using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClear : MonoBehaviour
{
    [SerializeField] private BossDie bossDie;
    [SerializeField] private Image panelalpha;
    [SerializeField] private TextMeshProUGUI stringText;
    [SerializeField] private GameObject tank;
    [SerializeField] private SpriteRenderer bossEye;
    [SerializeField] private GameObject panel2;
    [SerializeField] private TextMeshProUGUI nameText2;
    [SerializeField] private TextMeshProUGUI stringText2;
    [SerializeField] private Image image;
    [SerializeField] private GameObject clearText;

    string utext = ""; 

    private IEnumerator Start()
    {
        clearText.SetActive(false);
        stringText.enabled = false;
        panel2.SetActive(false);
        image.enabled = false;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.05f);
            panelalpha.color = new Color(1, 1, 1, panelalpha.color.a - 0.1f);
        }

        bossDie.StartCoroutine("Bossexplosion");
        bossDie.StartCoroutine("BossDown");

        yield return new WaitForSeconds(2.5f);

        panelalpha.color = new Color(0, 0, 0, 1);
        stringText.enabled = true;
        stringText.text = "";
        StartCoroutine("Text");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Text()
    {
        stringText.text = "";
        utext = "우마르 대위가 네오우야의 엑시즈를 파괴한 뒤,\n네오우야에게는 어떤 수단도 남지 않게 되었다.";

        for(int i = 0; i < utext.Length; i++)
        {
            stringText.text += utext[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        stringText.text = "";
        utext = "최후의 발악마저 실패한 네오우야는\n지도층의 와해로 사라지게 되었다.";

        for (int i = 0; i < utext.Length; i++)
        {
            stringText.text += utext[i];
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        stringText.text = "";
        utext = "그리고 전쟁이 끝난 후,\n연방이 재건에 전념하고 있을 때...";

        for (int i = 0; i < utext.Length; i++)
        {
            stringText.text += utext[i];
            yield return new WaitForSeconds(0.025f);
        }
        tank.SetActive(false);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));

        stringText.enabled = false;
        for(int i = 0; i < 10; i++)
            panelalpha.color = new Color(1, 1, 1, panelalpha.color.a - 0.1f);

        yield return new WaitForSeconds(1.5f);
        bossEye.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        bossEye.color = new Color(0.2f, 0.2f, 0.2f);
        yield return new WaitForSeconds(1.0f);
        bossEye.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        bossEye.color = new Color(0.2f, 0.2f, 0.2f);

        yield return new WaitForSeconds(2.0f);
        for(int i = 0; i < 80; i++)
        {
            bossEye.color = new Color(bossEye.color.r + 0.01f, bossEye.color.g + 0.01f, bossEye.color.b + 0.01f);
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(1.5f);

        panel2.SetActive(true);
        image.enabled = true;
        nameText2.text = "???";
        stringText2.text = "";

        string text = "아직 끝나지 않았어.. 연방은.. 사라져야만 해.";

        for(int i = 0; i < text.Length; i++)
        {
            stringText2.text += text[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.5f);
        panelalpha.color = new Color(0, 0, 0, 0);
        for (int i = 0; i < 10; i++)
        {
            panelalpha.color = new Color(0, 0, 0, panelalpha.color.a + 0.1f);
            yield return new WaitForSeconds(0.05f);
        }

        panel2.SetActive(false);
        image.enabled = false;

        yield return new WaitForSeconds(1.5f);

        clearText.SetActive(true);
    }
}
