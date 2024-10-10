using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    Slider BossHp;
    BossDronMove dronMove;
    DronLaserShoot laserShoot;
    BoomString boomString;
    BossPaternManage paternManage;
    BoomSupport boomSupport;
    [SerializeField] private Slider bossBalKanHp;
    [SerializeField] private GameObject boomPanel;
    [SerializeField] private Image panel;
    [SerializeField] private TextMeshProUGUI phaseText;

    private void Start()
    {
        BossHp = GameManager.instance.bossHpGauge.GetComponent<Slider>();
        boomString = GameManager.instance.boomString;
        boomSupport = GameManager.instance.boomSupport;
        dronMove = GameManager.instance.bossDronMove;
        laserShoot = GameManager.instance.dronLaserShoot;
        paternManage = GameManager.instance.bossPaternManage;
        phaseText.enabled = false;
    }

    bool phase2 = false;
    bool phase3 = false;
    bool phase4 = false;
    bool finish = false;
    // Update is called once per frame
    void Update()
    {

        if(BossHp.value <= 2900 && phase2 == false)
        {
            phase2 = true;
            StartCoroutine("Phase2Timeslow");
        }

        if (BossHp.value <= 1700 && phase3 == false)
        {
            phase3 = true;
            StartCoroutine("Phase3Timeslow");
        }
        
        if(BossHp.value <= 500 && phase4 == false)
        {
            phase4 = true;
            StartCoroutine("Phase4Timeslow");
        }

        if (BossHp.value <= 0.01f && finish == false)
        {
            finish = true;
            StartCoroutine("GameClear");
        }
    }

    IEnumerator Phase2Timeslow()
    {
        for (int i = 0; i < 9; i++)
        {
            Time.timeScale += -0.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Time.timeScale = 0;
        StartCoroutine("StartPhase2");
        phaseText.text = "<Phase2>";
        StartCoroutine("TextFlash");
    }

    IEnumerator Phase3Timeslow()
    {
        for (int i = 0; i < 9; i++)
        {
            Time.timeScale += -0.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Time.timeScale = 0;
        StartCoroutine("StartPhase3");
        phaseText.text = "<Phase3>";
        StartCoroutine("TextFlash");
    }

    IEnumerator Phase4Timeslow()
    {
        for (int i = 0; i < 9; i++)
        {
            Time.timeScale += -0.1f;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Time.timeScale = 0;
        StartCoroutine("StartPhase4");
        phaseText.text = "<Phase4>";
        StartCoroutine("TextFlash");
    }

    public void StartPhase1()
    {
        Time.timeScale = 1;
    }

    public IEnumerator StartPhase2()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            Time.timeScale += 0.1f;
        }
        Time.timeScale = 1;
        paternManage.Phase2Start();
        IsRArmOk();
    }

    public IEnumerator StartPhase3()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            Time.timeScale += 0.1f;
        }
        Time.timeScale = 1;
        paternManage.Phase3Start();
        dronMove.Phase3Start();
        laserShoot.Phase3Start();
    }

    public IEnumerator StartPhase4()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(0.05f);
            Time.timeScale += 0.1f;
        }
        Time.timeScale = 1;
        paternManage.Phase4Start();
    }

    void IsRArmOk()
    {
        if(bossBalKanHp.value < 0.01f)
        {
            boomPanel.SetActive(true);
            boomString.StartCoroutine("CallBoom");
        }
        else
        {
            boomPanel.SetActive(true);
            boomString.StartCoroutine("FailBoom");
        }
    }

    public void FinishBoomText()
    {
        boomPanel.SetActive(false);
        boomSupport.StartCoroutine("BoomMove");
    }

    IEnumerator GameClear()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            panel.color = new Color(1, 1, 1, panel.color.a + 0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(5);
    }

    IEnumerator TextFlash()
    {
        phaseText.enabled = true;
        yield return new WaitForSeconds(0.5f);
        phaseText.enabled = false;
        yield return new WaitForSeconds(0.5f);
        phaseText.enabled = true;
        yield return new WaitForSeconds(0.5f);
        phaseText.enabled = false;
        yield return new WaitForSeconds(0.5f);
    }
}
