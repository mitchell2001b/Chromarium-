using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float TurnSpeed = 5;
    [SerializeField] float ChaseRange = 5.0f;

    [SerializeField] float PatrolSpeed = 5.0f;
    [SerializeField] float WaitTime = 0.3f;
    [SerializeField] float PatrolTurnSpeed = 90f;

    float DistanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;
    [SerializeField] bool WakeUpIntro;
    private bool IsWakedUp = false;
    private bool WakingUp = false;

    Animator animatorEnemy;

    [SerializeField] Transform PathHolder;
    public Transform[] points;
    public int destPoint = 0;

    [SerializeField] bool debug;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animatorEnemy = GetComponent<Animator>();

        navMeshAgent.autoBraking = false;

        /*if(PathHolder.childCount > 0)
        {
            Vector3[] waypoints = new Vector3[PathHolder.childCount];
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = PathHolder.GetChild(i).transform.position;
                waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
            }

            StartCoroutine(PatrolPath(waypoints));
        } */


       
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            if(debug)
            {
                Debug.Log("0 points" + gameObject.name);
            }
           
            return;
        }

        animatorEnemy.SetTrigger("walk");
        // Set the agent to go to the currently selected destination.
        navMeshAgent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if(debug)
        {
            //Debug.Log(destPoint + "dest before");
        }
        destPoint = (destPoint + 1) % points.Length;
        if (debug)
        {
            //Debug.Log(destPoint + "dest after");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!navMeshAgent.pathPending)
        {
            //Debug.Log("its pending");
        }
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            //Debug.Log("its remain distance");
        }
        if(!isProvoked && !navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            if (debug)
            {
                //Debug.Log(destPoint + "dest to");
            }
            //Debug.Log(navMeshAgent.remainingDistance + "remain" + gameObject.name);
            GotoNextPoint();
        }
        
        DistanceToTarget = Vector3.Distance(target.position, transform.position);
        
          
        if(isProvoked)
        {
            if(WakeUpIntro && !IsWakedUp && !WakingUp)
            {
                WakingUp = true;
                animatorEnemy.SetTrigger("wakeup");

            }

            if(IsWakedUp || !WakeUpIntro)
            {
                EngageTarget();
            }
           
        }
        else if(DistanceToTarget < ChaseRange)
        {
            isProvoked = true;
        }



        
    }

    private void ChangeWakingUpStateEvent()
    {     
        IsWakedUp = true;      
    }

    IEnumerator PatrolPath(Vector3[] waypoints)
    {
       
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);
        while(!isProvoked)
        {
            animatorEnemy.SetTrigger("walk");
            Debug.Log("kkkk");
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, PatrolSpeed * Time.deltaTime);
            if(transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
               
                //yield return new WaitForSeconds(WaitTime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
                Debug.Log("reee");
            }

            yield return null;
        }

    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 directionToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(directionToLookTarget.z, directionToLookTarget.x) * Mathf.Rad2Deg;
        animatorEnemy.SetTrigger("idle");
        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f && !isProvoked)
        {
           
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, PatrolTurnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;

            yield return null;
        }
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * TurnSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);
    }

    private void EngageTarget()
    {

        
        //Debug.Log(DistanceToTarget + " dst " + navMeshAgent.stoppingDistance + " stop");
        if (DistanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
            //Debug.Log("chase");
        }

        if(DistanceToTarget <= navMeshAgent.stoppingDistance)
        {
            FaceTarget();
            AttackTarget();
            //Debug.Log("fireballl");
        }

        
        
    }

    private void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        
        animatorEnemy.SetBool("attack", false);
        animatorEnemy.SetTrigger("walk");
        
        
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        animatorEnemy.SetBool("attack", true);
        Debug.Log("attack");
    }
}
