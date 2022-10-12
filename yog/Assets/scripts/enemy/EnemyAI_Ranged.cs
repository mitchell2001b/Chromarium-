using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI_Ranged : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5f;
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] GameObject drop;
    [SerializeField] LayerMask mask;
    //private bool canSeePlayer = false;

    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            if(animator != null)
            {
                animator.SetTrigger("idle");
            }
        }

        RaycastHit hit;
        if (Physics.Linecast(transform.position, target.position, out hit, ~mask))
        {
            if (hit.collider.tag == "Player")
            {
                RotateToTarget();
            }
           

        }       
    }

    void ChaseTarget()
    {
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void DropMaterial()
    {
        Instantiate(drop, transform.position, drop.transform.rotation);
    }

    private void Erase()
    {
        Destroy(gameObject);
    }
}
