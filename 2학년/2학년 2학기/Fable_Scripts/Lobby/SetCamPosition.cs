using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class SetCamPosition : MonoBehaviour
{
    private float plusPosition = -0.4f;
    private float originSize = 0;
    private CamDrag camDrag;

    private void Start()
    {
        camDrag = FindObjectOfType<CamDrag>();

        originSize = 3;

        //if(Application.platform == RuntimePlatform.Android)
        //{
        //    originSize = 3;
        //}
        //else
        //{
        //    originSize = 2;
        //}

        //Camera.main.orthographicSize = originSize;
    }

    public void Set(Vector3 IslandPosition)
    {
        StartCoroutine(IslandLerpPosition(IslandPosition, originSize, 2));
    }

    public bool Cancel()
    {
        if (LobbyManager.Instance.SelectType != SelectType.Select) return false;   
        //LobbyManager.instance.SelectUIOFF();
        StartCoroutine(RollBackSize()); //이제 뭐 해야될지 생각하셈.
        camDrag.MovetoIsland(camDrag.GetIsland(), false);
        return true;
    }


    private IEnumerator IslandLerpPosition(Vector3 IslandPos, float startSize, float targetSize)
    {
        Vector3 fixedPos = new Vector3(IslandPos.x, IslandPos.y + plusPosition, -10);
        float t = 0f;
        float lerpTime = 0.5f;
        while (t < lerpTime)
        {
            Camera.main.transform.position =
                Vector3.Lerp(Camera.main.transform.position, fixedPos, t / lerpTime);
            Camera.main.orthographicSize = Mathf.Lerp(startSize, targetSize, t / lerpTime);
            t += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = fixedPos;

        //LobbyManager.instance.SelectUION();
    }

    public IEnumerator RollBackSize()
    {
        Vector3 fixedPos = Camera.main.transform.position;
        fixedPos.y -= plusPosition;
        float t = 0f;
        float lerpTime = 0.5f;
        while (t < lerpTime)
        {
            Camera.main.orthographicSize
                = Mathf.Lerp(Camera.main.orthographicSize, originSize, t / lerpTime);
            t += Time.deltaTime;
            yield return null;
        }
        Camera.main.orthographicSize = originSize; 

        LobbyManager.Instance.UnSelect();
    }
}
