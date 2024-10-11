using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreTMP;
    [SerializeField] private TextMeshProUGUI RateTMP;
    [SerializeField] private TextMeshProUGUI ClassTMP;
    [SerializeField] private TextMeshProUGUI PerfectPlusCountTMP;
    [SerializeField] private TextMeshProUGUI PerfectCountTMP;
    [SerializeField] private TextMeshProUGUI GreatCountTMP;
    [SerializeField] private TextMeshProUGUI GoodCountTMP;
    [SerializeField] private TextMeshProUGUI BadCountTMP;
    [SerializeField] private TextMeshProUGUI MissCountTMP;
    [SerializeField] private TextMeshProUGUI FastCountTMP;
    [SerializeField] private TextMeshProUGUI SlowCountTMP;
    [SerializeField] private TextMeshProUGUI MaxComboTMP;

    private Result result;
    public static ResultManager Instance;
    private void Awake()
    {
        Instance = this;

        Cursor.visible = true;
    }

    private void Start()
    {
        result = Information.Instance.Result;
        StartCoroutine(ResultLerp());

        string key = DataKey.ReturnKey(Information.Instance.CurrentSong, Information.Instance.DiffcultType);

        Information.Instance.GameData.playCount++;

        if (Information.Instance.GameData.PlayerHighScore[key] <= result.Score + result.BellScore)
        {
            Information.Instance.GameData.PlayerHighScore[key] = result.Score + result.BellScore;
            Information.Instance.GameData.PlayerHighRate[key] = result.Rate;

            string aureliaKey = DataKey.ReturnKey(SongTitle.Aurelia, DiffcultType.Special);
            if (aureliaKey == key)
            {
                BackendManager.Instance.AureliaRank();
                BackendManager.Instance.GetRanks();
            }

            string witchRecordKey = DataKey.ReturnKey(SongTitle.Witch_Record, DiffcultType.Special);
            if (witchRecordKey == key)
            {
                BackendManager.Instance.WRRank();
                BackendManager.Instance.GetRanks();
            }
        }
    }

    private IEnumerator ResultLerp()
    {
        float lerpTime = 1.0f;
        float t = 0f;

        while (t < lerpTime + 0.1f)
        {
            ScoreTMP.text = "점수 : " + ((int)Mathf.Lerp(0, result.Score + result.BellScore, t / lerpTime)).ToString();
            RateTMP.text = "정확도 : " + Mathf.Lerp(0f, result.Rate, t / lerpTime).ToString("#.00") + "%";
            PerfectPlusCountTMP.text = "Perfect+    " + ((int)Mathf.Lerp(0, result.PerfectPlusCount, t / lerpTime)).ToString();
            PerfectCountTMP.text = "Perfect    " + ((int)Mathf.Lerp(0, result.PerfectCount, t / lerpTime)).ToString();
            GreatCountTMP.text = "Great    " + ((int)Mathf.Lerp(0, result.GreatCount, t / lerpTime)).ToString();
            GoodCountTMP.text = "Good    " + ((int)Mathf.Lerp(0, result.GoodCount, t / lerpTime)).ToString();
            BadCountTMP.text = "Bad    " + ((int)Mathf.Lerp(0, result.BadCount, t / lerpTime)).ToString();
            MissCountTMP.text = "Miss    " + ((int)Mathf.Lerp(0, result.MissCount, t / lerpTime)).ToString();
            FastCountTMP.text = "Fast    " + ((int)Mathf.Lerp(0, result.FastCount, t / lerpTime)).ToString();
            SlowCountTMP.text = "Slow    " + ((int)Mathf.Lerp(0, result.SlowCount, t / lerpTime)).ToString();
            MaxComboTMP.text = "최고 콤보    " + ((int)Mathf.Lerp(0, result.MaxCombo, t / lerpTime)).ToString();

            t += Time.deltaTime;
            yield return null;
        }

        if (result.Rate >= (int)ClassType.SS)
        {
            ClassTMP.text = "SS";
        }
        else if (result.Rate >= (int)ClassType.SP)
        {
            ClassTMP.text = "S+";
        }
        else if (result.Rate >= (int)ClassType.S)
        {
            ClassTMP.text = "S";
        }
        else if (result.Rate >= (int)ClassType.A)
        {
            ClassTMP.text = "A";
        }
        else if (result.Rate >= (int)ClassType.B)
        {
            ClassTMP.text = "B";
        }
        else if (result.Rate >= (int)ClassType.C)
        {
            ClassTMP.text = "C";
        }
        else
        {
            ClassTMP.text = "D";
        }
    }

    public void GoLobby()
    {
        SceneManager.LoadScene("1_Selection");
    }
}
