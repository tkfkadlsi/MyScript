using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronLaserShoot : MonoBehaviour
{
    [SerializeField] private GameObject DronLaser;
    bool phase3 = false;
    bool inOut = false;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        DronLaser.SetActive(false);
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    public void Phase3Start()
    {
        phase3 = true;
        inOut = true;
    }



    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine("LaserShoot");
    }

    IEnumerator LaserShoot()
    {
        if(phase3 == true && inOut == true)
        {
            DronLaser.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            DronLaser.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("LaserShoot");
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("LaserShoot");
        }
    }

    public void GetOut()
    {
        inOut = false;
    }

    public void GenIn()
    {
        inOut = true;
    }
}
