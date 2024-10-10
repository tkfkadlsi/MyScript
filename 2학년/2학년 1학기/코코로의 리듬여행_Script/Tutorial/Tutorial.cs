using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Image displayImage;
    [SerializeField] private List<Sprite> tutorialImages = new List<Sprite>();

    [SerializeField] private GameObject exitButton;

    private int N = 0;

    private void Start()
    {
        exitButton.SetActive(false);
        displayImage.sprite = tutorialImages[N];
        UINavigation.ChangeFocus(GetComponent<UINavigation>());
    }

    public void NextImage()
    {
        N++;
        N = Mathf.Clamp(N, 0, tutorialImages.Count - 1);

        displayImage.sprite = tutorialImages[N];
        if(N == tutorialImages.Count - 1)
        {
            exitButton.SetActive(true);
        }
        else
        {
            exitButton.SetActive(false);
        }
    }

    public void BeforeImage()
    {
        N--;
        N = Mathf.Clamp(N, 0, tutorialImages.Count - 1);

        displayImage.sprite = tutorialImages[N];
        exitButton.SetActive(false);
    }

    public void ExitTutorial()
    {
        TitleUIManager.Instance.TutorialFinish();
        SceneManager.LoadScene("1_Selection");
    }
}
