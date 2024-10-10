using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;

    public void GameStart()
    {
        StartCoroutine(Text1());
    }

    IEnumerator Text1()
    {
        string str = "리듬 히어로에 오신 것을 환영합니다!";
        tutorialText.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text2());
    }

    IEnumerator Text2()
    {
        string str = "키 설정을 하지 않았을 때의 기본 키는 D, F, J, K입니다.";
        tutorialText.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text3());
    }

    IEnumerator Text3()
    {
        string str = "왼쪽의 빨간색은 공격 기어 입니다.";
        tutorialText.text = "";
        for(int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text4());
    }

    IEnumerator Text4()
    {
        string str = "Critical, Nice, Miss가 있으며 정확도에 따라 적에게 데미지를 넣을 수 있습니다.";
        tutorialText.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text5());
    }

    IEnumerator Text5()
    {
        string str = "오른쪽의 파란색은 방어 기어입니다.";
        tutorialText.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text6());
    }

    IEnumerator Text6()
    {
        string str = "Defense, Safe, Break가 있으며 정확도에 따라 데미지를 방어합니다.";
        tutorialText.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(Text7());
    }

    IEnumerator Text7()
    {
        string str = "실력을 향상시켜 꼭 보스를 처치해주세요! 부탁드립니다!";
        tutorialText.text = "";
        for (int i = 0; i < str.Length; i++)
        {
            tutorialText.text += str[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1);
    }
}
