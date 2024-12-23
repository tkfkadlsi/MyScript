using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NoteType
{
    NoneNote,
    LeftStep,
    LeftRotate,
    RightStep,
    RightRotate,
    EventNote
}
public abstract class Note : MonoBehaviour
{
    public float noteTiming = 0;
    public int noteIndex = 0;
    protected static PlayerInput player;
    protected static SetEventTimingSystem eventTimingSystem;
    protected bool isHit = false;
    protected bool isNoneStep = false;
    protected bool isDieNote = false;

    private static float dreamJudge = 0f;
    private static float coolJudge = 0f;

    protected virtual void Awake()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerInput>();
            eventTimingSystem = FindObjectOfType<SetEventTimingSystem>();
        }
    }

    private void Start()
    {

        if (Information.Instance.currentDiff == DifficultType.Dream || Information.Instance.currentDiff == DifficultType.Fairy)
        {
            dreamJudge = 0.080f;//80ms
            coolJudge = 0.150f;//150ms
        }
        else
        {
            dreamJudge = 0.040f;//40ms
            coolJudge = 0.075f;//75ms
        }

        if (Information.Instance.UseFairytaleItem)
        {
            dreamJudge *= 1.5f;
            coolJudge *= 1.5f;
        }
    }

    public abstract void Hit(NoteType type);

    protected void Judgement(bool isTurnNote = false)
    {
        isHit = true;
        float judgeTime = Mathf.Abs(player.rhythmManager.songTime - noteTiming);
        if (isTurnNote)
        {
            if (judgeTime < coolJudge)
            {
                player.judgeSystem.GetJudgement(JudgeType.Dream);
            }
            else
            {
                player.judgeSystem.GetJudgement(JudgeType.Bed);
            }
        }
        else
        {
            if (judgeTime < dreamJudge)
            {
                player.judgeSystem.GetJudgement(JudgeType.Dream);
            }
            else if (judgeTime < coolJudge)
            {
                player.judgeSystem.GetJudgement(JudgeType.Cool);
            }
            else
            {
                player.judgeSystem.GetJudgement(JudgeType.Bed);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.noteQ.RemoveNote(this);
            if (isNoneStep) { return; }

            if (isHit == false)
            {
                if (isDieNote == true)
                {
                    if(Information.Instance.UseHeroItem == true)
                    {
                        Information.Instance.UseHeroItem = false;
                        player.gameItemText.UseGameItem("용사의 가호 사용!");

                        if(this is TurnNote)
                        {
                            if(this is RightTurnNote)
                            {
                                player.TagDown(this.gameObject, 90);
                            }
                            else
                            {
                                player.TagDown(this.gameObject, -90);
                            }
                        }
                        player.judgeSystem.GetJudgement(JudgeType.Bed);
                        return;
                    }
                    player.playerDie.Die();
                }
                else
                {
                    if(Information.Instance.UseFairyItem == true)
                    {
                        Information.Instance.UseFairyItem = false;
                        player.gameItemText.UseGameItem("요정의 가호 사용!");

                        player.judgeSystem.GetJudgement(JudgeType.Bed);
                        return;
                    }
                }
                

                player.judgeSystem.GetJudgement(JudgeType.Awake);
            }
        }
    }
}
