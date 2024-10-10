using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private EnemyCar enemyCar;

    private void Awake()
    {
        enemyCar = FindObjectOfType<EnemyCar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyCar.Touch();
            Destroy(gameObject);
        }
    }
}
