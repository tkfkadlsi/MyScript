using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Car : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxAngle;

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI DRText;

    private AudioSource audioSource;

    private float currentSpeed;
    private float currentAngle;

    float Pitch = 0.15f;

    public bool start = false;

    private KeyCode forword = KeyCode.UpArrow;
    private KeyCode back = KeyCode.DownArrow;
    private KeyCode left = KeyCode.LeftArrow;
    private KeyCode right = KeyCode.RightArrow;
    private KeyCode repair = KeyCode.R;

    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.pitch = 0;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        SetMeter();
        Pitch = currentSpeed / 30;
        audioSource.pitch = Pitch;
        if (!start) return;

        if (Input.GetKeyDown(repair)) Repair();
        if (Input.GetKey(forword)) SpeedUp();
        else if (Input.GetKey(back)) SpeedDown();
        else SpeedZero();


        if (Input.GetKey(right)) TurnRight();
        else if (Input.GetKey(left)) TurnLeft();
        else TurnZero();


        if (currentSpeed > 0)
            transform.Rotate(new Vector3(0, currentAngle, 0) * Time.deltaTime);
        else if (currentSpeed < 0)
            transform.Rotate(new Vector3(0, -currentAngle, 0) * Time.deltaTime);
    }

    private void SetMeter()
    {
        speedText.text = Mathf.Abs((int)(currentSpeed * 5)).ToString() + "km/h";

        if (currentSpeed >= 0)
        {
            DRText.text = "D";
        }
        else
        {
            DRText.text = "R";
        }
    }

    private void SpeedUp()
    {
        currentSpeed += acceleration * Time.deltaTime;
        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
    }
    private void SpeedDown()
    {
        
        currentSpeed -= acceleration * Time.deltaTime;
        if (currentSpeed < minSpeed) currentSpeed = minSpeed;
    }
    private void SpeedZero()
    {
        if (currentSpeed > 0.1f) currentSpeed -= 5 * Time.deltaTime;
        else if (currentSpeed < 0.1f) currentSpeed += 2 * Time.deltaTime;
        else currentSpeed = 0;
    }

    private void TurnRight()
    {
        if (Mathf.Abs(currentSpeed) < 1) return;
        else if (Mathf.Abs(currentSpeed) < 6)
        {
            maxAngle = 10;
        }
        else if (Mathf.Abs(currentSpeed) < 18)
        {
            maxAngle = 30;
            currentSpeed -= (acceleration - 2) * Time.deltaTime;
        }
        else
        {
            maxAngle = 60;
            currentSpeed -= (acceleration + 2) * Time.deltaTime;
        }
        currentAngle += 90 * Time.deltaTime;

        if (currentAngle > maxAngle) currentAngle -= 90 * Time.deltaTime;
    }
    private void TurnLeft()
    {
        if (Mathf.Abs(currentSpeed) < 1) return;
        else if (Mathf.Abs(currentSpeed) < 6)
        {
            maxAngle = 10;
        }
        else if (Mathf.Abs(currentSpeed) < 18)
        {
            maxAngle = 30;
            currentSpeed -= (acceleration - 2) * Time.deltaTime;
        }
        else
        {
            maxAngle = 60;
            currentSpeed -= (acceleration + 2) * Time.deltaTime;
        }
        currentAngle -= 90 * Time.deltaTime;

        if (currentAngle < -maxAngle) currentAngle += 90 * Time.deltaTime;
    }
    private void TurnZero()
    {
        if (currentAngle > 0) currentAngle -= 60 * Time.deltaTime;
        else if (currentAngle < 0) currentAngle += 60 * Time.deltaTime;
    }

    private void Repair()
    {
        transform.rotation = Quaternion.EulerAngles(0, -90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
            currentSpeed = currentSpeed / 10;
    }
}
