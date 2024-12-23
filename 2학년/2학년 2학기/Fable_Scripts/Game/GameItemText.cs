using System.Collections;
using TMPro;
using UnityEngine;

public class GameItemText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameItemText;

    private void Start()
    {
        gameItemText.gameObject.SetActive(false);
    }

    public void UseGameItem(string text)
    {
        gameItemText.text = text;
        gameItemText.gameObject.SetActive(true);
        StartCoroutine(GameItemTextTime());
    }

    private IEnumerator GameItemTextTime()
    {
        yield return new WaitForSeconds(1f);

        gameItemText.gameObject.SetActive(false);
    }
}