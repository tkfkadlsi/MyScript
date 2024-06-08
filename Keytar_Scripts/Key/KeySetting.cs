using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class KeySetting : MonoBehaviour
{
    [SerializeField] private string _keymode;
    public string _Keymode
    {
        get
        {
            return _keymode;
        }
        set
        {
            _keymode = value;
            Information.Instance.Keymode = _Keymode;
        }
    }
    public List<Key> KeyList = new List<Key>();

    [SerializeField] private GameObject changeImage;

    [SerializeField] private TextMeshProUGUI[] keyTextList;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Keymode"))
        {
            Load();
        }
        ChangeText();

        changeImage.SetActive(false);
    }

    private void Start()
    {
        Information.Instance.Keymode = _keymode;
        Information.Instance.currentKeyList = KeyList;
    }

    public void CallChange(string keyName)
    {
        changeImage.SetActive(true);

        StartCoroutine(ChangeWait(keyName));
    }

    private IEnumerator ChangeWait(string keyName)
    {
        KeyCode newCode = KeyCode.None;

        yield return new WaitUntil(() => Input.anyKeyDown);
        for (int i = 0; i < 510; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                newCode = (KeyCode)i;
                break;
            }
        }

        bool isOverlap = false;
        Key overlapKey = new Key();

        foreach (Key key in KeyList)
        {
            if(newCode == key.Code)
            {
                overlapKey = key;
                isOverlap = true;
            }
        }

        if (isOverlap)
        {
            foreach(Key forchangeKey in KeyList)
            {
                if(keyName == forchangeKey.KeyName)
                {
                    overlapKey.Code = forchangeKey.Code;
                    forchangeKey.Code = newCode;
                    ChangeText();
                }
            }
        }
        else
        {
            foreach(Key forchangeKey in KeyList)
            {
                if(keyName == forchangeKey.KeyName)
                {
                    forchangeKey.Code = newCode;
                    ChangeText();
                }
            }
        }

        changeImage.SetActive(false);
    }

    private void ChangeText()
    {
        for (int i = 0; i < keyTextList.Length; i++)
        {
            keyTextList[i].text = KeyList[i].Code.ToString();
        }
        Save();
    }

    public void SetKeytar()
    {
        KeyList[0].Code = KeyCode.Keypad6;
        KeyList[1].Code = KeyCode.F1;
        KeyList[2].Code = KeyCode.F2;
        KeyList[3].Code = KeyCode.F3;
        KeyList[4].Code = KeyCode.Keypad3;
        KeyList[5].Code = KeyCode.Keypad9;
        KeyList[6].Code = KeyCode.Alpha1;
        KeyList[7].Code = KeyCode.Alpha2;
        ChangeText();
    }

    public void SetKeyboard()
    {
        KeyList[0].Code = KeyCode.UpArrow;
        KeyList[1].Code = KeyCode.LeftArrow;
        KeyList[2].Code = KeyCode.DownArrow;
        KeyList[3].Code = KeyCode.RightArrow;
        KeyList[4].Code = KeyCode.A;
        KeyList[5].Code = KeyCode.S;
        KeyList[6].Code = KeyCode.F;
        KeyList[7].Code = KeyCode.Space;
        ChangeText();
    }

    private void Save()
    {
        PlayerPrefs.SetString("Keymode", _keymode);
        PlayerPrefs.SetInt("Key0", (int)KeyList[0].Code);
        PlayerPrefs.SetInt("Key1", (int)KeyList[1].Code);
        PlayerPrefs.SetInt("Key2", (int)KeyList[2].Code);
        PlayerPrefs.SetInt("Key3", (int)KeyList[3].Code);
        PlayerPrefs.SetInt("Key4", (int)KeyList[4].Code);
        PlayerPrefs.SetInt("Key5", (int)KeyList[5].Code);
        PlayerPrefs.SetInt("Key6", (int)KeyList[6].Code);
        PlayerPrefs.SetInt("Key7", (int)KeyList[7].Code);
    }

    private void Load()
    {
        _keymode = PlayerPrefs.GetString("Keymode");
        KeyList[0].Code = (KeyCode)PlayerPrefs.GetInt("Key0");
        KeyList[1].Code = (KeyCode)PlayerPrefs.GetInt("Key1");
        KeyList[2].Code = (KeyCode)PlayerPrefs.GetInt("Key2");
        KeyList[3].Code = (KeyCode)PlayerPrefs.GetInt("Key3");
        KeyList[4].Code = (KeyCode)PlayerPrefs.GetInt("Key4");
        KeyList[5].Code = (KeyCode)PlayerPrefs.GetInt("Key5");
        KeyList[6].Code = (KeyCode)PlayerPrefs.GetInt("Key6");
        KeyList[7].Code = (KeyCode)PlayerPrefs.GetInt("Key7");
    }
}