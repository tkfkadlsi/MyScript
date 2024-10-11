using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Slider playerHPSlider;

    [SerializeField] private TextMeshProUGUI scoreTMP;

    [SerializeField] private TextMeshProUGUI bellScoreTMP;

    [SerializeField] private TextMeshProUGUI rateTMP;

    [SerializeField] private TextMeshProUGUI comboTMP;

    [SerializeField] private TextMeshProUGUI fastslowTMP;
    [SerializeField] private Image fastslowImage;

    [SerializeField] private TextMeshProUGUI judgementTMP;
    private Vector2 startTweenPos;
    private Vector2 endTweenPos;

    private float playerHP = 1000f;

    private float judgementTextDisplayTime;
    private float fastslowTextDisplayTime;

    private int misslife = 0;

    private void Awake()
    {
        Time.fixedDeltaTime = 0.001f;
        Application.targetFrameRate = 144;
        Cursor.visible = false;
    }

    private void Start()
    {
        fastslowImage.gameObject.SetActive(false);
        judgementTMP.enabled = false;

        misslife = Information.Instance.OptionData.IsSuddenDeath ? -9999 : -100;

        startTweenPos = comboTMP.rectTransform.localPosition - new Vector3(0, -50, 0);
        endTweenPos = comboTMP.rectTransform.localPosition;
    }

    private void Update()
    {
        if (judgementTextDisplayTime < 0f && judgementTMP.enabled)
            judgementTMP.enabled = false;

        if (fastslowTextDisplayTime < 0f && fastslowImage.gameObject.activeSelf)
            fastslowImage.gameObject.SetActive(false);

        judgementTextDisplayTime -= Time.deltaTime;
        fastslowTextDisplayTime -= Time.deltaTime;
    }

    public void DisplayJudgement(JudgementType judgementType)
    {
        judgementTMP.rectTransform.DOKill();
        judgementTMP.rectTransform.localScale = Vector3.zero;
        judgementTMP.rectTransform.DOScale(comboTMP.rectTransform.localScale, 0.15f).SetEase(Ease.OutBack);
        judgementTextDisplayTime = 0.15f;
        judgementTMP.enabled = true;
        switch (judgementType)
        {
            case JudgementType.Perfect_Plus:
                judgementTMP.color = Color.blue;
                judgementTMP.text = "Perfect+";
                DisplayPlayerHP(5);
                break;
            case JudgementType.Perfect:
                judgementTMP.color = Color.cyan;
                judgementTMP.text = "Perfect";
                DisplayPlayerHP(4);
                break;
            case JudgementType.Great:
                judgementTMP.color = Color.green;
                judgementTMP.text = "Great";
                DisplayPlayerHP(3);
                break;
            case JudgementType.Good:
                judgementTMP.color = Color.yellow;
                judgementTMP.text = "Good";
                DisplayPlayerHP(2);
                break;
            case JudgementType.Bad:
                judgementTMP.color = Color.red;
                judgementTMP.text = "Bad";
                DisplayPlayerHP(1);
                break;
            case JudgementType.Miss:
                judgementTMP.color = Color.gray;
                judgementTMP.text = "Miss";
                DisplayPlayerHP(misslife);
                break;
        }
        scoreTMP.text = Information.Instance.Result.Score.ToString("0000000");
        rateTMP.text = $"{Information.Instance.Result.Rate.ToString("#00.00")}%";
    }

    public void DisplayFastSlow(bool isFast)
    {
        fastslowTextDisplayTime = 0.15f;
        fastslowImage.gameObject.SetActive(true);
        if (isFast)
        {
            fastslowTMP.text = "fast";
            fastslowImage.color = Color.blue;
            Information.Instance.Result.FastCount++;
        }
        else
        {
            fastslowTMP.text = "slow";
            fastslowImage.color = Color.red;
            Information.Instance.Result.SlowCount++;
        }
    }

    public void DisplayCombo()
    {
        comboTMP.rectTransform.DOKill();

        comboTMP.text =
            Information.Instance.Result.Combo == 0
            ? "" : Information.Instance.Result.Combo.ToString();

        comboTMP.rectTransform.localPosition = startTweenPos;
        comboTMP.rectTransform.DOLocalMove(endTweenPos, 0.15f);
    }

    public void DisplayBellScore()
    {
        bellScoreTMP.text = $"+{Information.Instance.Result.BellScore.ToString("00000")}";
    }

    private void DisplayPlayerHP(float plusHP)
    {
        StopCoroutine("PlayerHPSliderChange");
        StartCoroutine("PlayerHPSliderChange", plusHP);
    }

    private IEnumerator PlayerHPSliderChange(float plusHP)
    {
        float beforePlayerHP = playerHP;
        playerHP = Mathf.Clamp(playerHP + plusHP, 0f, 1000f);

        if (playerHP <= 0)
            GameManager.Instance.GameEnd.Die();

        float lerpTime = 0.1f;
        float t = 0f;

        while (t < lerpTime + 0.1f)
        {
            t += Time.deltaTime;
            yield return null;

            playerHPSlider.value = Mathf.Lerp(beforePlayerHP, playerHP, t / lerpTime);
        }


    }
}
