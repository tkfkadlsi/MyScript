using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
    Color attackNoteColor;
    Color defendNoteColor;

    [SerializeField] private Image attackColorImage;
    [SerializeField] private Image defendColorImage;

    [SerializeField] private Slider slider_att_r;
    [SerializeField] private Slider slider_att_g;
    [SerializeField] private Slider slider_att_b;

    [SerializeField] private Slider slider_def_r;
    [SerializeField] private Slider slider_def_g;
    [SerializeField] private Slider slider_def_b;

    public float attack_R, attack_G, attack_B;
    public  float defend_R, defend_G, defend_B;

    private void Start()
    {
        attack_R = PlayerPrefs.GetFloat("attackR");
        attack_G = PlayerPrefs.GetFloat("attackG");
        attack_B = PlayerPrefs.GetFloat("attackB");

        defend_R = PlayerPrefs.GetFloat("defendR");
        defend_G = PlayerPrefs.GetFloat("defendG");
        defend_B = PlayerPrefs.GetFloat("defendB");

        slider_att_r.value = attack_R;
        slider_att_g.value = attack_G;
        slider_att_b.value = attack_B;

        slider_def_r.value = defend_R;
        slider_def_g.value = defend_G;
        slider_def_b.value = defend_B;

        AttackColorChange();
        DefendColorChange();
    }


    void AttackColorChange()
    {
        attackNoteColor = new Color(attack_R, attack_G, attack_B);
        attackColorImage.color = attackNoteColor;
        Information.instance._attackNoteColor = attackNoteColor;
    }


    void DefendColorChange()
    {
        defendNoteColor = new Color(defend_R, defend_G, defend_B);
        defendColorImage.color = defendNoteColor;
        Information.instance._defendNoteColor = defendNoteColor;
    }


    public void ChangeAttackR()
    {
        attack_R = slider_att_r.value;
        PlayerPrefs.SetFloat("attackR", attack_R);
        AttackColorChange();
    }


    public void ChangeAttackG()
    {
        attack_G = slider_att_g.value;
        PlayerPrefs.SetFloat("attackG", attack_G);
        AttackColorChange();
    }


    public void ChangeAttackB()
    {
        attack_B = slider_att_b.value;
        PlayerPrefs.SetFloat("attackB", attack_B);
        AttackColorChange();
    }


    public void ChangeDefendR()
    {
        defend_R = slider_def_r.value;
        PlayerPrefs.SetFloat("defendR", defend_R);
        DefendColorChange();
    }


    public void ChangeDefendG()
    {
        defend_G = slider_def_g.value;
        PlayerPrefs.SetFloat("defendG", defend_G);
        DefendColorChange();
    }


    public void ChangeDefendB()
    {
        defend_B = slider_def_b.value;
        PlayerPrefs.SetFloat("defendB", defend_B);
        DefendColorChange();
    }
}
