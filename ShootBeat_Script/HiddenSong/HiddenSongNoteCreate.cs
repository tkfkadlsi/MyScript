using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum HiddenNoteDir
{
    Top = 1,
    Bottom = 2,
    Left = 3,
    Right = 4
}

public class HiddenSongNoteCreate : MonoBehaviour
{
    [SerializeField] private GameObject pos_T;
    [SerializeField] private GameObject pos_B;
    [SerializeField] private GameObject pos_L;
    [SerializeField] private GameObject pos_R;

    [SerializeField] private GameObject notePrefab;

    float bpm = 222.22f;

    public float unitTime;

    public float offset;

    float plusOffset;

    string[] lines;

    void Awake()
    {
        plusOffset = PlayerPrefs.GetFloat("Offset");
        pos_T.SetActive(false);
        pos_B.SetActive(false);
        // 대충 매모장 읽어옴
        TextAsset filePath = Resources.Load<TextAsset>("HiddenSongNote");
        lines = filePath.text.Split('\n'); // 파일의 모든 라인을 읽어옵니다.
        unitTime = 60f / (bpm * 4f);
        offset = (1700f + (int)plusOffset) / 1000f;
    }

    private void Start()
    {
        Invoke("HiddenSongStart", offset);
    }

    public void noteSelected(HiddenNoteDir dt, int bit)
    {

        switch (dt)
        {
            case HiddenNoteDir.Top:
                Invoke("CreateTopNote", unitTime * bit);
                break;
            case HiddenNoteDir.Bottom:
                Invoke("CreateBottomNote", unitTime * bit);
                break;
            case HiddenNoteDir.Left:
                Invoke("CreateLeftNote", unitTime * bit);
                break;
            case HiddenNoteDir.Right:
                Invoke("CreateRightNote", unitTime * bit);
                break;
        }
    }

    void HiddenSongStart()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');

            int dir = int.Parse(line[0]);
            int bit = int.Parse(line[1]);

            if(i >= 185)
            {
                bit -= 8;
            }

            if(i >= 305)
            {
                bit += 10;
            }

            noteSelected((HiddenNoteDir)dir, bit);
        }
        Invoke("TopLineActive", (unitTime * 100) + 1);
        Invoke("BottomLineActice", (unitTime * 255) + 1);
    }

    void TopLineActive()
    {
        if (pos_T.activeSelf == true)
        {
            pos_T.SetActive(false);
        }
        else
        {
            pos_T.SetActive(true);
        }
    }


    void BottomLineActice()
    {
        if (pos_B.activeSelf == true)
        {
            pos_B.SetActive(false);
        }
        else
        {
            pos_B.SetActive(true);
        }
    }



    GameObject CreateTopNote()
    {
        GameObject note = HiddenSongManager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_T.transform;
        note.transform.rotation = pos_T.transform.rotation;
        note.transform.position = pos_T.transform.position;
        return note;
    }


    GameObject CreateBottomNote()
    {
        GameObject note = HiddenSongManager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_B.transform;
        note.transform.rotation = pos_B.transform.rotation;
        note.transform.position = pos_B.transform.position;
        return note;
    }


    GameObject CreateLeftNote()
    {
        GameObject note = HiddenSongManager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_L.transform;
        note.transform.rotation = pos_L.transform.rotation;
        note.transform.position = pos_L.transform.position;
        return note;
    }


    GameObject CreateRightNote()
    {
        GameObject note = HiddenSongManager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_R.transform;
        note.transform.rotation = pos_L.transform.rotation;
        note.transform.position = pos_R.transform.position;
        return note;
    }
}
