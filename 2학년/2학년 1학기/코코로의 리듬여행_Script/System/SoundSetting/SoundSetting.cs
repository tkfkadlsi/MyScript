using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Slider masterVolume;
    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider sfxVolume;

    private void Start()
    {
        masterVolume.value = Information.Instance.OptionData.MasterVolume;
        bgmVolume.value = Information.Instance.OptionData.BGMVolume;
        sfxVolume.value = Information.Instance.OptionData.SFXVolume;
    }


}
