using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void SoundPlay(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}