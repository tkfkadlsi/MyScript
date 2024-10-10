using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum noteDir3
{
    Top = 1,
    Bottom = 2,
    Left = 3,
    Right = 4
}

public class Song3NoteCreate : MonoBehaviour
{
    [SerializeField] private GameObject pos_T;
    [SerializeField] private GameObject pos_B;
    [SerializeField] private GameObject pos_L;
    [SerializeField] private GameObject pos_R;

    [SerializeField] private GameObject notePrefab;

    int bpm = 225;

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
        TextAsset filePath = Resources.Load<TextAsset>("Song3Note");
        lines = filePath.text.Split('\n'); // 파일의 모든 라인을 읽어옵니다.
        unitTime = 60f / (bpm * 4f);
        offset = (160f + (int)plusOffset) / 1000f;
    }

    private void Start()
    {
        Invoke("Song3Start", offset);
    }

    public void noteSelected(noteDir3 dt, int bit)
    {

        switch (dt)
        {
            case noteDir3.Top:
                Invoke("CreateTopNote", unitTime * bit);
                break;
            case noteDir3.Bottom:
                Invoke("CreateBottomNote", unitTime * bit);
                break;
            case noteDir3.Left:
                Invoke("CreateLeftNote", unitTime * bit);
                break;
            case noteDir3.Right:
                Invoke("CreateRightNote", unitTime * bit);
                break;
        }
    }

    void Song3Start()
    {
        for (int i = 0; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');

            int dir = int.Parse(line[0]);
            int bit = int.Parse(line[1]);

            noteSelected((noteDir3)dir, bit);
        }
        Invoke("TopLineActive", (unitTime * 127) + 1);
        Invoke("BottomLineActice", (unitTime * 159) + 1);
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
        GameObject note = Song3Manager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_T.transform;
        note.transform.rotation = pos_T.transform.rotation;
        note.transform.position = pos_T.transform.position;
        return note;
    }


    GameObject CreateBottomNote()
    {
        GameObject note = Song3Manager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_B.transform;
        note.transform.rotation = pos_B.transform.rotation;
        note.transform.position = pos_B.transform.position;
        return note;
    }


    GameObject CreateLeftNote()
    {
        GameObject note = Song3Manager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_L.transform;
        note.transform.rotation = pos_L.transform.rotation;
        note.transform.position = pos_L.transform.position;
        return note;
    }


    GameObject CreateRightNote()
    {
        GameObject note = Song3Manager.instance.NoteGet();
        note.transform.tag = "Note";
        note.transform.parent = pos_R.transform;
        note.transform.rotation = pos_L.transform.rotation;
        note.transform.position = pos_R.transform.position;
        return note;
    }
}
