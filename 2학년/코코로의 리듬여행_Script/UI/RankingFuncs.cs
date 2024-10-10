using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingFuncs : MonoBehaviour
{
    [SerializeField] private List<GameObject> AureliaRank = new List<GameObject>();
    [SerializeField] private List<GameObject> WitchRecordRank = new List<GameObject>();

    private TextMeshProUGUI rankTMP;
    private TextMeshProUGUI nameTMP;
    private TextMeshProUGUI scoreTMP;

    public void UpdateRankingBoard()
    {
        int aureliaRankCount = Information.Instance.AureliaRanking.Count >= 3 ? 3 : Information.Instance.AureliaRanking.Count;
        int witchRecordRankCount = Information.Instance.WitchRecordRanking.Count >= 3 ? 3 : Information.Instance.WitchRecordRanking.Count;

        for (int i = 0; i < aureliaRankCount; i++)
        {
            rankTMP = AureliaRank[i].transform.Find("Rank").GetComponent<TextMeshProUGUI>();
            nameTMP = AureliaRank[i].transform.Find("NickName").GetComponent<TextMeshProUGUI>();
            scoreTMP = AureliaRank[i].transform.Find("Score").GetComponent<TextMeshProUGUI>();

            rankTMP.text = Information.Instance.AureliaRanking[i].rank.ToString();
            nameTMP.text = Information.Instance.AureliaRanking[i].nickname;
            scoreTMP.text = Information.Instance.AureliaRanking[i].score.ToString();
        }

        rankTMP = AureliaRank[3].transform.Find("Rank").GetComponent<TextMeshProUGUI>();
        nameTMP = AureliaRank[3].transform.Find("NickName").GetComponent<TextMeshProUGUI>();
        scoreTMP = AureliaRank[3].transform.Find("Score").GetComponent<TextMeshProUGUI>();

        rankTMP.text = "";
        nameTMP.text = Information.Instance.userNickname;
        scoreTMP.text = "플레이 정보 없음";

        foreach (RankData rankData in Information.Instance.AureliaRanking)
        {
            if (rankData.nickname == Information.Instance.userNickname)
            {

                rankTMP.text = rankData.rank.ToString();
                nameTMP.text = rankData.nickname;
                scoreTMP.text = rankData.score.ToString();
            }
        }

        for (int i = 0; i < witchRecordRankCount; i++)
        {
            rankTMP = WitchRecordRank[i].transform.Find("Rank").GetComponent<TextMeshProUGUI>();
            nameTMP = WitchRecordRank[i].transform.Find("NickName").GetComponent<TextMeshProUGUI>();
            scoreTMP = WitchRecordRank[i].transform.Find("Score").GetComponent<TextMeshProUGUI>();

            rankTMP.text = Information.Instance.WitchRecordRanking[i].rank.ToString();
            nameTMP.text = Information.Instance.WitchRecordRanking[i].nickname;
            scoreTMP.text = Information.Instance.WitchRecordRanking[i].score.ToString();
        }

        rankTMP = WitchRecordRank[3].transform.Find("Rank").GetComponent<TextMeshProUGUI>();
        nameTMP = WitchRecordRank[3].transform.Find("NickName").GetComponent<TextMeshProUGUI>();
        scoreTMP = WitchRecordRank[3].transform.Find("Score").GetComponent<TextMeshProUGUI>();

        rankTMP.text = "";
        nameTMP.text = Information.Instance.userNickname;
        scoreTMP.text = "플레이 정보 없음";

        foreach (RankData rankData in Information.Instance.WitchRecordRanking)
        {
            if (rankData.nickname == Information.Instance.userNickname)
            {

                rankTMP.text = rankData.rank.ToString();
                nameTMP.text = rankData.nickname;
                scoreTMP.text = rankData.score.ToString();
            }
        }
    }
}
