using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PrologueString : MonoBehaviour
{

    TextMeshProUGUI prt;
    [SerializeField] private GameObject pr;
    [SerializeField] private GameObject StoryText;
    TextMeshProUGUI Storytelling;
    [SerializeField] private GameObject NameText;
    TextMeshProUGUI Nametelling;
    public GameObject che;
    [SerializeField] private GameObject bi;
    public int speed=3;
    string pry;
    string sty;
    string nm;

    private void Awake()
    {
        che.SetActive(false);
    }
    void Start()
    {
        prt = pr.GetComponent<TextMeshProUGUI>();
        Storytelling = StoryText.GetComponent<TextMeshProUGUI>();
        Nametelling = NameText.GetComponent<TextMeshProUGUI>();

        StartCoroutine("PR");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator PR()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "인류가 대지를 떠나\n 우주 이민을 시작한지 어언 수십년";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "허나 우주로 이주한 인류,\n 스페이스노이드들에 대한 계속되는\n차별과 억압 속 에서";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "스페이스노이드들은\n 네오우야 공국을 선포하기에 이른다.";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "네오우야는 이후\n자신들의 독립을 주장했고,\n결국 지구연방과의 전쟁이 시작된다.";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "전쟁은 2년간 계속되며\n열악한 환경에 있던\n네오우야의 패색은 짙어져만 갔다.";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "그리고\n패배가 눈앞인 네오우야는\n 최후의 발악을 이어간다.";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        prt.text = "";
        pry = "전쟁 발발 2년 5개월 경과";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.7f);

        //prt.text = "";
        pry = "\n\n-지구 공역 근방";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }

        
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        //yield return new WaitForSeconds(2);
        bi.SetActive(false);
        pr.SetActive(false);
        StartCoroutine("Text");
    }
    IEnumerator Text()
    {
        nm = "지구 공역군 군단장";
        sty = "현 상황은 어떻지?";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "연방군 병사";
        sty = "현재 제 4 우주함대가 적의 진군 지점으로 적 병력의 3배에 해당하는 함대를 이끌고 오고 있습니다.";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }



        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "지구 공역군 군단장";
        sty = "이것으로 모두 끝이군...";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "연방군 병사";
        sty = "....";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(0.4f);
        nm = "연방군 병사";
        sty = "..? 군단장님? 저..";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "지구 공역군 군단장";
        sty = "무슨 일인가?";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }



        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "연방군 병사";
        sty = "제 4함대가 진군한 곳이 작전구역에서 0.4 AU정도 밖이라고 합니다.";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nm = "지구 공역군 군단장";
        sty = "뭐? 작전 사항이 분명 모두 전달 되었을텐데..! 스파이인가!";
        Storytelling.text = "";
        Nametelling.text = "";
        for (int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        Storytelling.text = "";
        Nametelling.text = "";
        bi.SetActive(true);
        pr.SetActive(true);
       
        prt.text = "";
        pry = "결국 최후의 전투가 될 뻔했던 작전은 네오우야의 승리로 끝났고\n네오우야의 최종병기, 엑시즈가\n지구로 투하되었다.";

        for (int i = 0; i < pry.Length; i++)
        {
            prt.text += pry[i];
            yield return new WaitForSeconds(0.05f);
        }


        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        bi.SetActive(false);
        pr.SetActive(false);


        che.SetActive(true);
        while(che.transform.position.x >5.02)
        {
            yield return new WaitForSeconds(0.002f);
           che. transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        Storytelling.text = "";
        Nametelling.text = "";

        nm = "체르노빌";
        sty = "반갑네 우마르 대위";
        for(int i = 0; i < nm.Length; i++)
        {
            Nametelling.text += nm[i];
            yield return new WaitForSeconds(0.05f);
        }
        for(int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }
        //대사2
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        Storytelling.text = "";
        nm = "체르노빌";
        sty = "이미 알고 있겠다만, 연방이 엑시즈 방어 작전에서 패하였다네.";
  
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }
        //3
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        Storytelling.text = "";
        nm = "체르노빌";
        sty = "현재 엑시즈의 투하 예정지는 모두 계산 되었으니, 당장 출격하여 엑시즈를 조금이나마 저지해주게나";
        
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }
        //4
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        Storytelling.text = "";
        
        nm = "체르노빌";
        sty = "이후 남은 공군이 지원을 갈걸세, 건투를 비네.";
       
        for (int i = 0; i < sty.Length; i++)
        {
            Storytelling.text += sty[i];
            yield return new WaitForSeconds(0.05f);
        }
        //씬 전환
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        SceneManager.LoadScene(2);
    }
}
