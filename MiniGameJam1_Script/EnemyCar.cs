using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public bool start = false;

    [SerializeField] private List<GameObject> location;

    private Transform target;
    private Animator animator;
    private int count;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        target = location[count].transform;
    }

    private void Update()
    {
        if (!start) return;

        Vector3 dir = target.position - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
        transform.Translate(Vector3.forward * 30f * Time.deltaTime);
        animator.SetFloat("CurrentSpeed", 30);
    }

    public void Touch()
    {
        count++;
        target = location[count].transform;
    }
}
