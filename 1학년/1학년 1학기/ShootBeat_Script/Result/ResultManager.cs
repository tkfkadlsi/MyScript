using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : MonoBehaviour
{
    Song2Information information = Song2Information.instance;

    int score;
    int combo;
    int perfect;
    int good;
    int bad;
    int miss;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI perfectText;
    public TextMeshProUGUI goodText;
    public TextMeshProUGUI badText;
    public TextMeshProUGUI missText;
    public TextMeshProUGUI specialText;
    public TextMeshProUGUI classText;

    public AudioSource audioSource;

    public GameObject button;


    private void Awake()
    {
        Time.timeScale = 1;
        button.SetActive(false);
    }

    private IEnumerator Start()
    {
        if (information != null)
        {
            score = information.score1;
            combo = information.combo1;
            perfect = information.perfect1;
            good = information.good1;
            bad = information.bad1;
            miss = information.miss1;
        }
        Destroy(information.gameObject);
        yield return new WaitForSeconds(1);
        audioSource.Play();
        StartCoroutine("Score");
        StartCoroutine("Judge");
    }

    IEnumerator Score()
    {
        for (int i = 0; i <= score; i += 4321)
        {
            scoreText.text = $"Score : {i}";
            yield return null;
        }
        scoreText.text = $"Score : {score}";

        yield return new WaitForSeconds(1);

        if (score >= 900000)
        {
            classText.color = new Color(1, 0.8f, 0);
            classText.text = "S";
        }
        else if (score >= 750000)
        {
            classText.color = new Color(0, 1, 0);
            classText.text = "A";
        }
        else if (score >= 600000)
        {
            classText.color = new Color(0, 0, 1);
            classText.text = "B";
        }
        else if (score >= 400000)
        {
            classText.color = new Color(1, 0, 0);
            classText.text = "C";
        }
        else
        {
            classText.color = new Color(0, 0, 0);
            classText.text = "D";
        }

        button.SetActive(true);
    }

    IEnumerator Judge()
    {
        for (int i = 0; i <= 1331; i++)
        {
            if (i <= perfect)
            {
                perfectText.text = $"Perfect  {i}";
            }
            if (i <= good)
            {
                goodText.text = $"Good  {i}";
            }
            if (i <= bad)
            {
                badText.text = $"Bad  {i}";
            }
            if (i <= miss)
            {
                missText.text = $"Miss  {i}";
            }
            if (i <= combo)
            {
                comboText.text = $"Combo : {i}";
            }
            yield return new WaitForEndOfFrame();
        }
        if (miss == 0) specialText.text = "Full Combo";
        if (good == 0 && bad == 0 && miss == 0) specialText.text = "All Pefect";
    }
}