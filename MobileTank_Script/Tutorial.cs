using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    TextMeshProUGUI tutorialString;
    TankMove tankMove;

    string str = "";

    private void Awake()
    {
        tutorialString = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        tankMove = GameManager.instance.tankMove;
        tankMove.enabled = false;
        StartCoroutine("TutorialProgress");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            SceneManager.LoadScene(3);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator TutorialProgress()
    {
        str = "기본적인 튜토리얼을 시작합니다. 스킵하시려면 p를 눌러주세요.";
        tutorialString.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }

        yield return new WaitForSeconds(1f);

        str = "튜토리얼의 내용을 따라해야 다음으로 넘어갑니다.";
        tutorialString.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }

        yield return new WaitForSeconds(1f);

        str = "W와 S를 사용해 앞뒤로 조작할 수 있습니다.";
        tutorialString.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.W));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.S));

        yield return new WaitForSeconds(1f);
        tankMove.enabled = false;

        str = "A와 D를 사용해 방향을 전환 할 수 있습니다.";
        tutorialString.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.D));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));

        yield return new WaitForSeconds(1f);
        tankMove.enabled = false;

        str = "좌우 화살표를 이용해 포신의 방향을 전환 할 수 있습니다.";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));

        yield return new WaitForSeconds(1f);
        tankMove.enabled = false;

        str = "좌shift를 눌러 대시를 사용할 수 있습니다.";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftShift));

        yield return new WaitForSeconds(1f);
        tankMove.enabled = false;

        str = "F를 눌러 대포를 발사할 수 있습니다.";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));

        yield return new WaitForSeconds(1f);
        tankMove.enabled = false;

        str = "스페이스를 키다운하여 강력한 공격을 준비합니다.";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }
        tankMove.enabled = true;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        yield return new WaitForSeconds(0.5f);

        str = "스페이스를 떼 강력한 공격을 발사합니다.";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }

        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space));

        str = "잘하셨습니다. 기본적인 튜토리얼을 마치겠습니다";
        tutorialString.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialString.text += str[i];
            yield return new WaitForSeconds(0.0625f);
        }

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}