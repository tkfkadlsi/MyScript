using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Vector3 targetPos;

    private bool IsStopped = true;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        targetPos = GameObject.Find(Information.Instance.CurrentSong.ToString()).transform.position;
        MoveSkip();
    }

    private void Update()
    {
        bool isMoving = agent.velocity.sqrMagnitude > 0.1f;
        anim.SetBool("IsMove", isMoving);
    }

    public void TargetPosition(string targetName)
    {
        targetPos = GameObject.Find(targetName).transform.position;
        agent.SetDestination(targetPos);
    }

    public void MoveSkip()
    {
        agent.Warp(targetPos);
    }
}