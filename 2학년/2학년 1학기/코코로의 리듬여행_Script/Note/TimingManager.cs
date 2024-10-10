using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<Timing> timingList = new List<Timing>();

    public void SetTiming(TextAsset timingFile)
    {
        string[] timings = timingFile.ToString().Split('\n');

        foreach (string timing in timings)
        {
            string[] info = timing.Split(',');

            Timing newTiming = new Timing();
            newTiming.timing = int.Parse(info[0]);
            newTiming.newBPM =
                (int)(60000 / float.Parse(info[1]));

            timingList.Add(newTiming);
        }
    }

    public void ChangeBPM()
    {
        if (timingList.Count == 0) return;
        else
        {
            GameManager.Instance.Eight_beatTime = (30f / timingList[0].newBPM) * 1000f;
            timingList.Remove(timingList[0]);
        }


    }
}
