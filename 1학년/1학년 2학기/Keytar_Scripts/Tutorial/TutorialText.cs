using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TnI
{
    public string Text;
    public Sprite Sprite;
}

public class TutorialText : MonoBehaviour
{
    [SerializeField] private List<TnI> TutorialOpening_Kor;
    [SerializeField] private List<TnI> TutorialOpening_Eng;

    [SerializeField] private List<TnI> keytarTutorial_Kor;
    [SerializeField] private List<TnI> keytarTutorial_Eng;

    [SerializeField] private List<TnI> keyboardTutorial_Kor;
    [SerializeField] private List<TnI> keyboardTutorial_Eng;

    [SerializeField] private List<TnI> TutorialEnding_Kor;
    [SerializeField] private List<TnI> TutorialEnding_Eng;

    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private Image image;

    private void Start()
    {
        if (Information.Instance.Language == "ÇÑ±¹¾î")
        {
            StartCoroutine(Tutorialing_Kor());
        }
        else if(Information.Instance.Language == "English")
        {
            StartCoroutine(Tutorialing_Eng());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator Tutorialing_Kor()
    {
        for(int i = 0; i<TutorialOpening_Kor.Count; i++)
        {
            image.sprite = TutorialOpening_Kor[i].Sprite;
            yield return StartCoroutine(Log(TutorialOpening_Kor[i].Text));
            yield return new WaitForSeconds(1.5f);
        }

        if(Information.Instance.Keymode == "Keytar")
        {
            for(int i = 0; i < keytarTutorial_Kor.Count; i++)
            {
                image.sprite = keytarTutorial_Kor[i].Sprite;
                yield return StartCoroutine(Log(keytarTutorial_Kor[i].Text));
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if(Information.Instance.Keymode == "Keyboard")
        {
            for (int i = 0; i < keyboardTutorial_Kor.Count; i++)
            {
                image.sprite = keyboardTutorial_Kor[i].Sprite;
                yield return StartCoroutine(Log(keyboardTutorial_Kor[i].Text));
                yield return new WaitForSeconds(1.5f);
            }
        }

        for(int i = 0; i < TutorialEnding_Kor.Count; i++)
        {
            image.sprite = TutorialEnding_Kor[i].Sprite;
            yield return StartCoroutine(Log(TutorialEnding_Kor[i].Text));
            yield return new WaitForSeconds(1.5f);
        }

        SceneManager.LoadScene(1);
    }

    private IEnumerator Tutorialing_Eng()
    {
        for (int i = 0; i < TutorialOpening_Eng.Count; i++)
        {
            image.sprite = TutorialOpening_Eng[i].Sprite;
            yield return StartCoroutine(Log(TutorialOpening_Eng[i].Text));
            yield return new WaitForSeconds(1.5f);
        }

        if (Information.Instance.Keymode == "Keytar")
        {
            for (int i = 0; i < keytarTutorial_Eng.Count; i++)
            {
                image.sprite = keytarTutorial_Eng[i].Sprite;
                yield return StartCoroutine(Log(keytarTutorial_Eng[i].Text));
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (Information.Instance.Keymode == "Keyboard")
        {
            for (int i = 0; i < keyboardTutorial_Eng.Count; i++)
            {
                image.sprite = keyboardTutorial_Eng[i].Sprite;
                yield return StartCoroutine(Log(keyboardTutorial_Eng[i].Text));
                yield return new WaitForSeconds(1.5f);
            }
        }

        for (int i = 0; i < TutorialEnding_Eng.Count; i++)
        {
            image.sprite = TutorialEnding_Eng[i].Sprite;
            yield return StartCoroutine(Log(TutorialEnding_Eng[i].Text));
            yield return new WaitForSeconds(1.5f);
        }

        SceneManager.LoadScene(1);
    }

    private IEnumerator Log(string text)
    {
        tutorialText.text = "";

        for(int i = 0; i < text.Length; i++)
        {
            tutorialText.text += text[i];
            if (Input.GetKey(KeyCode.Space))
            {
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
