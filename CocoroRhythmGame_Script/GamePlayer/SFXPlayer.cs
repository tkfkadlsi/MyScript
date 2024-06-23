using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip noteHitSound;
    [SerializeField] private AudioClip getBellSound;
    private AudioSource sfxSource;

    private void Awake()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    public void HitNote()
    {
        sfxSource.PlayOneShot(noteHitSound);
    }

    public void GetBell()
    {
        sfxSource.PlayOneShot(getBellSound);
    }
}
