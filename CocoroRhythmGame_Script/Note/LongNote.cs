using UnityEngine;

public class LongNote : MonoBehaviour
{
    public int Line { get; private set; }
    public int gimmick { get; private set; }
    public int ms { get; private set; }

    public void SetNote(LongNoteInfo info)
    {
        Line = info.Line;
        gimmick = info.gimmick;
        ms = info.ms;

        transform.position = new Vector3(
            GameManager.Instance.NoteManager.LinePosList[Line].position.x,
            0.1f,
            200);
    }
}
