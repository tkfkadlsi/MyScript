[System.Serializable]
public class Result
{
    public int Score;
    public float Rate;
    public int PerfectPlusCount;
    public int PerfectCount;
    public int GreatCount;
    public int GoodCount;
    public int BadCount;
    public int MissCount;
    public int Combo;
    public int MaxCombo;
    public int FastCount;
    public int SlowCount;
    public int BellScore;
    public int BellCount;

    public void AddJudgement(JudgementType judgementType)
    {
        AddCombo(1);
        switch (judgementType)
        {
            case JudgementType.Perfect_Plus:
                PerfectPlusCount++;
                break;
            case JudgementType.Perfect:
                PerfectCount++;
                break;
            case JudgementType.Great:
                GreatCount++;
                break;
            case JudgementType.Good:
                GoodCount++;
                break;
            case JudgementType.Bad:
                BadCount++;
                break;
            case JudgementType.Miss:
                MissCount++;
                Combo = 0;
                GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.DisplayCombo));
                break;
        }
        float noteCount = PerfectPlusCount + PerfectCount + GreatCount + GoodCount + BadCount + MissCount;
        float noteAccuSum = PerfectPlusCount * 101 + PerfectCount * 100
        + GreatCount * 80 + GoodCount * 60 + BadCount * 40 + MissCount * 0;
        Rate = noteAccuSum / noteCount;
        float Scoresum = PerfectPlusCount * 100 + PerfectCount * 100 +
            GreatCount * 80 + GoodCount * 60 + BadCount * 40 + MissCount * 0;
        Score = (int)(Scoresum / GameManager.Instance.noteCount * 10000);

        if (noteCount == GameManager.Instance.noteCount)
            GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.GameEnd));

        GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.Judgement, judgementType));
    }

    public void AddCombo(int plusCombo)
    {
        Combo += plusCombo;

        if (MaxCombo < Combo)
            MaxCombo = Combo;

        GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.DisplayCombo));
    }

    public void AddBell()
    {
        BellCount++;
        BellScore = (int)(50000 * ((float)BellCount / (float)GameManager.Instance.bellNoteCount));

        GameManager.Instance.JobQ.Enqueue(new JobMethod(JobMethodType.DisplayBellScore));
    }
}
