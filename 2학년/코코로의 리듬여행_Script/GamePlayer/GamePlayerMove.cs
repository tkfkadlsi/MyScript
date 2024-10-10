using System.Collections;
using UnityEngine;

public class GamePlayerMove : MonoBehaviour
{
    public int direction { get; private set; }
    private float speed = 10f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("IsMove", true);
    }

    private void Update()
    {
        if (direction == -1)
            if (GameManager.Instance.NoteManager.bellNoteList[0].Count > 0)
                GameManager.Instance.NoteManager.bellNoteList[0][0].Judgement();

        if (direction == 1)
            if (GameManager.Instance.NoteManager.bellNoteList[1].Count > 0)
                GameManager.Instance.NoteManager.bellNoteList[1][0].Judgement();
    }

    public void CallMove(int dir)
    {

        direction = dir;

        StopCoroutine("Movement");
        StartCoroutine("Movement");
    }

    private IEnumerator Movement()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(direction, startPos.y, startPos.z);
        float lerpTime = Mathf.Abs(endPos.x - startPos.x) / 10f;
        float t = 0f;

        while (t < lerpTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, t / lerpTime);

            t += Time.deltaTime;
            yield return null;
        }
        transform.position = endPos;
    }
}
