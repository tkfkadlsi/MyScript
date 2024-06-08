using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiddenPlayerController : MonoBehaviour
{
    Transform trm;
    AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip audioClip;

    public string targetTag = "Note";

    private GameObject closestObject;

    [SerializeField] private Transform[] judgeTrm;
    [SerializeField] private TextMeshProUGUI[] judgeTexts;

    float delTime = 0;


    KeyCode right, left, up, down;

    private void Awake()
    {
        trm = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        right = KeyInfo.instance._right;
        left = KeyInfo.instance._left;
        up = KeyInfo.instance._up;
        down = KeyInfo.instance._down;

        if (KeyInfo.instance.playerColor == null)
            spriteRenderer.color = new Color(1, 0, 5f, 0);
        else
            spriteRenderer.color = KeyInfo.instance.playerColor;
    }

    private void Update()
    {
        if (HiddenSongManager.instance.isPause == false)
            Press();

        DelText();
        delTime -= Time.deltaTime;
    }

    void DelText()
    {
        if (delTime < 0)
        {
            judgeTexts[0].enabled = false;
            judgeTexts[1].enabled = false;
            judgeTexts[2].enabled = false;
            judgeTexts[3].enabled = false;
        }
    }

    void Press()
    {
        if (Input.GetKeyDown(left))
        {
            LeftPress();
            KeySound();
            GameObject laser = HiddenSongManager.instance.LaserGet();
            laser.transform.rotation = Quaternion.Euler(0, 0, -90);
            laser.transform.position = new Vector3(trm.position.x - 3, trm.position.y);
        }

        if (Input.GetKeyDown(right))
        {
            RightPress();
            KeySound();
            GameObject laser = HiddenSongManager.instance.LaserGet();
            laser.transform.rotation = Quaternion.Euler(0, 0, 90);
            laser.transform.position = new Vector3(trm.position.x + 3, trm.position.y);
        }

        if (Input.GetKeyDown(up))
        {
            TopPress();
            KeySound();
            GameObject laser = HiddenSongManager.instance.LaserGet();
            laser.transform.rotation = Quaternion.Euler(0, 0, 0);
            laser.transform.position = new Vector3(trm.position.x, trm.position.y + 3);
        }

        if (Input.GetKeyDown(down))
        {
            BottomPress();
            KeySound();
            GameObject laser = HiddenSongManager.instance.LaserGet();
            laser.transform.rotation = Quaternion.Euler(0, 0, 180);
            laser.transform.position = new Vector3(trm.position.x, trm.position.y - 3);
        }
    }

    void TopPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            float distance = Vector3.Distance(judgeTrm[0].position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            float distance = Vector3.Distance(judgeTrm[0].position, closestObject.transform.position);

            if (distance <= 0.6f * Time.timeScale) //40ms = 0.6
            {
                Efc(closestObject);
                Perfect();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 0.9f * Time.timeScale) //60ms = 0.9
            {
                Efc(closestObject);
                Good();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 1.5f * Time.timeScale) //100ms = 1.5
            {
                Efc(closestObject);
                Bad();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 3f * Time.timeScale) //200ms = miss
            {
                Miss();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboReset();
            }
        }
    }

    void BottomPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            float distance = Vector3.Distance(judgeTrm[1].position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            float distance = Vector3.Distance(judgeTrm[1].position, closestObject.transform.position);

            if (distance <= 0.6f * Time.timeScale) //40ms = 0.6
            {
                Efc(closestObject);
                Perfect();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 0.9f * Time.timeScale) //60ms = 0.9
            {
                Efc(closestObject);
                Good();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 1.5f * Time.timeScale) //100ms = 1.5
            {
                Efc(closestObject);
                Bad();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 3f * Time.timeScale) //200ms = miss
            {
                Miss();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboReset();
            }
        }
    }

    void LeftPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            float distance = Vector3.Distance(judgeTrm[2].position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            float distance = Vector3.Distance(judgeTrm[2].position, closestObject.transform.position);

            if (distance <= 0.6f * Time.timeScale) //40ms = 0.6
            {
                Efc(closestObject);
                Perfect();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 0.9f * Time.timeScale) //60ms = 0.9
            {
                Efc(closestObject);
                Good();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 1.5f * Time.timeScale) //100ms = 1.5
            {
                Efc(closestObject);
                Bad();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 3f * Time.timeScale) //200ms = miss
            {
                Miss();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboReset();
            }
        }
    }


    void RightPress()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);

        float closestDistance = Mathf.Infinity;
        closestObject = null;

        foreach (GameObject target in targetObjects)
        {
            float distance = Vector3.Distance(judgeTrm[3].position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = target;
            }
        }

        if (closestObject != null)
        {
            float distance = Vector3.Distance(judgeTrm[3].position, closestObject.transform.position);

            if (distance <= 0.6f * Time.timeScale) //40ms = 0.6
            {
                Efc(closestObject);
                Perfect();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 0.9f * Time.timeScale) //60ms = 0.6
            {
                Efc(closestObject);
                Good();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 1.5f * Time.timeScale) //100ms = 1
            {
                Efc(closestObject);
                Bad();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboUp();
            }
            else if (distance <= 3f * Time.timeScale) //200ms = miss
            {
                Miss();
                HiddenSongManager.instance.noteDel(closestObject);
                ComboReset();
            }
        }
    }


    public void Perfect()
    {
        audioSource.PlayOneShot(audioClip);
        HiddenSongManager.instance.Score += 668;
        delTime = 0.25f;
        HiddenSongManager.instance.perfect++;
        judgeTexts[0].enabled = true;
        judgeTexts[1].enabled = false;
        judgeTexts[2].enabled = false;
        judgeTexts[3].enabled = false;
    }

    void Good()
    {
        HiddenSongManager.instance.Score += 441;
        delTime = 0.25f;
        HiddenSongManager.instance.good++;
        judgeTexts[0].enabled = false;
        judgeTexts[1].enabled = true;
        judgeTexts[2].enabled = false;
        judgeTexts[3].enabled = false;
    }

    void Bad()
    {
        HiddenSongManager.instance.Score += 220;
        delTime = 0.25f;
        HiddenSongManager.instance.bad++;
        judgeTexts[0].enabled = false;
        judgeTexts[1].enabled = false;
        judgeTexts[2].enabled = true;
        judgeTexts[3].enabled = false;
    }

    public void Miss()
    {
        delTime = 0.25f;
        HiddenSongManager.instance.miss++;
        judgeTexts[0].enabled = false;
        judgeTexts[1].enabled = false;
        judgeTexts[2].enabled = false;
        judgeTexts[3].enabled = true;
    }

    void ComboUp()
    {
        HiddenSongManager.instance.Combo++;
    }

    void ComboReset()
    {
        HiddenSongManager.instance.Combo = 0;
    }

    void KeySound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    IEnumerator EfcDel(GameObject delefc)
    {
        yield return new WaitForSeconds(1.5f);
        HiddenSongManager.instance.EfcDel(delefc);
    }

    void Efc(GameObject note)
    {
        GameObject efc = HiddenSongManager.instance.EfcGet();
        efc.transform.position = note.transform.position;
        StartCoroutine("EfcDel", efc);
    }
    //ÀÌÆåÆ® ³Ö±â
}
