using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BossManager : MonoBehaviour
{
    BossLeftArm leftArm;
    BossPaternManage paternManage;
    GameObject armClearSign;
    GameObject bossLArm;
    GameObject bossHead;
    GameObject bossEye;
    SpriteRenderer eyeRenderer;
    SpriteRenderer bossHeadRenderer;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        armClearSign = GameManager.instance.armClearSign;
        leftArm = GameManager.instance.bossLeftArm;
        paternManage = GameManager.instance.bossPaternManage;
        bossLArm = GameManager.instance.bossLArm;
        bossHead = GameManager.instance.bosshead;
        bossEye = GameManager.instance.bossEye;
        eyeRenderer = bossEye.GetComponent<SpriteRenderer>();
        bossHeadRenderer = bossHead.GetComponent<SpriteRenderer>();
        spriteRenderer = bossLArm.GetComponent<SpriteRenderer>();
        armClearSign.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MoveForPunch()
    {
        yield return new WaitForSeconds(1);
        eyeRenderer.sortingLayerName = "BossArm";
        bossHeadRenderer.sortingLayerName = "BossArm";
        spriteRenderer.sortingLayerName = "BossArm";
        transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1), 0.5f);
        transform.DOScale(new Vector3(1.5f, 1.5f), 0.5f).OnComplete(()=>
        {
            transform.DOMove(new Vector3(Random.Range(-4.25f, 12.25f), transform.position.y), 0.75f).OnComplete(() =>
            {
                leftArm.StartCoroutine("Punch");
            });
        });
        yield return new WaitForSeconds(3f);
        transform.DOMove(new Vector3(transform.position.x + 4, transform.position.y), 0.2f);
    }

    public void MoveForPunch2()
    {
        armClearSign.SetActive(true);
        transform.DOMove(new Vector3(-15, transform.position.y - 1), 2.5f);
        transform.DOScale(new Vector3(1.5f, 1.5f), 2.5f).OnComplete(() =>
        {
            leftArm.StartCoroutine("Punch2");
        });
    }

    public IEnumerator Punch2Move()
    {
        armClearSign.SetActive(false);
        transform.DOMove(new Vector3(25, transform.position.y), 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(2.0f);

        transform.DOMove(new Vector3(0, 1), 2.5f);
        transform.DOScale(new Vector3(1, 1), 2.5f).OnComplete(()=>
        {
            leftArm.Punch2End();
            paternManage.BPaternEndCall();
        });
        
    }

    public void PunchEnd()
    {
        transform.DOMove(new Vector3(0, 1), 1.5f);
        transform.DOScale(new Vector3(1, 1), 1.5f).OnComplete(() =>
        {
            spriteRenderer.sortingLayerName = "Boss";
            bossHeadRenderer.sortingLayerName = "Boss";
            eyeRenderer.sortingLayerName = "Boss";
            paternManage.BPaternEndCall();
        });
    }
}
