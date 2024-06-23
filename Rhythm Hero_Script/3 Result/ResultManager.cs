using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI criticalText;
    [SerializeField] private TextMeshProUGUI niceText;
    [SerializeField] private TextMeshProUGUI missText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI safeText;
    [SerializeField] private TextMeshProUGUI breakText;
    [SerializeField] private TextMeshProUGUI highComboText;
    [SerializeField] private TextMeshProUGUI tearText;
    [SerializeField] private TextMeshProUGUI rateText;

    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;

    AudioSource audioSource;

    private void Awake()
    {
        title.text = "";
        criticalText.text = "";
        niceText.text = "";
        missText.text = "";
        defenseText.text = "";
        safeText.text = "";
        breakText.text = "";
        highComboText.text = "";
        tearText.text = "";
        rateText.text = "";

        audioSource = GetComponent<AudioSource>();
    }

    int critical;
    int nice;
    int miss;
    int defense;
    int safe;
    int break_;

    int highCombo;

    int count;
    float rate;

    private void Start()
    {
        if(Information.instance.clearGame == true)
        {
            title.text = "Win";
            title.color = new Color(1, 1, 0.5f, 1);
            audioSource.PlayOneShot(winSound);
        }
        else if(Information.instance.clearGame == false)
        {
            title.text = "Lose";
            title.color = new Color(0.5f, 0.5f, 0.5f, 1);
            audioSource.PlayOneShot(loseSound);
        }

        critical = Information.instance._critical;
        nice = Information.instance._nice;
        miss = Information.instance._miss;
        defense = Information.instance._defense;
        safe = Information.instance._safe;
        break_ = Information.instance._break;
        highCombo = Information.instance._highCombo;

        rate = (critical * 100) + (nice * 90) + (miss * 0) + (defense * 100) + (safe * 90) + (break_ * 0);
        count = critical + nice + miss + defense + safe + break_;

        rate = rate / count;

        rate = Mathf.Round(rate * 100) / 100;

        StartCoroutine(Result());
    }

    IEnumerator Result()
    {
        yield return new WaitForSeconds(0.5f);

        criticalText.text = $"Critical : {critical}";

        yield return new WaitForSeconds(0.25f);

        niceText.text = $"Nice : {nice}";

        yield return new WaitForSeconds(0.25f);

        missText.text = $"Miss : {miss}";

        yield return new WaitForSeconds(0.25f);

        defenseText.text = $"Defense : {defense}";

        yield return new WaitForSeconds(0.25f);

        safeText.text = $"Safe : {safe}";

        yield return new WaitForSeconds(0.25f);

        breakText.text = $"Break : {break_}";

        yield return new WaitForSeconds(0.25f);

        highComboText.text = $"High Combo : {highCombo}";

        yield return new WaitForSeconds(0.25f);

        if(rate >= 97)
        {
            tearText.text = "S";
            tearText.color = new Color(1, 0.2f, 1);
        }
        else if(rate >= 95)
        {
            tearText.text = "A";
            tearText.color = new Color(1, 0.4f, 1);
        }
        else if(rate >= 90)
        {
            tearText.text = "B";
            tearText.color = new Color(1, 0.6f, 1);
        }
        else if(rate >= 75)
        {
            tearText.text = "C";
            tearText.color = new Color(1, 0.8f, 1);
        }
        else if(rate < 75)
        {
            tearText.text = "D";
            tearText.color = new Color(0.8f, 0.8f, 0.8f);
        }

        rateText.text = $"{rate}%";
    }

    public void GOLobby()
    {
        SceneManager.LoadScene(1);
    }
}
