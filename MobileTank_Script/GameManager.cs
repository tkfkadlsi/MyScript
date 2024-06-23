using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GaugeManage gaugeManage;

    public BalKanLaunch balKanLaunch;

    public BoomString boomString;

    public BoomSupport boomSupport;

    public BossDronMove bossDronMove;
    
    public BossEyeMove bossEyeMove;
    
    public BossHpManager bossHpManager;
    
    public BossLaser bossLaser;
    
    public BossLeftArm bossLeftArm;
    
    public BossManager bossManager;
    
    public BossPaternManage bossPaternManage;
    
    public DronLaserShoot dronLaserShoot;
    
    public MissileLaunch missileLaunch;
    
    public PhaseManager phaseManager;
    
    public PlayerLaser playerLaser;
    
    public TankMove tankMove;

    public Pools pools;

    public AudioManage audioManage;

    public LastPatern lastPatern;

    public Launch launch;

    public CameraMove cameraMove;

    public GameObject tank;

    public GameObject boss;

    public GameObject tower;

    public GameObject bosshead;

    public GameObject armClearSign;

    public GameObject poolManager;

    public GameObject poolStorage;

    public GameObject bossHpGauge;

    public GameObject bossRArmGauge;

    public GameObject bossLArmGauge;

    public GameObject bossBalKanGauge;

    public GameObject phasePanel;

    public GameObject bossRArm;

    public GameObject cannon;

    public GameObject balKanShoot;

    public GameObject bossLArm;

    public GameObject lastLaser;

    public GameObject playerHp;

    public GameObject mainCamera;

    public GameObject bossEye;

    public GameObject laserWarning;

    public GameObject bossBody;

    public GameObject cannonWarning;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
