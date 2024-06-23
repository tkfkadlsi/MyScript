using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    private Rigidbody rigid;

    private bool isJumping = false;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        rigid = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 dir = transform.forward;
            transform.position += dir * moveSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 dir = transform.forward;
            dir = new Vector3(-dir.z, 0, dir.x);
            transform.position += dir * moveSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 dir = transform.forward;
            dir = new Vector3(dir.z, 0, -dir.x);
            transform.position += dir * moveSpeed * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 dir = transform.forward;
            dir = new Vector3(-dir.x, 0, -dir.z);
            transform.position += dir * moveSpeed * Time.fixedDeltaTime;
        }
    }

    private void Jump()
    {
        if (isJumping) return;

        isJumping = true;
        rigid.velocity += new Vector3(0, jumpPower, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
}
