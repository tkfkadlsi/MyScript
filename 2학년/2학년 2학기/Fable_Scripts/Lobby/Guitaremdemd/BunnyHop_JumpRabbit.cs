using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BunnyHop_JumpRabbit : MonoBehaviour
{
    private void Start()
    {
        LobbyManager.Instance.DragEvent += HandleDragEvent;
        JumpCo = Jump();
        StartCoroutine(JumpCo);
    }

    private void OnDisable()
    {
        LobbyManager.Instance.DragEvent -= HandleDragEvent;
    }

    private void HandleDragEvent()
    {
        transform.position = new Vector3(-3.5f, 11f, 0f);
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
        if (JumpCo != null)
        {
            StopCoroutine(JumpCo);
        }
        JumpCo = Jump();
        StartCoroutine(JumpCo);
    }

    private IEnumerator JumpCo;

    private IEnumerator Jump()
    {
        Vector3 endPos = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        transform.DOJump(endPos, 2f, 1, 1.5f);
        yield return new WaitForSeconds(2f);
        transform.eulerAngles += new Vector3(0f, 180f, 0f);
        JumpCo = Jump();
        StartCoroutine(JumpCo);
    }
}
