using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    BGM,
    SFX
}

[System.Serializable]
public class CustomAudioClip
{
    public string name;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BGMaudioSource = transform.GetChild(0).GetComponent<AudioSource>();
        SFXaudioSource = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private AudioSource BGMaudioSource;
    private AudioSource SFXaudioSource;

    [SerializeField] private List<CustomAudioClip> clipList = new List<CustomAudioClip>();

    public void PlaySound(string name, AudioType type)
    {
        foreach (CustomAudioClip clip in clipList)
        {
            if(clip.name == name)
            {
                _PlaySound(clip.clip, type);
                return;
            }
        }
    }
    public void PlaySound(AudioClip clip, AudioType type)
    {
        _PlaySound(clip, type);
    }

    private void _PlaySound(AudioClip clip, AudioType type)
    {
        switch (type)
        {
            case AudioType.BGM:
                Debug.Log("BGM");
                BGMaudioSource.PlayOneShot(clip); 
                break;
            case AudioType.SFX:
                Debug.Log("SFX");
                SFXaudioSource.PlayOneShot(clip);
                break;
        }
    }
}
