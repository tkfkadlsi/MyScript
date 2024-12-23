using BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackEndManager : MonoBehaviour
{
    public static BackEndManager Instance;
    public string gameDataRowInDate;

    public void UserSignUp(string id, string pw)
    {

        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            //회원가입이 성공하면 유저로그인을 시도한다.
            UserSignIn(id, pw);

            //닉네임을 생성한다
            Backend.BMember.UpdateNickname(id);
            SetRanking();
        }
        else
        {
            StartPanelSystem startPanel = FindObjectOfType<StartPanelSystem>();
            PopupPanel popupPanel = FindObjectOfType<PopupPanel>();
            var errcode = bro.GetMessage();
            if (errcode.Contains("serverStatus"))
            {
                startPanel.OpenPanel(startPanel.popupPanel);
                popupPanel.SettingPanel(PopupType.ServerInspection);
            }
            if (errcode.Contains("Duplicated"))
            {
                UserSignIn(id, pw);
            }
        }
    }

    public void UserSignIn(string id, string pw)
    {
        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            //차트를 불러온다
            BackendChart.Instance.GetChart("141349");

            //버전을 체크한다
            StartPanelSystem startPanel = FindObjectOfType<StartPanelSystem>();
            PopupPanel popupPanel = FindObjectOfType<PopupPanel>();
            bool VCheck = false;
            foreach (string ver in Information.Instance.gameversion)
            {
                if (Application.version == ver)
                {
                    VCheck = true;
                }
            }

            //만약 버전이 틀리다면 내보낸다
            if (VCheck == false)
            {
                startPanel.OpenPanel(startPanel.popupPanel);
                popupPanel.SettingPanel(PopupType.NoUpdate);
                return;
            }

            //유저 데이터를 불러온다
            GameDataGet();

            //랭킹 데이터를 불러온다
            GetRanking();

            //로컬에 저장한다

            Information.Instance.GameData.Nickname = id;
            Information.Instance.GameData.PassWord = pw;

            startPanel.ClosePanel(startPanel.namePanel);
        }
        else
        {
            StartPanelSystem startPanel = FindObjectOfType<StartPanelSystem>();
            PopupPanel popupPanel = FindObjectOfType<PopupPanel>();
            var errcode = bro.GetMessage();
            if (errcode.Contains("serverStatus"))
            {
                startPanel.OpenPanel(startPanel.popupPanel);
                popupPanel.SettingPanel(PopupType.ServerInspection);
            }
            if (errcode.Contains("customPassword"))
            {
                startPanel.OpenPanel(startPanel.popupPanel);
                popupPanel.SettingPanel(PopupType.EqualIDorFailPassword);
            }
            if (errcode.Contains("customId"))
            {
                startPanel.OpenPanel(startPanel.popupPanel);
                popupPanel.SettingPanel(PopupType.NotID);
            }
        }
    }

    public void GameDataInsert()
    {
        Param param = new Param();
        param.Add("Level", Information.Instance.GameData.LV);
        param.Add("EXP", Information.Instance.GameData.Exp);
        param.Add("Coin", Information.Instance.GameData.Coin);
        param.Add("Ticket", Information.Instance.GameData.EnterTicket);

        Backend.GameData.Insert("User_Level", param);
    }

    public void GameDataGet()
    {

        var bro = Backend.GameData.GetMyData("User_Level", new Where());

        if (bro.IsSuccess())
        {

            LitJson.JsonData gamedataJson = bro.FlattenRows();

            if (gamedataJson.Count <= 0)
            {
            }
            else
            {
                gameDataRowInDate = gamedataJson[0]["inDate"].ToString();

                Information.Instance.GameData.LV = int.Parse(gamedataJson[0]["Level"].ToString());
                Information.Instance.GameData.Exp = int.Parse(gamedataJson[0]["EXP"].ToString());
                Information.Instance.GameData.Coin = int.Parse(gamedataJson[0]["Coin"].ToString());
                Information.Instance.GameData.EnterTicket = int.Parse(gamedataJson[0]["Ticket"].ToString());
            }
        }
        else
        {
            GameDataInsert();
        }
    }

    public void GameDataUpdate()
    {
        Param param = new Param();
        param.Add("Level", Information.Instance.GameData.LV);
        param.Add("EXP", Information.Instance.GameData.Exp);
        param.Add("Coin", Information.Instance.GameData.Coin);
        param.Add("Ticket", Information.Instance.GameData.EnterTicket);

        BackendReturnObject bro = null;

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            bro = Backend.GameData.Update("User_Level", new Where(), param);
        }
        else
        {
            bro = Backend.GameData.UpdateV2("User_Level", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
        }
        else
        {
            Debug.LogError("게임 정보 데이터 수정에 실패했습니다.");
        }
    }

    public void SetRanking()
    {
        string rankingUUID = "7abc62e0-5409-11ef-a9b0-51b0ed58505a";

        string tableName = "User_Level";
        string rowInDate = string.Empty;

        var bro = Backend.GameData.GetMyData(tableName, new Where());

        if (!bro.IsSuccess())
        {
            return;
        }


        if (bro.FlattenRows().Count > 0)
        {
            rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
        }
        else
        {
            var bro2 = Backend.GameData.Insert(tableName);

            if (!bro.IsSuccess())
            {
                return;
            }

            rowInDate = bro2.GetInDate();
        }

        Param param = new Param();

        param.Add("Level", Information.Instance.GameData.LV);

        var rankBro = Backend.URank.User.UpdateUserScore(rankingUUID, tableName, rowInDate, param);

        if (!rankBro.IsSuccess())
        {
            return;
        }

    }

    public void GetRanking()
    {
        string rankingUUID = "7abc62e0-5409-11ef-a9b0-51b0ed58505a";
        var bro = Backend.URank.User.GetRankList(rankingUUID);

        if (!bro.IsSuccess())
        {
            return;
        }

        List<RankingData> rankList = new List<RankingData>();
        foreach (LitJson.JsonData jsonData in bro.FlattenRows())
        {
            RankingData rankingData = new RankingData();
            rankingData.rank = jsonData["rank"].ToString();
            rankingData.name = jsonData["nickname"].ToString();
            rankingData.score = jsonData["score"].ToString();

            rankList.Add(rankingData);


            Debug.Log(rankingData.name + '\n' + rankingData.score + '\n' + rankingData.rank);
        }
        var bro2 = Backend.URank.User.GetMyRank(rankingUUID);

        RankingData myRankingData = new RankingData();
        if(bro2.IsSuccess())
        {
            myRankingData.rank = bro2.FlattenRows()[0]["rank"].ToString();
            myRankingData.name = bro2.FlattenRows()[0]["nickname"].ToString();
            myRankingData.score = bro2.FlattenRows()[0]["score"].ToString();
        }


        Information.Instance.myRankingData = myRankingData;

        Information.Instance.rankingDatas = rankList;

    }

    private void Awake()
    {
        Backend.Initialize(true);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void OnEnable()
    //{
    //    AudioSettings.OnAudioConfigurationChanged += HandleChangeAudioConfiguration;
    //}

    //private void HandleChangeAudioConfiguration(bool deviceWasChanged)
    //{
    //    if(BluetoothChecker.IsBluetoothAudioDevice())
    //    {
    //        Information.Instance.offset = 150;
    //    }
    //    else
    //    {
    //        Information.Instance.offset = 0;
    //    }
    //}

    private void OnApplicationFocus(bool focus)
    {
        GameDataUpdate();
        SetRanking();
    }

    private void OnDisable()
    {
        //AudioSettings.OnAudioConfigurationChanged -= HandleChangeAudioConfiguration;
        GameDataUpdate();
    }
}

//public class BluetoothChecker
//{
//    public static bool IsBluetoothAudioDevice()
//    {
//        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
//        {
//            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
//            AndroidJavaObject audioManager = activity.Call<AndroidJavaObject>("getSystemService", "audio");
//            int deviceType = audioManager.Call<int>("getMode");

//            return deviceType == 3; // AudioManager.MODE_IN_COMMUNICATION for Bluetooth devices
//        }
//    }
//}
