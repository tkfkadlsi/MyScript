using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private Information information;
    private string path;

    private void Awake()
    {
        information = GetComponent<Information>();
        path = Path.Combine(Application.persistentDataPath, "OptionData.json");

        if (File.Exists(path))
        {
            LoadData();
        }
        else
        {
            ResetData();
        }
    }

    private void ResetData()
    {
        information.OptionData = new OptionData
        {
            ScrollSpeed = 4.0f,
            SoundOffset = 0,
            JudgementOffset = 0,
            MasterVolume = 0f,
            BGMVolume = 0f,
            SFXVolume = 0f,
            IsRandom = false,
            IsSuddenDeath = false,
            IsFastSlow = true,
            LS = KeyCode.LeftShift,
            LL = KeyCode.D,
            LM = KeyCode.F,
            RM = KeyCode.J,
            RR = KeyCode.K,
            RS = KeyCode.RightShift,
        };
        SaveData();
    }

    public void SaveData()
    {
        string optiondata = JsonUtility.ToJson(information.OptionData, true);

        File.WriteAllText(path, optiondata);
    }

    public void LoadData()
    {
        string optiondata = File.ReadAllText(path);

        if (optiondata == "")
        {
            information.OptionData = new OptionData
            {
                ScrollSpeed = 4.0f,
                SoundOffset = 0,
                JudgementOffset = 0,
                MasterVolume = 0f,
                BGMVolume = 0f,
                SFXVolume = 0f,
                IsRandom = false,
                IsSuddenDeath = false,
                IsFastSlow = true,
                LS = KeyCode.LeftShift,
                LL = KeyCode.D,
                LM = KeyCode.F,
                RM = KeyCode.J,
                RR = KeyCode.K,
                RS = KeyCode.RightShift,
            };

            SaveData();
        }
        else
        {
            information.OptionData = JsonUtility.FromJson<OptionData>(optiondata);
        }
    }
}
