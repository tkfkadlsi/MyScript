using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEventTimingSystem : MonoBehaviour
{
    [SerializeField] private List<EventTimingList> FairytaleEventTimingLists = new List<EventTimingList>();
    [SerializeField] private List<EventTimingList> DreamEventTimingLists = new List<EventTimingList>();
    [SerializeField] private List<EventTimingList> NightmareEventTimingLists = new List<EventTimingList>();

    private EventTimingList currentList = new EventTimingList();
    private NoteQueue noteQueue;
    private EventFuncs eventFuncs;
    private RhythmGameManager rhythmGameManager;

    private void Awake()
    {
        noteQueue = FindObjectOfType<NoteQueue>();
        rhythmGameManager = FindObjectOfType<RhythmGameManager>();
    }

    private void OnEnable()
    {
        if(Information.Instance.currentDiff == DifficultType.Fairy)
        {
            foreach (EventTimingList list in FairytaleEventTimingLists)
            {
                if (list.SongID == Information.Instance.currentSong.SongID)
                {
                    currentList = list;
                    break;
                }
            }
        }
        else if(Information.Instance.currentDiff == DifficultType.Dream)
        {
            foreach (EventTimingList list in DreamEventTimingLists)
            {
                if (list.SongID == Information.Instance.currentSong.SongID)
                {
                    currentList = list;
                    break;
                }
            }
        }
        else
        {
            foreach (EventTimingList list in NightmareEventTimingLists)
            {
                if (list.SongID == Information.Instance.currentSong.SongID)
                {
                    currentList = list;
                    break;
                }
            }
        }


        switch (Information.Instance.currentSong.SongID)
        {
            case 0:
                eventFuncs = GetComponentInChildren<EventFunc_0>();
                break;
            case 1:
                eventFuncs = GetComponentInChildren<EventFunc_1>();
                break;
            case 2:
                eventFuncs = GetComponentInChildren<EventFunc_2>();
                break;
            case 3:
                eventFuncs = GetComponentInChildren<EventFunc_3>();
                break;
            case 4:
                eventFuncs = GetComponentInChildren<EventFunc_4>();
                break;
            case 5:
                eventFuncs = GetComponentInChildren<EventFunc_5>();
                break;
            case 6:
                eventFuncs = GetComponentInChildren<EventFunc_6>();
                break;
            case 7:
                eventFuncs = GetComponentInChildren<EventFunc_7>();
                break;
            case 8:
                eventFuncs = GetComponentInChildren<EventFunc_8>();
                break;
            case 9:
                eventFuncs = GetComponentInChildren<EventFunc_9>();
                break;
        }

    }

    public void SetTiming()
    {
        if(currentList != null && currentList.Timings.Count != 0)
        {
            foreach (EventTiming eventTiming in currentList.Timings)
            {
                if (noteQueue.GetNote(eventTiming.NoteIndex) != null)
                    eventTiming.Timing = noteQueue.GetNote(eventTiming.NoteIndex).noteTiming;
            }
        }
    }

    public void EventNoteProduction(int noteIndex)
    {
        eventFuncs.Event_1(noteIndex);
    }

    private void Update()
    {
        if (currentList.Timings.Count > 0)
        {
            if(currentList.Timings[0].Timing <= rhythmGameManager.songTime)
            {
                EventStart(currentList.Timings[0]);
                currentList.Timings.Remove(currentList.Timings[0]);
            }
        }
    }

    private void EventStart(EventTiming @event)
    {
        Debug.Log(@event);
        switch(@event.Type)
        {
            case EventType.Event_1:
                eventFuncs.Event_1(@event.NoteIndex);
                break;
            case EventType.Event_2:
                eventFuncs.Event_2(@event.NoteIndex);
                break;
            case EventType.Event_3:
                eventFuncs.Event_3(@event.NoteIndex);
                break;
        }
    }
}
