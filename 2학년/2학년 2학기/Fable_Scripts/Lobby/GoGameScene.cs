using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoGameScene : MonoBehaviour
{
    [SerializeField] private Image blindImage;

    private void Awake()
    {
        blindImage.color = Color.clear;
        blindImage.gameObject.SetActive(false);
    }

    public IEnumerator GameScene()
    {
        LobbyManager.Instance.PlaySFX(0);
        blindImage.gameObject.SetActive(true);
        blindImage.DOColor(Color.white, 0.5f);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("RhythmGame");
    }
}
