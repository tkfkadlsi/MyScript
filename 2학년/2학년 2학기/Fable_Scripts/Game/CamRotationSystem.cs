using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotationSystem : MonoBehaviour
{
    NoteQueue noteQueue;
    RhythmGameManager rhythmGameManager;
    CamManager camManager;
    [SerializeField] private List<CamRotateList> Fairy_Rot_List = new List<CamRotateList>();
    [SerializeField] private List<CamRotateList> Dream_Rot_List = new List<CamRotateList>();
    [SerializeField] private List<CamRotateList> Nightmare_Rot_List = new List<CamRotateList>();

    private List<CamRotation> currentRotList;

    private void Awake()
    {
        noteQueue = FindObjectOfType<NoteQueue>();
        rhythmGameManager = FindObjectOfType<RhythmGameManager>();
        camManager = FindObjectOfType<CamManager>();
    }
     
    private void Update()
    {
        if (currentRotList.Count <= 0) return;

        if(currentRotList[0].timing <= rhythmGameManager.songTime)
        {
            CamRotate(currentRotList[0]);
            currentRotList.Remove(currentRotList[0]);
        }
    }

    private void CamRotate(CamRotation rotation)
    {
        if(rotation.isTurn == true)
        {
            camManager.TurningRot(rotation.duration, rotation.angle, rotation.curveType);
        }
        else
        {
            camManager.Return();
        }
    }

    public void SetRotationTiming()
    {
        SetCurrentNoteQueue();

        foreach(CamRotation rotation in currentRotList)
        {
            if(noteQueue.GetNote(rotation.noteIndex) != null)
                rotation.timing = noteQueue.GetNote(rotation.noteIndex).noteTiming;
        }
    }

    private void SetCurrentNoteQueue()
    {
        if(Information.Instance.currentDiff == DifficultType.Fairy)
        {
            currentRotList = Fairy_Rot_List[Information.Instance.currentSong.SongID].camRots;
        }
        else if(Information.Instance.currentDiff == DifficultType.Dream)
        {
            currentRotList = Dream_Rot_List[Information.Instance.currentSong.SongID].camRots;
        }
        else
        {
            currentRotList = Nightmare_Rot_List[Information.Instance.currentSong.SongID].camRots;
        }
    }

}
