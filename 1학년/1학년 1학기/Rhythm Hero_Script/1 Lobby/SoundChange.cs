using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundChange : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    float master;
    float bgm;
    float sfx;

    public void MasterChange()
    {
        master = masterSlider.value;
        audioMixer.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("Master", master);
    }
    public void BgmChange()
    {
        bgm = bgmSlider.value;
        audioMixer.SetFloat("BGM", bgmSlider.value);
        PlayerPrefs.SetFloat("BGM", bgm);
    }
    public void SfxChange()
    {
        sfx = sfxSlider.value;
        audioMixer.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("SFX", sfx);
    }


    public void Start()
    {
        master = PlayerPrefs.GetFloat("Master");
        bgm = PlayerPrefs.GetFloat("BGM");
        sfx = PlayerPrefs.GetFloat("SFX");

        masterSlider.value = master;
        bgmSlider.value = bgm;
        sfxSlider.value = sfx;

        audioMixer.SetFloat("Master", masterSlider.value);
        audioMixer.SetFloat("BGM", bgmSlider.value);
        audioMixer.SetFloat("SFX", sfxSlider.value);
    }
}
