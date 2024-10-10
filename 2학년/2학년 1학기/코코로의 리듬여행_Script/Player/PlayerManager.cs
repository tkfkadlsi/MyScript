using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerMove PlayerMove;
    public PlayerInput PlayerInput;

    private AudioSource BGMSource;

    private void Awake()
    {
        Instance = this;
        if (!TryGetComponent(out PlayerMove))
        {
            PlayerMove = gameObject.AddComponent<PlayerMove>();
        }
        if (!TryGetComponent(out PlayerInput))
        {
            PlayerInput = gameObject.AddComponent<PlayerInput>();
        }

        BGMSource = GameObject.Find("Sound").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GamePoint"))
        {
            Information.Instance.IsGamePoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GamePoint"))
        {
            Information.Instance.IsGamePoint = false;
            UIManager.Instance.MenuFuncs.CloseSongUI();
        }
    }
}
