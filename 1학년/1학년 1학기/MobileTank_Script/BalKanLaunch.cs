using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalKanLaunch : MonoBehaviour
{
    public GameObject BossHead;
    public GameObject PlayerTank;
    Pools balKanPool;
    AudioManage audioManage;
    [SerializeField] private Slider slider;

    int countBalKan = 30;
    float reloadTime = 4;

    void Start()
    {
        audioManage = GameManager.instance.audioManage;
        balKanPool = GameManager.instance.pools;
        StartCoroutine("BalKanReload");
    }
    IEnumerator BalKanContinue()
    {
        if (slider.value >= 0.01f)
        {
           if(countBalKan > 0)
            {
                audioManage.BalKanPo();
                yield return new WaitForSeconds(0.1f);
                GameObject lbalkanPo = balKanPool.GetBalKan();
                countBalKan -= 1;
                GameObject rbalkanPo = balKanPool.GetBalKan();
                countBalKan -= 1;

                StartCoroutine("BalKanContinue");
            }
            else
            {
                StartCoroutine("BalKanReload");
            }
        }
    }

    IEnumerator BalKanReload()
    {
        yield return new WaitForSeconds(reloadTime);
        countBalKan = 30;
        StartCoroutine("BalKanContinue");
    }
}
