using UnityEngine;

public class CamRig : MonoBehaviour
{
    private Transform trm;
    private Transform playerTrm;
    private float sensitive = 120f;

    private Vector3 plusVector = Vector3.zero;

    private void Start()
    {
        trm = GetComponent<Transform>();
        playerTrm = PlayerManager.Instance.GetComponent<Transform>();
    }

    private void Update()
    {
        trm.position = playerTrm.position;
        Quaternion q = playerTrm.rotation;
        q.eulerAngles += plusVector;

        trm.rotation = q;
        CameraMove();
    }

    private void CameraMove()
    {
        float y = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        plusVector += new Vector3(x, y) * sensitive * Time.deltaTime;

        plusVector = new Vector3(Mathf.Clamp(plusVector.x, -30f, 30f), plusVector.y);
    }

    public void CamLock()
    {
        plusVector = Vector3.zero;
    }
}
