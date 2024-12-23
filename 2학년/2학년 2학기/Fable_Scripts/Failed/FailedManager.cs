using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailedManager : MonoBehaviour
{
    [SerializeField] private Image Image;
    [SerializeField] private Sprite Sprite;

    private void Start()
    {
        Image.sprite = Sprite;
    }

    public void GoLobbyScene()
    {
        Information.Instance.SetUpItemfalse();
        SceneManager.LoadScene("Lobby");
    }

    public void GoRestart()
    {
        SceneManager.LoadScene("RhythmGame");
    }
}
