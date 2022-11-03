using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5f;
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] GameObject drop;

    [SerializeField] bool isCargoUnit = false;
    [SerializeField] CargoUnit cargo;
    [System.Serializable]
    public class CargoUnit
    {
        [SerializeField] GameObject cargoSpawnPrefab;
        [SerializeField] float cargoSpawnRange;
        [SerializeField] int cargoUnitCount;


        public void SpawnCargoUnits(Transform transformEnemy)
        {
            bool offsetBool = false;
            for (int i = 0; i < cargoUnitCount; i++)
            {
                
                float offset = UnityEngine.Random.Range(0, cargoSpawnRange);
                if (offsetBool)
                {
                    Instantiate(cargoSpawnPrefab, new Vector3(transformEnemy.position.x + offset, transformEnemy.position.y + 1, transformEnemy.position.z + offset), cargoSpawnPrefab.transform.rotation);
                    offsetBool = false;
                }
                else
                {
                    Instantiate(cargoSpawnPrefab, new Vector3(transformEnemy.position.x - offset, transformEnemy.position.y + 1, transformEnemy.position.z - offset), cargoSpawnPrefab.transform.rotation);
                    offsetBool = true;
                }
                
                
            }
        }
    }


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance){
            ChaseTarget();
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance){
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        try
        {
            navMeshAgent.SetDestination(target.position);
        }
        catch(Exception ex)
        {

        }
        
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void DropMaterial()
    {
        Instantiate(drop, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), drop.transform.rotation);
        if(isCargoUnit)
        {
            cargo.SpawnCargoUnits(this.transform);
        }
    }

    private void Erase()
    {
        Destroy(gameObject);
    }
}
