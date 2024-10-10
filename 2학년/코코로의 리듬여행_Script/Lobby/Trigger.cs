using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private string msg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.SetMsg(msg);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.SetMsg("");
        }
    }
}
