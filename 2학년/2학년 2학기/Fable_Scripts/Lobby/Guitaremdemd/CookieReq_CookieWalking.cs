using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieReq_CookieWalking : MonoBehaviour
{
    private const float cooldown = 0.4f;
    private float timer = 0f;

    private void Start()
    {
        LobbyManager.Instance.DragEvent += HandleDragEvent;
    }

    private void OnDisable()
    {
        LobbyManager.Instance.DragEvent -= HandleDragEvent;
    }

    private void HandleDragEvent()
    {
        timer = 1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > cooldown)
        {
            timer -= cooldown;

            if (transform.localPosition.x >= 5f)
                transform.localPosition += new Vector3(-10f, 0f, 0f);

            transform.localPosition += new Vector3(0.25f, 0f, 0f);

            int rand = Random.Range(0, 2);

            if (rand == 0)
                transform.localEulerAngles = new Vector3(-25f, -225f, 10f);
            else
                transform.localEulerAngles = new Vector3(-25f, -225f, -10f);
        }
    }
}
