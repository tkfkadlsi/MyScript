public class JobMethod
{
    public JobMethod(JobMethodType methodType)
    {
        MethodType = methodType;
    }

    public JobMethod(JobMethodType methodType, JudgementType judgement)
    {
        MethodType = methodType;
        Judgement = judgement;
    }

    public JobMethod(JobMethodType methodType, bool isFast)
    {
        MethodType = methodType;
        IsFast = isFast;
    }

    public JobMethodType MethodType;
    public JudgementType Judgement;
    public bool IsFast;
}
