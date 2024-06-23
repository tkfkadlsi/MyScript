using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [SerializeField] private AudioSource backGroundBgm1;
    [SerializeField] private AudioSource playerBullet;
    [SerializeField] private AudioSource balKanFire;
    [SerializeField] private AudioSource missileExplode;
    [SerializeField] private AudioSource playerLaser;
    [SerializeField] private AudioSource playerLaserStop;
    [SerializeField] private AudioSource bossLaserWarning;
    [SerializeField] private AudioSource missileLaunch;
    [SerializeField] private AudioSource cannonLaunch;
    [SerializeField] private AudioClip balKanClip;
    [SerializeField] private AudioClip missileCilp;
    [SerializeField] private AudioClip missileLaunchClip;
    Launch launch;

    private void Start()
    {
        launch = GameManager.instance.launch;
        backGroundBgm1.Play();
    }

    public IEnumerator BulletFire()
    {
        playerBullet.Play();
        yield return new WaitForSeconds(0.125f);
        launch.Fire();
    }

    public void BalKanPo()
    {
        balKanFire.PlayOneShot(balKanClip);
    }

    public void Missile()
    {
        missileExplode.PlayOneShot(missileCilp);
    }

    public void playerLaserCharge()
    {
        playerLaser.Play();
    }

    public void playerLaserShoot()
    {
        playerLaser.Stop();
        playerLaserStop.Play();
    }

    public void BossLaserWarning()
    {
        bossLaserWarning.Play();
    }

    public void MissileLaunch()
    {
        missileLaunch.PlayOneShot(missileLaunchClip);
    }

    public void CannonLaunch()
    {
        cannonLaunch.Play();
    }
}
