using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class Island : MonoBehaviour, IPointerClickHandler
{
    public int IslandID;
    [SerializeField] private TextMeshProUGUI songNameText;

    private RhythmGamePanel gamePanel;

    private bool canSelect = false;

    private void Start()
    {
        songNameText = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        if(Information.Instance.IsKorean)
        {
            songNameText.text = Information.Instance.SongList[IslandID].SongName;
        }
        else
        {
            songNameText.text = Information.Instance.SongList[IslandID].EngSongName;
        }
        LobbyManager.Instance.SelectIsland += SelectFunc;
        LobbyManager.Instance.UnSelectIsland += UnSelectFunc;
        gamePanel = FindObjectOfType<RhythmGamePanel>();
        SpriteRenderer sprite = new GameObject() { name = "LobbyBG" }.AddComponent<SpriteRenderer>();
        sprite.sprite = Information.Instance.SongList[IslandID].LobbyBGSprite;
        sprite.transform.SetParent(transform);
        sprite.transform.position = transform.position + new Vector3(0, 0, 10);
        sprite.transform.localScale *= 0.35f;
    }

    private void OnDestroy()
    {
        LobbyManager.Instance.SelectIsland -= SelectFunc;
        LobbyManager.Instance.UnSelectIsland -= UnSelectFunc;
    }

    private void SelectFunc()
    {
        songNameText.enabled = false;
    }

    private void UnSelectFunc()
    {
        songNameText.enabled = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canSelect)
            return;

        if (LobbyManager.Instance.SelectType != SelectType.NoSelect) return;
        LobbyManager.Instance.Selecting(IslandID);
        LobbyManager.Instance.SetCamPosition.Set(transform.position);
    }

    public void CanSelectCall()
    {
        canSelect = true;
    }
}
