using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectDiffcult : MonoBehaviour
{
    [SerializeField] private Sprite fairytaleSprite;
    [SerializeField] private Sprite dreamSprite;
    [SerializeField] private Sprite nightmareSprite;
    [SerializeField] private Sprite noneSprite;

    [SerializeField] private Image fairytaleButton;
    [SerializeField] private Image dreamButton;
    [SerializeField] private Image nightmareButton;

    private RhythmGamePanel rhythmGamePanel;

    private void Start()
    {
        rhythmGamePanel = FindObjectOfType<RhythmGamePanel>();
        SelectDream();
    }

    public void SelectFairytale()
    {
        fairytaleButton.sprite = fairytaleSprite;
        dreamButton.sprite = noneSprite;
        nightmareButton.sprite = noneSprite;

        fairytaleButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, -15, 0);
        dreamButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        nightmareButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);

        Information.Instance.currentDiff = DifficultType.Fairy;
        rhythmGamePanel.SetDiffDream();
    }

    public void SelectDream()
    {
        fairytaleButton.sprite = noneSprite;
        dreamButton.sprite = dreamSprite;
        nightmareButton.sprite = noneSprite;

        fairytaleButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        dreamButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, -15, 0);
        nightmareButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);

        Information.Instance.currentDiff = DifficultType.Dream;
        rhythmGamePanel.SetDiffDream();
    }

    public void SelectNightmare()
    {
        fairytaleButton.sprite = noneSprite;
        dreamButton.sprite = noneSprite;
        nightmareButton.sprite = nightmareSprite;

        fairytaleButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        dreamButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        nightmareButton.GetComponentInChildren<TextMeshProUGUI>().rectTransform.anchoredPosition = new Vector3(0, -15, 0);

        Information.Instance.currentDiff = DifficultType.Nightmare;
        rhythmGamePanel.SetDiffNightmare();
    }
}
