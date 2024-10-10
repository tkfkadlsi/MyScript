using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Vector2 mincamera;
    [SerializeField] private Vector2 maxcamera;

    Transform player;
    Vector3 direction;
    float moveSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.tank.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        direction = new Vector3(player.position.x - transform.position.x, (player.position.y - transform.position.y) + 2, -10);

        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        limit();
    }

    void limit()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, mincamera.x, maxcamera.x), Mathf.Clamp(transform.position.y, mincamera.y, maxcamera.y), -10);
    }

    public void Shake()
    {
        transform.DOShakePosition(0.1f, 0.125f, 1);
    }
}
