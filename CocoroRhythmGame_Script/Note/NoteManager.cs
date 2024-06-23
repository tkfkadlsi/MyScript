using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public List<Note>[] noteList = new List<Note>[4];
    public List<NoteBell>[] bellNoteList = new List<NoteBell>[2];

    public List<Transform> LinePosList = new List<Transform>();

    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject bellNotePrefab;
    public GameObject longNotePrefab;

    private int[] line = { 0, 1, 2, 3 };


    private void Awake()
    {
        for (int i = 0; i < noteList.Length; i++)
        {
            noteList[i] = new List<Note>();
        }
        for (int i = 0; i < bellNoteList.Length; i++)
        {
            bellNoteList[i] = new List<NoteBell>();
        }
    }

    public void CreateNotes(TextAsset ChaeboFile) //채보 텍스트 파일
    {
        if (Information.Instance.OptionData.IsRandom)
            RandomLine(); //이건 랜덤 걸면 라인 섞어주는 코드

        string[] notes = ChaeboFile.ToString().Split('\n');
        //1줄에 1노트니까 배열에 Split '\n'으로 나눠서 넣어줌.

        foreach (string note in notes)
        {
            string[] info = note.Split(','); //오스 채보 파일은 각 요소가 ,로 나뉘어 있으니 또 string 배열로 나눠
            NoteInfo noteinfo = new NoteInfo();//이건 구조체, 굳이 안따라해도 됨
            noteinfo.Line = LineParsing(info[0]);//LineParsing함수 참조
            noteinfo.isLong = IsLongParsing(info[3]);//IsLongParsing 참조
            noteinfo.gimmick = int.Parse(info[4]);//키음 칸을 이용해서 기믹추가(안써도 됨)
            noteinfo.ms = int.Parse(info[2]);//노트의 ms

            if (noteinfo.isLong)
            {
                noteinfo.endms = EndMSParsing(info[5]);//롱노트라면 롱노트가 끝나는 ms받아오기 EndMSParsing 함수 참조
            }

            CreateNote(noteinfo);//노트 오브젝트 만들기
        }
    }

    public void CreateBellNote(TextAsset ChaeboFile)
    {
        string[] notes = ChaeboFile.ToString().Split('\n');

        foreach (string note in notes)
        {
            string[] info = note.Split(',');
            NoteInfo noteinfo = new NoteInfo();
            noteinfo.Line = BellLineParsing(info[0]);
            noteinfo.ms = int.Parse(info[2]);

            CreateBellNote(noteinfo);
        }
    }

    private void RandomLine()
    {
        for (int i = 0; i < 1000; i++)
        {
            int rand = Random.Range(0, line.Length);
            int a = line[rand];
            line[rand] = line[0];
            line[0] = a;
        }
    }

    private int LineParsing(string line)
    {//오스는 라인 정보가 이상하게 되어있음. 그래서 그 숫자를 우리가 0, 1, 2, 3으로 바꿔줘야함.
        int intline = int.Parse(line);
        switch (intline)
        {
            case 64:
                return this.line[0];
            case 192:
                return this.line[1];
            case 320:
                return this.line[2];
            case 448:
                return this.line[3];
        }

        return intline;//어차피 작동 안하지만 없으면 에러라 넣음.
    }

    private int BellLineParsing(string line)
    {
        int intline = int.Parse(line);
        switch (intline)
        {
            case 64:
                return 0;
            case 448:
                return 1;
        }
        return intline;
    }

    private bool IsLongParsing(string isLong)
    {//롱노트면 4번째 요소가 128로 적혀있음. 그걸 이용해서 bool 값으로 파싱
        int intIsLong = int.Parse(isLong);
        switch (intIsLong)
        {
            case 128:
                return true;
            default:
                return false;
        }
    }

    private int EndMSParsing(string endms)
    {//이상하게 롱노트 끝나는 ms는 :0:0:0:0 이런식으로 장난질 되어있음. 쓸데 없는 정보는 모두 빼야하니
        //string 배열로 나눠서 필요한 값만 파싱
        string[] endmses = endms.Split(':');
        return int.Parse(endmses[0]);
    }

    private void CreateNote(NoteInfo noteInfo)
    {
        GameObject newNote = Instantiate(notePrefab);
        Note noteScript = newNote.GetComponent<Note>();

        noteScript.SetNote(noteInfo);
    }

    private void CreateBellNote(NoteInfo noteInfo)
    {
        GameObject newNote = Instantiate(bellNotePrefab);
        NoteBell noteScript = newNote.GetComponent<NoteBell>();

        noteScript.SetNote(noteInfo);
    }
}
