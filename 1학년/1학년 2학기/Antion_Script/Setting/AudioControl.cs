using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Tkfkadlsi
{
    public class AudioControl : MonoBehaviour
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider sfxVolumeSlider;
        [SerializeField] private TextMeshProUGUI masterVolumeText;
        [SerializeField] private TextMeshProUGUI bgmVolumeText;
        [SerializeField] private TextMeshProUGUI sfxVolumeText;

        private float MasterVolume = 0;
        private float BGMVolume = 0;
        private float SFXVolume = 0;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey("MasterVolume"))
            {
                VolumeReset();
                return;
            }

            MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
            BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        }

        private void VolumeReset()
        {
            PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
            PlayerPrefs.SetFloat("BGMVolume", BGMVolume);
            PlayerPrefs.SetFloat("SFXVolume", SFXVolume);


        }

        private void Start()
        {
            audioMixer.SetFloat("Master", MasterVolume);
            audioMixer.SetFloat("BGM", BGMVolume);
            audioMixer.SetFloat("SFX", SFXVolume);

            masterVolumeSlider.value = MasterVolume;
            bgmVolumeSlider.value = BGMVolume;
            sfxVolumeSlider.value = SFXVolume;

            masterVolumeText.text = Percentage(masterVolumeSlider.value).ToString() + "%";
            bgmVolumeText.text = Percentage(bgmVolumeSlider.value).ToString() + "%";
            sfxVolumeText.text = Percentage(sfxVolumeSlider.value).ToString() + "%";
        }

        public void MasterVolumeChange()
        {
            float volume = masterVolumeSlider.value;
            MasterVolume = volume;
            PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
            audioMixer.SetFloat("Master", MasterVolume);
            masterVolumeText.text = Percentage(masterVolumeSlider.value).ToString() + "%";
        }

        public void BGMVolumeChange()
        {
            float volume = bgmVolumeSlider.value;
            BGMVolume = volume;
            PlayerPrefs.SetFloat("BGMVolume", BGMVolume);
            audioMixer.SetFloat("BGM", BGMVolume);
            bgmVolumeText.text = Percentage(bgmVolumeSlider.value).ToString() + "%";
        }

        public void SFXVolumeChange()
        {
            float volume = sfxVolumeSlider.value;
            SFXVolume = volume;
            PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
            audioMixer.SetFloat("SFX", SFXVolume);
            sfxVolumeText.text = Percentage(sfxVolumeSlider.value).ToString() + "%";
        }

        private float Percentage(float value)
        {
            value = value + 80;
            return (int)value;
        }
    }
}