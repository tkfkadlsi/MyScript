using UnityEngine;

public class Note : MonoBehaviour
{
    private Transform myTrm;
    private LongNote myLongNote = null;
    private Transform longNoteTrm;
    private LineRenderer lineRenderer;
    private OptionData currentOptionData;
    private GameObject longHitEffect;

    public int Line { get; private set; }
    public int gimmick { get; private set; }
    public int ms { get; private set; }
    public int endms { get; private set; }
    public bool isLong { get; private set; }

    private bool isJudgementing;
    private bool isLongJudgementing;

    private float eight_beatTime;
    private float longNoteComboDelayTime;
    private int mylongNoteCombo;

    private int offset;

    private void Awake()
    {
        myTrm = GetComponent<Transform>();
        isJudgementing = false;
        isLongJudgementing = false;
        longNoteComboDelayTime = 0f;
        mylongNoteCombo = 0;
        longHitEffect = transform.GetChild(0).gameObject;
        longHitEffect.SetActive(false);
    }

    public void SetNote(NoteInfo info)
    {
        currentOptionData = Information.Instance.OptionData;

        Line = info.Line;
        gimmick = info.gimmick;
        ms = info.ms + Information.Instance.OptionData.JudgementOffset - Information.Instance.OptionData.SoundOffset;
        endms = info.endms + Information.Instance.OptionData.JudgementOffset - Information.Instance.OptionData.SoundOffset;
        isLong = info.isLong;

        GameManager.Instance.NoteManager.noteList[Line].Add(this);

        transform.position = new Vector3(
            GameManager.Instance.NoteManager.LinePosList[Line].position.x,
            0.1f,
            200);

        offset = Information.Instance.OptionData.JudgementOffset;

        if (isLong)
        {
            longHitEffect.SetActive(false);

            LongNoteInfo longNoteInfo = new LongNoteInfo();
            longNoteInfo.Line = info.Line;
            longNoteInfo.gimmick = info.gimmick;
            longNoteInfo.ms = info.endms;

            GameObject newLongNote = Instantiate(GameManager.Instance.NoteManager.longNotePrefab);
            myLongNote = newLongNote.GetComponent<LongNote>();
            longNoteTrm = myLongNote.GetComponent<Transform>();
            lineRenderer = myLongNote.GetComponent<LineRenderer>();

            myLongNote.SetNote(longNoteInfo);
            SetLongNoteLineRender();
        }
    }

    private void Update()
    {
        //Test();

        //그냥 단노트
        if (!isLong)
        {
            myTrm.position = new Vector3(myTrm.position.x, myTrm.position.y, CalculateDistance(ms));
        }
        //앞도 안쳐진 롱노트
        if (isLong && !isJudgementing)
        {
            myTrm.position = new Vector3(myTrm.position.x, myTrm.position.y, CalculateDistance(ms));
            longNoteTrm.position = new Vector3(longNoteTrm.position.x, longNoteTrm.position.y, CalculateDistance(endms));
            SetLongNoteLineRender();
        }
        //앞은 쳐진 롱노트
        if (isLong && isJudgementing)
        {
            if (longNoteComboDelayTime < 0f && mylongNoteCombo > 0)
            {
                longNoteComboDelayTime = eight_beatTime;
                mylongNoteCombo--;
                Information.Instance.Result.AddCombo(1);
            }
            else
            {
                longNoteComboDelayTime -= Time.deltaTime * 1000f;
            }
            longNoteTrm.position = new Vector3(longNoteTrm.position.x, longNoteTrm.position.y, Mathf.Clamp(CalculateDistance(endms), 0, Mathf.Infinity));
            SetLongNoteLineRender();
        }

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
        int subms = (int)(ms - GameManager.Instance.SongTime);
        subms += offset;

        int endsubms = (int)(endms - GameManager.Instance.SongTime);
        if(isLong)
        {
            endsubms += offset;
        }

        //롱노트가 아니면 넘어갔을때 처리를 멈추고 사라져야함.
        if (!isLong && subms <= -115)
        {
            Information.Instance.Result.AddJudgement(JudgementType.Miss);
            NoteDisable();
            NoteDie();
        }
        //롱노트면 앞이 안쳐지고 넘어갔을때 처리를 멈춰야함.
        if (isLong && !isJudgementing && subms <= -115)
        {
            isJudgementing = true;
            SetLongNoteCombo();

            Information.Instance.Result.AddJudgement(JudgementType.Miss);
            NoteDisable();
        }
        //롱노트면 뒤가 넘어갔을때 사라져야함.
        if (isLong && endsubms <= -115)
        {
            Information.Instance.Result.AddJudgement(JudgementType.Miss);
            NoteDisable();
            NoteDie();
        }
    }

    private void NoteDisable()
    {
        GameManager.Instance.NoteManager.noteList[Line].Remove(this);
    }

