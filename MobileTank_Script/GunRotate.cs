using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float gunRotateSpeed = 180.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, Time.deltaTime * gunRotateSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, Time.deltaTime * -gunRotateSpeed);
        }
    }
}
