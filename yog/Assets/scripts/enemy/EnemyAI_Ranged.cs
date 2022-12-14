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
    [SerializeField] Transform eyes;
    [SerializeField] float stoppingDistanceRange;
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
                RotateToTarget();
            }
        }

        RaycastHit hit;
        if (Physics.Linecast(eyes.position, target.position, out hit, ~mask))
        {
            if (hit.collider.tag == "Player")
            {
                RotateToTarget();
                Debug.Log("set the range");
                navMeshAgent.stoppingDistance = stoppingDistanceRange;
            }
            else
            {
                navMeshAgent.stoppingDistance = 1f;
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
        Instantiate(drop, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), drop.transform.rotation);
    }

    private void Erase()
    {
        Destroy(gameObject);
    }
}
