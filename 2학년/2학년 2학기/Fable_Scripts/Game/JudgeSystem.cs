using System.Collections;
using UnityEngine;

public class JudgeSystem : MonoBehaviour
{
    [SerializeField] private JudgementText judgementText;
    [SerializeField] private Transform effectDisplayPos;
    [SerializeField] private AudioClip sfxClip;

    private ComboText comboSystem;
    private PoolManager poolManager;
    private AudioSource sfxAS;

    private string DreamStar = "DreamStar";
    private string CoolStar = "CoolStar";
    private string BedStar = "BedStar";

    private void Awake()
    {
        comboSystem = FindObjectOfType<ComboText>();
        sfxAS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        poolManager = FindObjectOfType<PoolManager>();
    }

    public void GetJudgement(JudgeType judgeType)
    {
        judgementText.Judgement(judgeType);
        bool isCombo = true;

        switch (judgeType)
        {
            case JudgeType.Dream:

                if (Information.Instance.ShowEffect)
                    SetEffectPos(poolManager.GetObject(DreamStar));
                sfxAS.PlayOneShot(sfxClip);
                Information.Instance.dream++;
                break;

            case JudgeType.Cool:

                if (comboSystem.isAP) comboSystem.isAP = false;
                if (Information.Instance.ShowEffect)
                    SetEffectPos(poolManager.GetObject(CoolStar));
                sfxAS.PlayOneShot(sfxClip);
                Information.Instance.cool++;
                break;

            case JudgeType.Bed:
                if (comboSystem.isAP) comboSystem.isAP = false;
                if (Information.Instance.ShowEffect)
                    SetEffectPos(poolManager.GetObject(BedStar));
                sfxAS.PlayOneShot(sfxClip);
                Information.Instance.bed++;
                break;

            case JudgeType.Awake:
                if (comboSystem.isAP) comboSystem.isAP = false;
                isCombo = false;
                Information.Instance.awake++;

                if (Information.Instance.IsShake)
                {
                    Vibration.Vibrate(100);
                }

                break;
        }
        comboSystem.ShowCombo(isCombo);
    }

    private void SetEffectPos(GameObject effect)
    {
        ParticleSystem particleSystem = effect.GetComponent<ParticleSystem>();
        effect.transform.SetParent(effectDisplayPos);
        effect.transform.localPosition = Vector3.zero;
        particleSystem.Play(true);
        StartCoroutine(ReturnEffect(effect));
    }

    private IEnumerator ReturnEffect(GameObject effect)
    {
        yield return new WaitForSeconds(1.5f);

        effect.transform.SetParent(null);
        poolManager.SetObject(effect.name, effect);
    }
}
