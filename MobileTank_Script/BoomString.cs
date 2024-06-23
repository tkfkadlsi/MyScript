using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoomString : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boomstring;
    PhaseManager phaseManager;
    string text = "";
    void Start()
    {
        phaseManager = GameManager.instance.phaseManager;
        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public IEnumerator CallBoom()
    {
        yield return new WaitForSeconds(1.0f);
        text = "발칸포 무력화 확인.";
        boomstring.text = "";
        for(int i = 0; i < text.Length; i++)
        {
            boomstring.text += text[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1.0f);
        text = "폭격 지원이 있을 예정이다.";
        boomstring.text = "";
        for(int i = 0; i < text.Length; i++)
        {
            boomstring.text += text[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1.0f);
        phaseManager.FinishBoomText();
    }

    public IEnumerator FailBoom()
    {
        yield return new WaitForSeconds(1.0f);
        text = "폭격 지원 진행 중...";
        boomstring.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            boomstring.text += text[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1.0f);
        text = "공격당한다! 지원 취소! 후ㅌ...ㅗ...ㅣ....!";
        boomstring.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            boomstring.text += text[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
