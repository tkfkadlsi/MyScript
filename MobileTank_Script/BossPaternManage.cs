using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossPaternManage : MonoBehaviour
{
    MissileLaunch misslieLaunch;
    BossLeftArm leftArm;
    LastPatern lastPatern;
    AudioManage audioManage;
    Slider bossLArmGauge;
    Slider bossRArmGauge;
    GameObject cannon;
    GameObject lastLaser;
    GameObject laserWarning;
    GameObject bossBody;
    GameObject cannonWarning;
    SpriteRenderer warningRenderer;
    [SerializeField] private GameObject lightPrefab;
    bool Phase2 = false;
    bool Phase3 = false;
    bool Phase4 = false;
    void Start()
    {
        misslieLaunch = GameManager.instance.missileLaunch;
        leftArm = GameManager.instance.bossLeftArm;
        cannon = GameManager.instance.cannon;
        lastPatern = GameManager.instance.lastPatern;
        lastLaser = GameManager.instance.lastLaser;
        laserWarning = GameManager.instance.laserWarning;
        bossBody = GameManager.instance.bossBody;
        audioManage = GameManager.instance.audioManage;
        cannonWarning = GameManager.instance.cannonWarning;
        warningRenderer = laserWarning.GetComponent<SpriteRenderer>();
        bossLArmGauge = GameManager.instance.bossLArmGauge.GetComponent<Slider>();
        bossRArmGauge = GameManager.instance.bossRArmGauge.GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine("FirstPatern");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator APaternStartCall()
    {
        yield return null;
        int ARandomPatern = 0;
        ARandomPatern = Random.Range(1, 4);

        if (ARandomPatern == 1)
        {
            if(Phase2 == true)
            {
                misslieLaunch.MissileLaunchCall();
            }
            else
            {
                StartCoroutine("APaternStartCall");
            }
        }
        else if(ARandomPatern == 2)
        {
            if (Phase3 == true && bossRArmGauge.value >= 0.01f)
            {
                cannonWarning.SetActive(true);
                yield return new WaitForSeconds(1.5f);
                cannonWarning.SetActive(false);
                audioManage.CannonLaunch();
                yield return new WaitForSeconds(0.125f);
                cannon.SetActive(true);
            }
            else
            {
                StartCoroutine("APaternStartCall");
            }
        }
        else if(ARandomPatern == 3)
        {
            StartCoroutine("APaternStartCall");
        }
    }

    IEnumerator BPaternStartCall()
    {
        yield return null;
        int BRandomPatern = 0;
        BRandomPatern = Random.Range(1, 4);

        if (BRandomPatern == 1 && bossLArmGauge.value >= 0.01f)
        {
            leftArm.CallPunch();
        }
        else if (BRandomPatern == 2)
        {
            if(Phase2 == true && bossLArmGauge.value >= 0.01f)
            {
                leftArm.CallPunch2();
            }
            else
            {
                StartCoroutine("BPaternStartCall");
            }
        }
        else if(BRandomPatern == 3)
        {
            if(Phase4 == true)
            {
                audioManage.BossLaserWarning();
                GameObject obj = Instantiate(lightPrefab, new Vector3(bossBody.transform.position.x, bossBody.transform.position.y + 1.75f), Quaternion.identity);
                for (int i = 0; i < 10; i++)
                {
                    warningRenderer.color = new Color(warningRenderer.color.r - 0.1f, warningRenderer.color.g, warningRenderer.color.b - 0.1f);
                    yield return new WaitForSeconds(0.1f);
                }
                for (int i = 0; i < 10; i++)
                {
                    warningRenderer.color = new Color(warningRenderer.color.r + 0.1f, warningRenderer.color.g, warningRenderer.color.b + 0.1f);
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(1.0f);

                Destroy(obj);

                lastLaser.SetActive(true);
                lastPatern.StartCoroutine("CallLaser");
            }
            else
            {
                StartCoroutine("BPaternStartCall");
            }
        }
    }

    public void APaternEndCall()
    {
        StartCoroutine("APaternCooltime");
    }

    public void BPaternEndCall()
    {
        StartCoroutine("BPaternCooltime");
    }

    IEnumerator FirstPatern()
    {
        yield return new WaitForSeconds(3.0f);
        StartCoroutine("BPaternStartCall");
        StartCoroutine("APaternStartCall");
    }

    IEnumerator APaternCooltime()
    {
        yield return new WaitForSeconds(2.0f);

        StartCoroutine("APaternStartCall");
    }

    IEnumerator BPaternCooltime()
    {
        yield return new WaitForSeconds(4.0f);

        StartCoroutine("BPaternStartCall");
    }

    public void Phase2Start()
    {
        Phase2 = true;
    }

    public void Phase3Start()
    {
        Phase3 = true;
    }

    public void Phase4Start()
    {
        Phase4 = true;
    }
}
