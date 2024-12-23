using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JudgementText : MonoBehaviour
{
    private Image judgeImage;
    private float imageOnTime;

    [SerializeField] private Sprite DreamImage;
    [SerializeField] private Sprite CoolImage;
    [SerializeField] private Sprite BedImage;
    [SerializeField] private Sprite AwakeImage;

    [SerializeField] private AnimationCurve animationCurve;

    private IEnumerator sizeLerpCo;

    private void Awake()
    {
        judgeImage = GetComponent<Image>();
        imageOnTime = 0f;

        sizeLerpCo = SizeLerp();
    }

    private void Update()
    {
        if (imageOnTime <= 0f)
        {
            if (judgeImage.enabled)
                judgeImage.enabled = false;
            return;
        }
        imageOnTime -= Time.deltaTime;
    }

    public void Judgement(JudgeType judge)
    {
        imageOnTime = 0.5f;
        judgeImage.enabled = true;
        if(sizeLerpCo is not null)
            StopCoroutine(sizeLerpCo);

        StartCoroutine(sizeLerpCo = SizeLerp());

        switch (judge)
        {
            case JudgeType.Dream:
                judgeImage.sprite = DreamImage;
                break;
            case JudgeType.Cool:
                judgeImage.sprite = CoolImage;
                break;
            case JudgeType.Bed:
                judgeImage.sprite = BedImage;
                break;
            case JudgeType.Awake:
                judgeImage.sprite = AwakeImage;
                break;
        }
    }

    private IEnumerator SizeLerp()
    {
        float t = 0f;
        float lerpTime = 0.25f;

        Vector3 startSize = new Vector3(1.5f, 1.5f, 1f);
        Vector3 endSize = Vector3.one;

        while(t < lerpTime)
        {
            t += Time.deltaTime;
            yield return null;

            judgeImage.rectTransform.localScale = Vector3.Lerp(startSize, endSize, animationCurve.Evaluate(t / lerpTime));
        }
    }
}
