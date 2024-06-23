using UnityEngine;

public class LunarAirship : MonoBehaviour
{
    private float num = 0f;
    private Vector3 originPos;

    private void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        num += Time.deltaTime;
        transform.position = originPos + new Vector3(0f, (0.25f * Mathf.Cos(num)) - 0.5f, 0f);
    }
}
