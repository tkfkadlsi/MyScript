using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeManage : MonoBehaviour
{
    [SerializeField] private GameObject dashCheck;
    [SerializeField] private GameObject DuraGauge;
    [SerializeField] private GameObject HpGauge;
    [SerializeField] private Image panel;
    Slider HpGaugeFill;
    Slider DuraSlider;
    Slider slider;
    TankMove tankMove;
    CameraMove cameraMove;

    BalKanPoMove balKanPoMove;
    BulletMove bulletMove;
    MissileDamage missileDamage;
    MissileMove missileMove;
    MissileWarningSign missileWarningSign;

    float dashCoolTime = 0.0f;
    bool powerDown = false;
    void Awake()
    {
        HpGaugeFill = HpGauge.GetComponent<Slider>();
        slider = GetComponent<Slider>();
        DuraSlider = DuraGauge.GetComponent<Slider>();
    }

    private void Start()
    {
        tankMove = GameManager.instance.tankMove;
        cameraMove = GameManager.instance.cameraMove;
    }

    void OnEnable()
    {

    }

    void Update()
    {
        slider.value += 0.2f * Time.deltaTime;
        dashCoolTime -= Time.deltaTime;
        CheckGauge();

        if (slider.value <= 2.0f)
        {
            DuraSlider.value -= 0.3f * Time.deltaTime;
        }

        if(dashCoolTime <= 0.01f)
        {
            dashCheck.SetActive(true);
        }
    }

    void CheckGauge()
    {
        if(HpGaugeFill.value <= 0.01f)
        {
            SceneManager.LoadScene(4);
        }
        else if(DuraSlider.value <= 0.01f && powerDown == false)
        {
            powerDown = true;
            StartCoroutine("PowerUp");
        }
    }

    IEnumerator PowerUp()
    {
        while(DuraSlider.value != 5)
        {
            DuraSlider.value += 0.03f;
            tankMove.PowerDown();
            yield return new WaitForSeconds(0.05f);
        }

        powerDown = false;
        tankMove.PowerRepair();
    }

    public void DashManage()
    {
        if(slider.value >= 2.5 && dashCoolTime <= 0.01f)
        {
            StartCoroutine("DashGauge");
            tankMove.CallDash();
            dashCoolTime = 2.0f;
        }
    }

    IEnumerator DashGauge()
    {
        for(int i = 0; i < 10; i++)
        {
            slider.value -= 0.25f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void CallBalKanDamage()
    {
        StartCoroutine("BalKanDamage");
    }

    IEnumerator BalKanDamage()
    {
        cameraMove.Shake();
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            HpGaugeFill.value -= 0.1f;
        }
    }

    public void CallMissileDamage()
    {
        StartCoroutine("MissileDamage");
    }

    IEnumerator MissileDamage()
    {
        cameraMove.Shake();
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            HpGaugeFill.value -= 0.8f;
        }
    }

    public void CallPunch1Damage()
    {
        cameraMove.Shake();
        StartCoroutine("PunchDamage");
    }

    IEnumerator PunchDamage()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            HpGaugeFill.value -= 1.5f;
        }
    }

    public void CallPunch2Damage()
    {
        cameraMove.Shake();
        StartCoroutine("Punch2Damage");
    }

    IEnumerator Punch2Damage()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            HpGaugeFill.value -= 2f;
        }
    }

    public void CallLaserDamage()
    {
        HpGaugeFill.value -= 1.5f * Time.deltaTime;
    }

    public void ChargingLaser()
    {
        if (slider.value >= 0.01f)
        {
            slider.value += -1f * Time.deltaTime;
            tankMove.LaserDamageUp();
        }
    }

    public IEnumerator CannonDamage()
    {
        cameraMove.Shake();
        for (int i = 0; i < 10; i++)
        {
            HpGaugeFill.value += -1f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator GameOver()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            panel.color = new Color(1, 1, 1, panel.color.a + 0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(4);
    }
}
