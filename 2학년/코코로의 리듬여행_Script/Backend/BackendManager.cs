using BackEnd;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackendManager : MonoBehaviour
{
    public static BackendManager Instance;

    private Canvas canvas;
    [SerializeField] private TextMeshProUGUI errmsg;

    private bool IsAwake = true;

    private void Awake()
    {
        Backend.Initialize(true);
        IsAwake = false;

        Instance = this;

        canvas = GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    public void ErrorMsg(string msg)
    {
        errmsg.text = msg;
        canvas.enabled = true;
    }

    public void CloseError()
    {
        canvas.enabled = false;
    }

    async void Test()
    {

        await Task.Run(() =>
        {
            //CustomSignUp("tkfkadlsi", "@rladPtjd070113");
            //CustomLogin("tkfkadlsi", "@rladPtjd070113");
            //UpdateNickname("tkfkadlsi");
            //GameDataGet();
            //AureliaRank();

            Debug.Log("테스트를 종료합니다");
        });
    }

    public void CustomSignUp(string id, string pw)
    {
        Debug.Log("회원가입을 요청합니다.");

        var bro = Backend.BMember.CustomSignUp(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("회원가입에 성공했습니다. : " + bro);
            UpdateNickname(id);
            GameDataInsert();
            SceneManager.LoadScene("4_Tutorial");
        }
        else
        {
            var errcode = bro.GetStatusCode();
            switch (errcode)
            {
                case "409":
                    ErrorMsg("중복된 아이디에요.");
                    break;
                case "401":
                    ErrorMsg("점검중이에요.");
                    break;
                default:
                    ErrorMsg("알 수 없는 오류에요.");
                    break;
            }
        }
    }

    public void CustomLogin(string id, string pw)
    {
        Debug.Log("로그인을 요청합니다.");

        var bro = Backend.BMember.CustomLogin(id, pw);

        if (bro.IsSuccess())
        {
            Debug.Log("로그인에 성공했습니다.");
            GetUserNickName();
            GameDataGet();
            GetRanks();
            UIManager.Instance.ProfileFuncs.SetProfile();
            TitleUIManager.Instance.LoginSuccess();
        }
        else
        {
            var errorcode = bro.GetStatusCode();
            switch (errorcode)
            {
                case "401":
                    ErrorMsg("아이디 또는 비밀번호를 확인해주세요.");
                    break;
                default:
                    ErrorMsg("알 수 없는 오류에요.");
                    break;
            }
        }
    }

    public void GetUserNickName()
    {
        Debug.Log("닉네임을 불러옵니다.");
        BackendReturnObject bro = Backend.BMember.GetUserInfo();
        Information.Instance.userNickname = bro.GetReturnValuetoJSON()["row"]["nickname"].ToString();
        Debug.Log("닉네임 불러오기를 성공했습니다.");
    }

    public void UpdateNickname(string nickname)
    {
        Debug.Log("닉네임 변경을 요청합니다.");

        var bro = Backend.BMember.UpdateNickname(nickname);

        if (bro.IsSuccess())
        {
            Debug.Log("닉네임 변경에 성공했습니다 : " + bro);
        }
        else
        {
            Debug.LogError("닉네임 변경에 실패했습니다 : " + bro);
        }
    }

    private string gameDataRowInDate = string.Empty;

    public void GameDataInsert()
    {
        Param param = new Param();
        param.Add("Playcount", Information.Instance.GameData.playCount);
        param.Add("HighScore", Information.Instance.GameData.PlayerHighScore);
        param.Add("HighRate", Information.Instance.GameData.PlayerHighRate);

        Backend.GameData.Insert("GameData", param);
    }

    public void GameDataGet()
    {
        Debug.Log("게임 정보 조회 함수를 호출합니다.");
        var bro = Backend.GameData.GetMyData("GameData", new Where());
        if (bro.IsSuccess())
        {
            Debug.Log("게임 정보 조회에 성공했습니다. : " + bro);


            LitJson.JsonData gameDataJson = bro.FlattenRows(); // Json으로 리턴된 데이터를 받아옵니다.

            // 받아온 데이터의 갯수가 0이라면 데이터가 존재하지 않는 것입니다.
            if (gameDataJson.Count <= 0)
            {
                Debug.LogWarning("데이터가 존재하지 않습니다.");
            }
            else
            {
                gameDataRowInDate = gameDataJson[0]["inDate"].ToString(); //불러온 게임정보의 고유값입니다.
                Information.Instance.GameData = new GameData();

                Information.Instance.GameData.playCount = int.Parse(gameDataJson[0]["Playcount"].ToString());

                foreach (string key in gameDataJson[0]["HighScore"].Keys)
                {
                    Debug.Log(key);
                    Information.Instance.GameData.PlayerHighScore.Add(key, int.Parse(gameDataJson[0]["HighScore"][key].ToString()));
                }
                foreach (string key in gameDataJson[0]["HighRate"].Keys)
                {
                    Information.Instance.GameData.PlayerHighRate.Add(key, float.Parse(gameDataJson[0]["HighRate"][key].ToString()));
                }

            }
        }
        else
        {
            Debug.LogError("게임 정보 조회에 실패했습니다. : " + bro);
        }
    }

    public void GameDataUpdate()
    {
        if (Information.Instance.GameData == null)
        {
            Debug.LogError("서버에서 다운받거나 새로 삽입한 데이터가 존재하지 않습니다. Insert 혹은 Get을 통해 데이터를 생성해주세요.");
            return;
        }

        Param param = new Param();
        param.Add("Playcount", Information.Instance.GameData.playCount);
        param.Add("HighScore", Information.Instance.GameData.PlayerHighScore);
        param.Add("HighRate", Information.Instance.GameData.PlayerHighRate);

        BackendReturnObject bro = null;

        if (string.IsNullOrEmpty(gameDataRowInDate))
        {
            Debug.Log("내 제일 최신 게임정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.Update("GameData", new Where(), param);
        }
        else
        {
            Debug.Log($"{gameDataRowInDate}의 게임정보 데이터 수정을 요청합니다.");

            bro = Backend.GameData.UpdateV2("GameData", gameDataRowInDate, Backend.UserInDate, param);
        }

        if (bro.IsSuccess())
        {
            Debug.Log("게임정보 데이터 수정에 성공했습니다. : " + bro);
        }
        else
        {
            Debug.LogError("게임정보 데이터 수정에 실패했습니다. : " + bro);
        }
    }

    public void GetRanks()
    {
        string aureliaUUID = "3d644d20-1c11-11ef-be9a-ff517081b521";
        string witchRecordUUID = "503e59e0-1c11-11ef-8481-0d388203abc3";
        var aureliaBro = Backend.URank.User.GetRankList(aureliaUUID);
        var witchRecordBro = Backend.URank.User.GetRankList(witchRecordUUID);

        if (!aureliaBro.IsSuccess() || !witchRecordBro.IsSuccess())
        {
            Debug.Log("랭킹 조회 실패");
            return;
        }

        List<RankData> aureliaRanks = new List<RankData>();
        List<RankData> witchReocrdRanks = new List<RankData>();

        foreach (LitJson.JsonData jsonData in aureliaBro.FlattenRows())
        {
            RankData rankData = new RankData();

            rankData.nickname = jsonData["nickname"].ToString();
            rankData.score = int.Parse(jsonData["score"].ToString());
            rankData.rank = int.Parse(jsonData["rank"].ToString());

            aureliaRanks.Add(rankData);
        }
        foreach (LitJson.JsonData jsonData in witchRecordBro.FlattenRows())
        {
            RankData rankData = new RankData();

            rankData.nickname = jsonData["nickname"].ToString();
            rankData.score = int.Parse(jsonData["score"].ToString());
            rankData.rank = int.Parse(jsonData["rank"].ToString());

            witchReocrdRanks.Add(rankData);
        }

        Information.Instance.AureliaRanking = aureliaRanks.OrderBy(rank => rank.rank).ToList();
        Information.Instance.WitchRecordRanking = witchReocrdRanks.OrderBy(rank => rank.rank).ToList();
        Debug.Log("랭킹 조회에 성공했습니다.");
    }

    public void AureliaRank()
    {
        string rankUUID = "3d644d20-1c11-11ef-be9a-ff517081b521";
        string tableName = "GameData";
        string rowInDate = string.Empty;

        var bro = Backend.GameData.GetMyData(tableName, new Where());

        if (bro.FlattenRows().Count > 0)
        {
            rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
        }
        else
        {
            Debug.Log("데이터가 존재하지 않습니다. 데이터 삽입을 시도합니다.");
            var bro2 = Backend.GameData.Insert(tableName);

            if (bro2.IsSuccess() == false)
            {
                Debug.LogError("데이터 삽입 중 문제가 발생했습니다 : " + bro2);
                return;
            }

            Debug.Log("데이터 삽입에 성공했습니다 : " + bro2);

            rowInDate = bro2.GetInDate();
        }

        string key = DataKey.ReturnKey(SongTitle.Aurelia, DiffcultType.Special);

        if (!Information.Instance.GameData.PlayerHighScore.ContainsKey(key))
        {
            Information.Instance.GameData.PlayerHighScore.Add(key, 0);
        }
        if (!Information.Instance.GameData.PlayerHighRate.ContainsKey(key))
        {
            Information.Instance.GameData.PlayerHighRate.Add(key, 0);
        }

        Param param = new Param();
        param.Add("Playcount", Information.Instance.GameData.PlayerHighScore[key]);

        var rankBro = Backend.URank.User.UpdateUserScore(rankUUID, tableName, rowInDate, param);

        if (rankBro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 등록 중 오류가 발생했습니다. : " + rankBro);
            return;
        }

        Debug.Log("랭킹 삽입에 성공했습니다. : " + rankBro);
    }

    public void WRRank()
    {
        string rankUUID = "503e59e0-1c11-11ef-8481-0d388203abc3";
        string tableName = "GameData";
        string rowInDate = string.Empty;

        var bro = Backend.GameData.GetMyData(tableName, new Where());

        if (bro.FlattenRows().Count > 0)
        {
            rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
        }
        else
        {
            Debug.Log("데이터가 존재하지 않습니다. 데이터 삽입을 시도합니다.");
            var bro2 = Backend.GameData.Insert(tableName);

            if (bro2.IsSuccess() == false)
            {
                Debug.LogError("데이터 삽입 중 문제가 발생했습니다 : " + bro2);
                return;
            }

            Debug.Log("데이터 삽입에 성공했습니다 : " + bro2);

            rowInDate = bro2.GetInDate();
        }

        string key = DataKey.ReturnKey(SongTitle.Witch_Record, DiffcultType.Special);

        if (!Information.Instance.GameData.PlayerHighScore.ContainsKey(key))
        {
            Information.Instance.GameData.PlayerHighScore.Add(key, 0);
        }
        if (!Information.Instance.GameData.PlayerHighRate.ContainsKey(key))
        {
            Information.Instance.GameData.PlayerHighRate.Add(key, 0);
        }

        Param param = new Param();
        param.Add("Playcount", Information.Instance.GameData.PlayerHighScore[key]);

        var rankBro = Backend.URank.User.UpdateUserScore(rankUUID, tableName, rowInDate, param);

        if (rankBro.IsSuccess() == false)
        {
            Debug.LogError("랭킹 등록 중 오류가 발생했습니다. : " + rankBro);
            return;
        }

        Debug.Log("랭킹 삽입에 성공했습니다. : " + rankBro);
    }

    private void OnApplicationQuit()
    {
        GameDataUpdate();
    }
}