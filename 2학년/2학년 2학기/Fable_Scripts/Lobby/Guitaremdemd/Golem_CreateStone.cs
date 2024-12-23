using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Golem_CreateStone : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;

    private const float cooldown = 1.2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > cooldown)
        {
            timer -= cooldown;

            GameObject obj = Instantiate(stonePrefab);
            obj.AddComponent<Golem_Stone>();
            obj.transform.position = transform.position + new Vector3(
                Random.Range(-2.0f, 2.0f),
                3f,
                -1);

            obj.transform.eulerAngles = new Vector3(
                Random.Range(-180f, 180f),
                Random.Range(-180f, 180f),
                Random.Range(-180f, 180f));

            obj.AddComponent<Rigidbody>();
        }
    }
}