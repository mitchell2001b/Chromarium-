using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAiKamikaze : MonoBehaviour
{

    [SerializeField] float turnSpeed = 5f;
    [SerializeField] float runSpeed = 10f;
     private float walkSpeed;
    private Transform target;
    [SerializeField] NavMeshAgent navMeshAgent;
    private Animator animator;
    private float distanceToTarget = Mathf.Infinity;
    [SerializeField] GameObject drop;
    [SerializeField] float meleeRange = 10f;

    public EnemyKamikazeAttack attack;

    private bool hasExploded = false;

    //public EnemyHealth health;
   
   // [SerializeField] float navmeshStoppingDistanceMelee = 2f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent.GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        walkSpeed = navMeshAgent.speed;
        attack = GetComponent<EnemyKamikazeAttack>();
        //health = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();

        /*if(health.isDead)
        {
            if (!hasExploded)
            {
                Debug.Log("explode");
                attack.Explode();
                hasExploded = true;
            }
        }*/
    }

    private void RotateToTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void ChaseTarget()
    {
        navMeshAgent.isStopped = false;
        animator.SetBool("attack", false);
        navMeshAgent.SetDestination(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, meleeRange);


        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }

    private void EngageTarget()
    {

        if (distanceToTarget < meleeRange)
        {
            navMeshAgent.speed = runSpeed;
            animator.SetTrigger("run");
            ChaseTarget();
        }
        else
        {
            
            navMeshAgent.speed = walkSpeed;
            animator.SetTrigger("walk");
            ChaseTarget();
        }


        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.velocity = Vector3.zero;
            RotateToTarget();
            AttackTarget();
            
            //Debug.Log("fireballl");
        }
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
              
    }



    private void OnDisable()
    {
        if (!hasExploded)
        {
            Debug.Log("explode");
            attack.Explode();
            hasExploded = true;
        }
    }

}
