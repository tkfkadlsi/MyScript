using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;

    private float xRotate = 0.0f;

    private Camera mainCam;

    private void Awake()
    {
        mainCam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        MouseRotation();
    }

    void MouseRotation()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * turnSpeed;
        float xRotateSize = Input.GetAxis("Mouse Y") * turnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;
        float xRotate = mainCam.transform.localEulerAngles.x - xRotateSize;

        transform.eulerAngles = new Vector3(0, yRotate, 0);
        mainCam.transform.localEulerAngles = new Vector3(xRotate, 0, 0);
    }
}
