using UnityEngine;

public class ButterFly : MonoBehaviour
{
    private float speed = 30f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        transform.eulerAngles += new Vector3(0, 15 * Time.deltaTime, 0);
    }
}
