using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    GaugeManage gaugeManage;
    PlayerLaser playerLaser;
    AudioManage audioManage;
    [SerializeField] private GameObject dashCheck;
    [SerializeField] private GameObject laserCheck;
    [SerializeField] private GameObject chargeLight;

    public Vector2 maxPos;
    public Vector2 minPos;

    float laserDamage = 0;

    float laserCooltime = 10.0f;
    float lasertime = 0.0f;
    void Start()
    {
        gaugeManage = GameManager.instance.gaugeManage;
        playerLaser = GameManager.instance.playerLaser;
        audioManage = GameManager.instance.audioManage;
        chargeLight.SetActive(false);
    }

    float moveSpeed = 3.0f;
    float rotateSpeed = 180.0f;

    bool charging = false;

    // Update is called once per frame
    void Update()
    {
        #region 이동
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime, Space.Self);
        }
        #endregion 이동

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            gaugeManage.DashManage();
        }

        if(Input.GetKeyDown(KeyCode.Space) && lasertime >= laserCooltime && powerDown == false)
        {
            audioManage.playerLaserCharge();
            chargeLight.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space) && lasertime >= laserCooltime && powerDown == false)
        {
            charging = true;
            gaugeManage.ChargingLaser();
            moveSpeed = 1.5f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && charging == true)
        {
            audioManage.playerLaserShoot();
            chargeLight.SetActive(false);
            playerLaser.LaserFire(laserDamage);
            LaserDamageReset();
            lasertime = 0;
            charging = false;
        }

        if(lasertime >= laserCooltime)
        {
            laserCheck.SetActive(true);
        }
        else
        {
            laserCheck.SetActive(false);
        }

        lasertime += Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x), Mathf.Clamp(transform.position.y, minPos.y, maxPos.y), 0);
    }

    private void FixedUpdate()
    {
        chargeLight.transform.position = gameObject.transform.position;
    }

    public void CallDash()
    {
        StartCoroutine("Dash");
        dashCheck.SetActive(false);
    }

    IEnumerator Dash()
    {
        for (int i = 0; i < 10; i++) 
        {
            transform.Translate(Vector2.up * 0.2f, Space.Self);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void LaserDamageUp()
    {
        laserDamage += 13.0f * Time.deltaTime;
    }

    void LaserDamageReset()
    {
        laserDamage = 0;
        moveSpeed = 3.0f;
    }

    bool powerDown = false;

    public void PowerDown()
    {
        powerDown = true;
        moveSpeed = 0.0f;
        rotateSpeed = 90.0f;
    }

    public void PowerRepair()
    {
        powerDown = false;
        moveSpeed = 3.0f;
        rotateSpeed = 180.0f;
    }
}
