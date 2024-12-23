//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TutorialManager : MonoBehaviour
//{
//    private PlayerInput player;

//    private bool tutorialLeftStep = false;
//    private bool tutorialRightStep = false;
//    private bool tutorialLeftTurn = false;
//    private bool tutorialRightTurn = false;
//    private bool tutorialEventNote = false;

//    [SerializeField] private GameObject LeftStepPopup;
//    [SerializeField] private GameObject RightStepPopup;
//    [SerializeField] private GameObject LeftRotatePopup;
//    [SerializeField] private GameObject RightRotatePopup;
//    [SerializeField] private GameObject EventNotePopup;

//    private void Awake()
//    {
//        player = FindObjectOfType<PlayerInput>();
//        LeftStepPopup.SetActive(false);
//        RightStepPopup.SetActive(false);
//        LeftRotatePopup.SetActive(false);
//        RightRotatePopup.SetActive(false);
//        EventNotePopup.SetActive(false);
//    }

//    private void Start()
//    {
//        player.rhythmManager.isTutorial = true;
//        player.rhythmManager.TutorialManager = this;
//    }

//    private void Update()
//    {
//        if(player.rhythmManager.isSongPlaying && player.noteQ.GetNote(0).GetType() != typeof(NoneStepNote))
//        {
//            if (TimingCheck())
//            {
//                PopupTutorial(player.noteQ.GetNote(0));
//            }
//        }
//    }

//    private void PopupTutorial(Note note)
//    {
//        if(note is LeftStepNote && !tutorialLeftStep)
//        {
//            tutorialLeftStep = true;
//            player.rhythmManager.SongPause();
//            LeftStepPopup.SetActive(true);
//        }
//        else if(note is RightStepNote && !tutorialRightStep)
//        {
//            tutorialRightStep = true;
//            player.rhythmManager.SongPause();
//            RightStepPopup.SetActive(true);
//        }
//        else if(note is LeftTurnNote && !tutorialLeftTurn)
//        {
//            tutorialLeftTurn = true;
//            player.rhythmManager.SongPause();
//            LeftRotatePopup.SetActive(true);
//        }
//        else if(note is RightTurnNote && !tutorialRightTurn)
//        {
//            tutorialRightTurn = true;
//            player.rhythmManager.SongPause();
//            RightRotatePopup.SetActive(true);
//        }
//        else if(note is EventNote && !tutorialEventNote)
//        {
//            tutorialEventNote = true;
//            player.rhythmManager.SongPause();
//            EventNotePopup.SetActive(true);
//        }
//    }

//    private bool TimingCheck()
//    {
//        return 0.04f > Mathf.Abs(player.noteQ.GetNote(0).noteTiming - player.rhythmManager.songTime);
//    }

//    public void TutorialInput(Note currentNote, NoteType touchType)
//    {
//        if(currentNote is LeftStepNote && touchType == NoteType.LeftStep)
//        {
//            currentNote.Hit(touchType);
//            player.rhythmManager.SongResume();
//            LeftStepPopup.SetActive(false);
//        }
//        else if(currentNote is RightStepNote && touchType == NoteType.RightStep)
//        {
//            currentNote.Hit(touchType);
//            player.rhythmManager.SongResume();
//            RightStepPopup.SetActive(false);
//        }
//        else if(currentNote is LeftTurnNote && touchType == NoteType.LeftRotate)
//        {
//            currentNote.Hit(touchType);
//            player.rhythmManager.SongResume();
//            LeftRotatePopup.SetActive(false);
//        }
//        else if(currentNote is RightTurnNote && touchType == NoteType.RightRotate)
//        {
//            currentNote.Hit(touchType);
//            player.rhythmManager.SongResume();
//            RightRotatePopup.SetActive(false);
//        }
//        else if(currentNote is EventNote && touchType == NoteType.EventNote)
//        {
//            currentNote.Hit(touchType);
//            player.rhythmManager.SongResume();
//            EventNotePopup.SetActive(false);
//        }
//    }
//}
