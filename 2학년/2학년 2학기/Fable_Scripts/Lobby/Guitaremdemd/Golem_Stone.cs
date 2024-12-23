using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Stone : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < 22.5f)
            Destroy(gameObject);
    }
}
