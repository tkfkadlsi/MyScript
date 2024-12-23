using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEditor.Rendering;
using UnityEngine;

public class EventNote_Four : EventNote
{
    [SerializeField] private AnimationCurve trmUpCurve;
    Transform playerTrm;

    protected override void Awake()
    {
        base.Awake();
        playerTrm = player.transform;
        trmUpCurve = player.rhythmManager.GetComponent<EventNoteTool>().Fairy_Spring_EventCurve;
        isDieNote = true;
    }


    protected override void EventFunc()
    {
        base.EventFunc();
        animaionControl.Event();
        StartEvent();
    }

    public override void Hit(NoteType type)
    {
        if (isHit) { return; }
        if (type != NoteType.EventNote) { return; }
        EventFunc();
        Judgement();
    }

    private void StartEvent()
    {
        Debug.Log("¿Ã∫•∆Æ");
        StartCoroutine(WhileEvent());
    }

    private IEnumerator WhileEvent()
    {
        float endY = playerTrm.position.y + 2f;
        float startY = playerTrm.position.y;

        float t = 0f;
        float lerpTime;
        if(Information.Instance.currentDiff == DifficultType.Dream)
        {
            lerpTime = 120f / Information.Instance.currentSong.SongBPM;
        }
        else
        {
            lerpTime = 60f / Information.Instance.currentSong.SongBPM;
        }

        while(t < lerpTime)
        {
            playerTrm.position = Vector3.Lerp(
                new Vector3(playerTrm.position.x, startY, playerTrm.position.z),
                new Vector3(playerTrm.position.x, endY, playerTrm.position.z),
                trmUpCurve.Evaluate(t/lerpTime));

            t += Time.deltaTime;
            yield return null;
        }
    }
}