    private void NoteDie()
    {
        if (!isLong)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(myLongNote.gameObject);
            Destroy(gameObject);
        }
    }

    private void SetLongNoteLineRender()
    {
        Vector3 startPosition = new Vector3(myTrm.position.x, 0.08f, myTrm.position.z);
        Vector3 endPosition = new Vector3(myTrm.position.x, 0.08f, longNoteTrm.position.z);
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    private void SetLongNoteCombo()
    {
        eight_beatTime = GameManager.Instance.Eight_beatTime;

        longNoteComboDelayTime = eight_beatTime;
        mylongNoteCombo = (int)((endms - ms) / GameManager.Instance.Eight_beatTime) - 1;
        if (mylongNoteCombo == 0)
            mylongNoteCombo = 1;
    }

    public void Judgement()
    {
        if (isJudgementing) return;
        isJudgementing = true;


        int subms = ms - (int)GameManager.Instance.SongTime;
        subms += offset;
        bool isFast = false;
        if (subms > 0)
            isFast = true;

        subms = Mathf.Abs(subms);

        if (subms <= (int)JudgementType.Perfect_Plus)
            CallResultAdd(JudgementType.Perfect_Plus, isFast);

        else if (subms <= (int)JudgementType.Perfect)
            CallResultAdd(JudgementType.Perfect, isFast);

        else if (subms <= (int)JudgementType.Great)
            CallResultAdd(JudgementType.Great, isFast);

        else if (subms <= (int)JudgementType.Good)
            CallResultAdd(JudgementType.Good, isFast);

        else if (subms <= (int)JudgementType.Bad)
            CallResultAdd(JudgementType.Bad, isFast);

        else if (subms <= (int)JudgementType.Miss)
            CallResultAdd(JudgementType.Miss, isFast);
        else
            isJudgementing = false;

        if (isLong)
        {
            SetLongNoteCombo();
        }
    }

    private void CallResultAdd(JudgementType type, bool isFast)
    {
        GameManager.Instance.SFXPlayer.HitNote();
        if((!isFast && type > JudgementType.Great) == false)
            GameManager.Instance.HitEffectPool.DisplayEffect(myTrm.position, type);
        if ((int)type > (int)JudgementType.Perfect && Information.Instance.OptionData.IsFastSlow)
            GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.DisPlayFastSlow, isFast));

        Information.Instance.Result.AddJudgement(type);

        //롱노트가 아닌데 쳐지면 사망.
        if (!isLong)
        {
            NoteDisable();
            NoteDie();
        }
        //롱노트가 쳐지면 앞 노트의 위치를 고정하고 롱노트 이펙트 온
        else
        {
            longHitEffect.SetActive(true);
            myTrm.position = new Vector3(myTrm.position.x, myTrm.position.y, 0);
        }
    }

    public void LongJudgement()
    {
        if (!isLong) return;
        if (!isJudgementing) return;
        if (isLongJudgementing) return;
        isLongJudgementing = true;


        int subms = endms - (int)GameManager.Instance.SongTime;
        subms += offset;    
        bool isFast = false;
        if (subms > 0)
            isFast = true;

        subms = Mathf.Abs(subms);

        if (subms <= (int)JudgementType.Perfect_Plus)
            CallLongResultAdd(JudgementType.Perfect_Plus, isFast);

        else if (subms <= (int)JudgementType.Perfect)
            CallLongResultAdd(JudgementType.Perfect, isFast);

        else if (subms <= (int)JudgementType.Great)
            CallLongResultAdd(JudgementType.Perfect, isFast);

        else if (subms <= (int)JudgementType.Good)
            CallLongResultAdd(JudgementType.Good, isFast);

        else if (subms <= (int)JudgementType.Bad)
            CallLongResultAdd(JudgementType.Bad, isFast);

        else
            CallLongResultAdd(JudgementType.Miss, isFast);
    }

    private void CallLongResultAdd(JudgementType type, bool isFast)
    {
        GameManager.Instance.HitEffectPool.DisplayEffect(myTrm.position, type);
        if ((int)type > (int)JudgementType.Perfect && Information.Instance.OptionData.IsFastSlow)
            GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.DisPlayFastSlow, isFast));

        if (type == JudgementType.Perfect || type == JudgementType.Perfect_Plus)
            Information.Instance.Result.AddCombo(mylongNoteCombo);

        Information.Instance.Result.AddJudgement(type);
        //롱노트가 쳐지면 다 죽어야지.
        NoteDisable();
        NoteDie();
    }




    private void Test()
    {
        int subms = (int)(ms - GameManager.Instance.SongTime) + offset;
        if (subms <= 0)
            Judgement();

        if (isLong)
        {
            int longsubms = (int)(endms - GameManager.Instance.SongTime) + offset;
            if (longsubms <= 0)
                LongJudgement();
        }
    }
}