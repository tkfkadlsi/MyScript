using DG.Tweening;
using UnityEngine;

public class LobbyUIMove : MonoBehaviour
{
    private RhythmGamePanel gamePanel;
    private ItemPanel dkdlxpavosjf;

    private void Awake()
    {
        gamePanel = FindObjectOfType<RhythmGamePanel>();
        dkdlxpavosjf = FindObjectOfType<ItemPanel>();
    }

    public void RhythmGameMoveON()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.OutCirc).OnComplete(()=>
        {
            gamePanel.noTouchZonePanel.gameObject.SetActive(true);
        });
    }

    public void Dkdlxpavosjfanqmdhs()
    {
        dkdlxpavosjf.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.OutCirc);
    }

    public void RhythmGameMoveOFF()
    {
        GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -900), 0.5f).SetEase(Ease.OutCirc);
        dkdlxpavosjf.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, -900), 0.5f).SetEase(Ease.OutCirc);
    }
}