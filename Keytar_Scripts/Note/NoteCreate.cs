using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoteType
{
    None = 0,
    Half_Note = 1,
    Quarter_Note = 2,
    Quarter_Note_Dotted = 3,
    Eighth_Note = 4,
    Eighth_Note_Dotted = 5,
    Sixteenth_Note = 6,
    Sixteenth_Note_Dotted = 7,
    Half_Rest = 8,
    Quarter_Rest = 9,
    Eighth_Rest = 10
}

[System.Serializable]
public class ToneY
{
    public int tone;
    public float y;
    public bool isSharp;
}

public class NoteCreate : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Vector3 spawnPosition;

    NoteType currentSpawnNote = NoteType.None;
    private float delayTime = 0f;
    private float unitTime;

    [SerializeField] private List<ToneY> toneYs;

    private void Awake()
    {
        Information.Instance.ChaeboChange += ChaeboStart;
    }

    private void Start()
    {
        ChaeboStart();
    }

    private void ChaeboStart()
    {
        StopCoroutine("CreateNote");
        StopCoroutine("CreateEnemyNote");
        DeleteNote();
        StartCoroutine("CreateNote");
        StartCoroutine("CreateEnemyNote");
    }


    private IEnumerator CreateNote()
    {
        unitTime = 240 / Information.Instance.CurrentChaebo.bpm;

        for (int i = 0; i < Information.Instance.CurrentChaebo.noteList.Count; i++)
        {
            currentSpawnNote = Information.Instance.CurrentChaebo.noteList[i].type;

            GameObject currentNote = null;

            currentNote =
               PoolManager.Instance.GetObjectUI(
               currentSpawnNote.ToString(),
               spawnPosition,
               spawnTransform
               );



            Note note = currentNote.GetComponent<Note>();
            note.Tone = Information.Instance.CurrentChaebo.noteList[i].tone;
            foreach(ToneY toneY in toneYs)
            {
                if (toneY.tone == note.Tone)
                {
                    note.Set_Y(toneY);
                }
            }

            delayTime = unitTime / note.noteData.NotePeriod;
            yield return new WaitForSeconds(delayTime);
        }

        StartCoroutine("CreateNote");
    }

    private IEnumerator CreateEnemyNote()
    {
        GameObject currentNote = null;

        if (Information.Instance.stageDifficult == Difficult.normal)
        {
            currentNote = PoolManager.Instance.GetObjectUI("EnemyNote", spawnPosition, spawnTransform);

            yield return new WaitForSeconds(unitTime / 2);
        }
        else if(Information.Instance.stageDifficult == Difficult.hard)
        {
            currentNote = PoolManager.Instance.GetObjectUI("EnemyNote", spawnPosition, spawnTransform);

            yield return new WaitForSeconds(unitTime / 2);

            currentNote = PoolManager.Instance.GetObjectUI("EnemyNote", spawnPosition, spawnTransform);

            yield return new WaitForSeconds(unitTime / 4);
        }
        else
        {
            currentNote = PoolManager.Instance.GetObjectUI("EnemyNote", spawnPosition, spawnTransform);

            yield return new WaitForSeconds(unitTime / 2);
        }

        StartCoroutine("CreateEnemyNote");
    }

    private void DeleteNote()
    {
        Note[] notes = FindObjectsOfType<Note>();

        foreach(Note note in notes)
        {
            note.Release();
        }
    }

    private void OnDestroy()
    {
        Information.Instance.ChaeboChange -= ChaeboStart;
    }
}
