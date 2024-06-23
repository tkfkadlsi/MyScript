using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionFuncs : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterVolume;
    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Slider sfxVolume;

    [SerializeField] private TextMeshProUGUI scrollSpeedTMP;
    [SerializeField] private TextMeshProUGUI soundOffsetTMP;
    [SerializeField] private TextMeshProUGUI judgementOffsetTMP;

    private void Start()
    {
        masterVolume.value = Information.Instance.OptionData.MasterVolume;
        bgmVolume.value = Information.Instance.OptionData.BGMVolume;
        sfxVolume.value = Information.Instance.OptionData.SFXVolume;

        scrollSpeedTMP.text = Information.Instance.OptionData.ScrollSpeed.ToString();
        soundOffsetTMP.text = Information.Instance.OptionData.SoundOffset.ToString();
        judgementOffsetTMP.text = Information.Instance.OptionData.JudgementOffset.ToString();
    }

    public void VolumeUp(int key)
    {
        switch (key)
        {
            case 0:
                ChangeVolume(masterVolume, VolumeType.Master, true);
                break;
            case 1:
                ChangeVolume(bgmVolume, VolumeType.BGM, true);
                break;
            case 2:
                ChangeVolume(sfxVolume, VolumeType.SFX, true);
                break;
        }
    }

    public void VolumeDown(int key)
    {
        switch (key)
        {
            case 0:
                ChangeVolume(masterVolume, VolumeType.Master, false);
                break;
            case 1:
                ChangeVolume(bgmVolume, VolumeType.BGM, false);
                break;
            case 2:
                ChangeVolume(sfxVolume, VolumeType.SFX, false);
                break;
        }
    }

    public void VolumeSet(int key)
    {
        switch (key)
        {
            case 0:
                SetVolume(masterVolume, VolumeType.Master);
                break;
            case 1:
                SetVolume(bgmVolume, VolumeType.BGM);
                break;
            case 2:
                SetVolume(sfxVolume, VolumeType.SFX);
                break;
        }
    }

    private void ChangeVolume(Slider volumeSlider, VolumeType volumeType, bool isUp)
    {
        float volume = volumeSlider.value;
        if (isUp)
        {
            volume += 5;
        }
        else
        {
            volume -= 5;
        }

        volume = Mathf.Clamp(volume, -80, 20);

        volumeSlider.value = volume;

        switch (volumeType)
        {
            case VolumeType.Master:
                audioMixer.SetFloat("Master", volume);
                Information.Instance.OptionData.MasterVolume = volume;
                break;
            case VolumeType.BGM:
                Information.Instance.OptionData.BGMVolume = volume;
                audioMixer.SetFloat("BGM", volume);
                break;
            case VolumeType.SFX:
                Information.Instance.OptionData.SFXVolume = volume;
                audioMixer.SetFloat("SFX", volume);
                break;
        }

        Information.Instance.GetComponent<SaveLoad>().SaveData();
    }

    private void SetVolume(Slider volumeSlider, VolumeType volumeType)
    {
        float volume = volumeSlider.value;

        switch (volumeType)
        {
            case VolumeType.Master:
                audioMixer.SetFloat("Master", volume);
                Information.Instance.OptionData.MasterVolume = volume;
                break;
            case VolumeType.BGM:
                Information.Instance.OptionData.BGMVolume = volume;
                audioMixer.SetFloat("BGM", volume);
                break;
            case VolumeType.SFX:
                Information.Instance.OptionData.SFXVolume = volume;
                audioMixer.SetFloat("SFX", volume);
                break;
        }

        Information.Instance.GetComponent<SaveLoad>().SaveData();
    }

    public void ChangeScrollSpeed(bool isUp)
    {
        float scrollSpeed = Information.Instance.OptionData.ScrollSpeed;

        if (isUp)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                scrollSpeed += 1f;
            else
                scrollSpeed += 0.1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
                scrollSpeed -= 1f;
            else
                scrollSpeed -= 0.1f;
        }

        scrollSpeed = Mathf.Clamp(scrollSpeed, 1.0f, 12.0f);

        scrollSpeed = Mathf.Round(scrollSpeed * 10) / 10;

        scrollSpeedTMP.text = scrollSpeed.ToString();
        Information.Instance.OptionData.ScrollSpeed = scrollSpeed;

        Information.Instance.GetComponent<SaveLoad>().SaveData();
    }

    public void ChangeSoundOffset(bool isUp)
    {
        int soundoffset = Information.Instance.OptionData.SoundOffset;
        int changeValue = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            changeValue *= 10;
        }

        if (isUp)
        {
            soundoffset += changeValue;
        }
        else
        {
            soundoffset -= changeValue;
        }

        soundoffset = Mathf.Clamp(soundoffset, -200, 200);

        Information.Instance.OptionData.SoundOffset = soundoffset;
        soundOffsetTMP.text = Information.Instance.OptionData.SoundOffset.ToString();

        Information.Instance.GetComponent<SaveLoad>().SaveData();
    }

    public void ChangeJudgementOffset(bool isUp)
    {
        int judgementoffset = Information.Instance.OptionData.JudgementOffset;
        int changeValue = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            changeValue *= 10;
        }

        if (isUp)
        {
            judgementoffset += changeValue;
        }
        else
        {
            judgementoffset -= changeValue;
        }

        judgementoffset = Mathf.Clamp(judgementoffset, -200, 200);

        Information.Instance.OptionData.JudgementOffset = judgementoffset;
        judgementOffsetTMP.text = Information.Instance.OptionData.JudgementOffset.ToString();

        Information.Instance.GetComponent<SaveLoad>().SaveData();
    }
}
