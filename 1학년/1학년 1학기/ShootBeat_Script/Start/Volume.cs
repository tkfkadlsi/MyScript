using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class Volume : MonoBehaviour
{
    public static Volume Instance;
    [SerializeField] private AudioMixer audioMixer;

    Slider BgmSlider;
    Slider SfxSlider;
    Slider OffsetSlider;
    TextMeshProUGUI offsetText;
    private float bgm, sfx;
    private float offset;

    float Offset
    {
        get
        {
            return offset;
        }
        set
        {
            if (value > 200)
                return;
            else if (value < -200)
                return;
            else
                offset = value;
        }
    }
    
    public void SetBgmVolume()
    {
        bgm = BgmSlider.value;
        audioMixer.SetFloat("BGM", bgm);
        PlayerPrefs.SetFloat("BGM", bgm);
    }

    public void SetSfxVolume()
    {
        sfx = SfxSlider.value;
        audioMixer.SetFloat("SFX", sfx);
        PlayerPrefs.SetFloat("SFX", sfx);
    }

    public void SetOffset()
    {
        Offset = (int)OffsetSlider.value;
        PlayerPrefs.SetFloat("Offset", Offset);
        SetOffsetText();
    }

    public void PlusOffset()
    {
        Offset++;
        OffsetSlider.value = Offset;
        PlayerPrefs.SetFloat("Offset", Offset);
        SetOffsetText();
    }

    public void MinusOffset()
    {
        Offset--;
        OffsetSlider.value = Offset;
        PlayerPrefs.SetFloat("Offset", Offset);
        SetOffsetText();
    }

    private void Awake()
    {
        BgmSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        SfxSlider = GameObject.Find("SFXSlider").GetComponent<Slider>();
        OffsetSlider = GameObject.Find("OffsetSlider").GetComponent<Slider>();
        offsetText = GameObject.Find("OffsetText").GetComponent<TextMeshProUGUI>();

        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);

        Offset = PlayerPrefs.GetFloat("Offset");

        bgm = PlayerPrefs.GetFloat("BGM");
        sfx = PlayerPrefs.GetFloat("SFX");

        BgmSlider.value = bgm;
        SfxSlider.value = sfx;


        OffsetSlider.value = Offset;
        SetOffsetText();
    }

    private void Start()
    {
        audioMixer.SetFloat("BGM", bgm);
        audioMixer.SetFloat("SFX", sfx);
    }

    void SetOffsetText()
    {
        offsetText.text = $"{(int)Offset}";
    }
}