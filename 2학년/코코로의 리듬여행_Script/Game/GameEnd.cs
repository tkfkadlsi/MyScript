using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private Image maskImage;
    [SerializeField] private TextMeshProUGUI endText;

    private bool isDie = false;

    public void End()
    {
        if (isDie) return;
        GameManager.Instance.BlockUIControl();

        Result result = Information.Instance.Result;
        blackScreen.SetActive(true);

        if (result.MissCount == 0 && result.BadCount == 0 && result.GoodCount == 0 && result.GreatCount == 0)
        {
            endText.text = "All Perfect!!";
            endText.color = Color.cyan;
        }
        else if (result.MissCount == 0)
        {
            endText.text = "Full Combo!";
            endText.color = Color.cyan;
        }
        else
        {
            endText.text = "Game Clear";
            endText.color = Color.white;
        }

        ResultScene(true);
    }

    public void Die()
    {
        if (isDie) return;
        isDie = true;

        GameManager.Instance.BlockUIControl();
        GameManager.Instance.GamePlayerInput.isInputOK = false;
        blackScreen.SetActive(true);

        endText.text = "Failed..";
        endText.color = Color.red;

        ResultScene(false);
    }

    private void ResultScene(bool isClear)
    {
        Sequence sq = DOTween.Sequence();

        sq.Append(maskImage.rectTransform.DOSizeDelta(new Vector2(1920, 1080), 3f));
        sq.OnComplete(() =>
        {
            if (isClear)
            {
                SceneManager.LoadScene("3_Result");
            }
            else
            {
                SceneManager.LoadScene("1_Selection");
            }
        });
    }
}
