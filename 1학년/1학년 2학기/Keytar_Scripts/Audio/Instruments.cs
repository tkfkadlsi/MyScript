using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruments : MonoBehaviour
{
    public List<Instrument> instruments;

    private void Awake()
    {
        Information.Instance.CurrentInst = instruments[0];
    }
}

[System.Serializable]
public class Instrument
{
    public string InstName;
    public List<AudioClip> clips;
}
