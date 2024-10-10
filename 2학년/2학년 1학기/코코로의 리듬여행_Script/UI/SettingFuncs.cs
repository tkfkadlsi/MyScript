using UnityEngine;
using UnityEngine.UI;

public class SettingFuncs : MonoBehaviour
{
    [SerializeField] private Image random_on;
    [SerializeField] private Image random_off;
    [SerializeField] private Image suddendeath_on;
    [SerializeField] private Image suddendeath_off;
    [SerializeField] private Image fastslow_on;
    [SerializeField] private Image fastslow_off;

    [SerializeField] private Color selectedColor = Color.yellow;
    [SerializeField] private Color unselectColor = Color.white;

    private void Start()
    {
        if (Information.Instance.OptionData.IsRandom)
            OnRandom();
        else
            OffRandom();

        if (Information.Instance.OptionData.IsSuddenDeath)
            OnSuddenDeath();
        else
            OffSuddenDeath();

        if (Information.Instance.OptionData.IsFastSlow)
            OnFastSlow();
        else
            OffFastSlow();
    }

    public void OnRandom()
    {
        random_on.color = selectedColor;
        random_off.color = unselectColor;
        Information.Instance.OptionData.IsRandom = true;
    }
    public void OffRandom()
    {
        random_on.color = unselectColor;
        random_off.color = selectedColor;
        Information.Instance.OptionData.IsRandom = false;
    }

    public void OnSuddenDeath()
    {
        suddendeath_on.color = selectedColor;
        suddendeath_off.color = unselectColor;
        Information.Instance.OptionData.IsSuddenDeath = true;
    }
    public void OffSuddenDeath()
    {
        suddendeath_on.color = unselectColor;
        suddendeath_off.color = selectedColor;
        Information.Instance.OptionData.IsSuddenDeath = false;
    }

    public void OnFastSlow()
    {
        fastslow_on.color = selectedColor;
        fastslow_off.color = unselectColor;
        Information.Instance.OptionData.IsFastSlow = true;
    }
    public void OffFastSlow()
    {
        fastslow_on.color = unselectColor;
        fastslow_off.color = selectedColor;
        Information.Instance.OptionData.IsFastSlow = false;
    }
}
