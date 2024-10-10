using UnityEngine;

public class NoteBell : MonoBehaviour
{
    private OptionData currentOptionData;
    private Transform myTrm;

    public int Line { get; private set; }
    public int ms { get; private set; }

    private void Start()
    {
        currentOptionData = Information.Instance.OptionData;
        myTrm = GetComponent<Transform>();
    }

    public void SetNote(NoteInfo info)
    {
        Line = info.Line;
        ms = info.ms;

        GameManager.Instance.NoteManager.bellNoteList[Line].Add(this);

        transform.position = new Vector3(
            GameManager.Instance.NoteManager.LinePosList[Line == 0 ? 0 : 3].position.x,
            0.5f,
            200);
    }

    private void Update()
    {
        myTrm.position = new Vector3(myTrm.position.x, myTrm.position.y, CalculateDistance(ms));
        DieCheck();
    }

    private float CalculateDistance(int ms)
    {
        float subms = ms - GameManager.Instance.SongTime;

        float distance = subms / 1000f * currentOptionData.ScrollSpeed * 4f;

        return distance;
    }

    private void DieCheck()
    {
        if (ms + 75 - GameManager.Instance.SongTime <= -75)
        {
            NoteDisable();
            NoteDie();
        }
    }

    private void NoteDisable()
    {
        GameManager.Instance.NoteManager.bellNoteList[Line].Remove(this);
    }

    private void NoteDie()
    {
        Destroy(gameObject);
    }

    public void Judgement()
    {
        int subms = ms + 75 - (int)GameManager.Instance.SongTime;
        subms = Mathf.Abs(subms);

        if (subms <= (int)JudgementType.Great)
        {
            CallResultAdd();
        }
    }

    private void CallResultAdd()
    {
        GameManager.Instance.SFXPlayer.GetBell();
        Information.Instance.Result.AddBell();

        NoteDisable();
        NoteDie();
    }
}
