using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CamDrag : MonoBehaviour
{
    [SerializeField] private AnimationCurve movingCurve;
    private Transform CamTrm;
    private Island[] islands;
    private LobbyBlind lobbyBlind;

    int cnt;
    public bool isMoving = true;

    private void Start()
    {
        cnt = Information.Instance.currentSong.SongID;
        CamTrm = Camera.main.transform;
        islands = FindObjectsOfType<Island>();
        lobbyBlind = FindObjectOfType<LobbyBlind>();
        LobbyManager.Instance.SongPlay();
        Vector3 islandPos = GetIsland().transform.position;
        islandPos.z = CamTrm.position.z;
        islandPos.y += 0.4f;
        CamTrm.position = islandPos;
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        foreach (Island island in islands)
        {
            island.CanSelectCall();
        }
        isMoving = false;
    }

    private Vector2 lastMousePosition;

    private void Update()
    {
        if (isMoving)
            return;
        if (LobbyManager.Instance.SelectType != SelectType.NoSelect)
            return;
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                Vector2 currentMousePosition = Input.mousePosition;
                Vector2 deltaPosition = currentMousePosition - lastMousePosition;

                if (deltaPosition.magnitude > 300f)
                {
                    if (deltaPosition.y < 0f && cnt < 9)
                    {
                        cnt++;
                        if (cnt == 6)
                            cnt = 8;
                        LobbyManager.Instance.SelectType = SelectType.Moving;
                        MovetoIsland(GetIsland());
                    }
                    else if (deltaPosition.y > 0f && cnt > 0)
                    {
                        cnt--;
                        if (cnt == 7)
                            cnt = 5;
                        LobbyManager.Instance.SelectType = SelectType.Moving;
                        MovetoIsland(GetIsland());
                    }

                    lastMousePosition = currentMousePosition;
                    return;
                }
            }

            Touch touch = new Touch();
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
            }

            if (touch.deltaPosition.magnitude > 300f)
            {
                if (touch.deltaPosition.y < 0f && cnt < 9)
                {
                    cnt++;
                    if (cnt == 6)
                        cnt = 8;
                    LobbyManager.Instance.SelectType = SelectType.Moving;
                    MovetoIsland(GetIsland());
                }
                else if (touch.deltaPosition.y > 0f && cnt > 0)
                {
                    cnt--;
                    if (cnt == 7)
                        cnt = 5;
                    LobbyManager.Instance.SelectType = SelectType.Moving;
                    MovetoIsland(GetIsland());
                }

                return;
            }
        }
    }

    public Island GetIsland()
    {
        foreach (Island i in islands)
        {
            if (i.IslandID == cnt)
                return i;
        }

        return null;
    }

    public void MovetoIsland(Island island, bool toBlind = true)
    {
        Vector3 targetPos = island.transform.position;
        targetPos.z = 0;
        targetPos.y += 0.4f;
        Information.Instance.currentSong = Information.Instance.SongList[island.IslandID];
        if (toBlind)
        {
            LobbyManager.Instance.SongPlay();
        }
        StartCoroutine(MovingCam(targetPos, toBlind));
    }

    private IEnumerator MovingCam(Vector3 endPos, bool toBlind)
    {
        isMoving = true;
        Vector3 startPos = CamTrm.position;
        endPos.z = CamTrm.position.z;
        float t = 0f;
        float lerpTime = 0.5f;
        if (toBlind)
        {
            StartCoroutine(lobbyBlind.Blind(Color.black));
        }
        while (t < lerpTime)
        {
            t += Time.deltaTime;
            yield return null;

            CamTrm.position = Vector3.Lerp(startPos, endPos, movingCurve.Evaluate(t / lerpTime));
        }
        if (toBlind)
        {
            StartCoroutine(lobbyBlind.Blind(Color.clear));
        }
        yield return new WaitForSeconds(0.2f);
        LobbyManager.Instance.SelectType = SelectType.NoSelect;
        isMoving = false;
    }
}