using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JudgeText : MonoBehaviour
{
    TextMeshProUGUI judgeText;
    [SerializeField] private TextMeshProUGUI ComboText;
    [SerializeField] private Slider playerHP;

    int combo;
    public int highCombo;

    private void Awake()
    {
        judgeText = GetComponent<TextMeshProUGUI>();
        critical = nice = miss = defense = safe = break_ = combo = highCombo = 0;
        ComboText.text = "";
    }

    float seeTime;

    private void Update()
    {
        seeTime -= Time.deltaTime;

        if(seeTime <= 0)
        {
            if(judgeText.text != "")
                judgeText.text = "";
        }
    }

    public void Critical()
    {
        seeTime = 0.15f;
        judgeText.color = new Color(1, 0, 0.75f, 1);
        judgeText.text = "Critical";
        critical++;
        ComboUp();
    }

    public void Nice()
    {
        seeTime = 0.15f;
        judgeText.color = new Color(1, 0.5f, 0, 1);
        judgeText.text = "Nice";
        nice++;
        ComboUp();
    }

    public void Miss()
    {
        seeTime = 0.15f;
        judgeText.color = new Color(0.65f, 0.65f, 0.65f, 1);
        judgeText.text = "Miss";
        miss++;
        ComboZero();
    }

    public void Defense()
    {
        playerHP.value += 1;
        seeTime = 0.15f;
        judgeText.color = new Color(0, 1, 1, 1);
        judgeText.text = "Defense";
        defense++;
        ComboUp();
    }

    public void Safe()
    {
        seeTime = 0.15f;
        judgeText.color = new Color(0, 0.5f, 1, 1);
        judgeText.text = "Safe";
        safe++;
        ComboUp();
    }

    public void Break()
    {
        playerHP.value -= 2;
        seeTime = 0.15f;
        judgeText.color = new Color(1, 0, 0, 1);
        judgeText.text = "Break";
        break_++;
        ComboZero();
    }

    void ComboUp()
    {
        combo++;
        if (combo > highCombo)
            highCombo = combo;
        ComboText.text = combo.ToString();
    }

    void ComboZero()
    {
        combo = 0;
        ComboText.text = "";
    }

    public int critical;
    public int nice;
    public int miss;
    public int defense;
    public int safe;
    public int break_;
}
