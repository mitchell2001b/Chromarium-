using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyAI_Switcher : MonoBehaviour
{
    
    [SerializeField] float turnSpeed = 5f;
    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    [SerializeField] GameObject drop;
    [SerializeField] GameObject graph;
    [SerializeField] float switchDelay;
    private EnemyHealth health;
    [SerializeField] List<SwitchMode> modes;
    [SerializeField] float spawnRange;
    [SerializeField] int spawnCount;
    [SerializeField] EnemySoundHandler soundHandler;

    [System.Serializable]
    public class SwitchMode
    {
        public AmmoType ammoType;
        public GameObject spawnPrefab;
        public Material meshTexture;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>();
        StartCoroutine(SwitchClock());
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        soundHandler = GetComponent<EnemySoundHandler>();
        target = GameObject.FindWithTag("Player").transform;
    }

    IEnumerator SwitchClock()
    {
        if(animator !=  null)
        {
            animator.SetTrigger("spawn");
            soundHandler.PlayAttackSound();
        }
       
        SwitchMode mode = GetRandomSwitchMode();
        health.ChangeAffinity(mode.ammoType);
        bool offsetBool = false;       
       
        for (int i = 0; i < spawnCount; i++)
        {

            float offset = UnityEngine.Random.Range(0, spawnRange);
            if (offsetBool)
            {
                Instantiate(mode.spawnPrefab, new Vector3(transform.position.x + offset, transform.position.y + 1, transform.position.z + offset), mode.spawnPrefab.transform.rotation);
                offsetBool = false;
            }
            else
            {
                Instantiate(mode.spawnPrefab, new Vector3(transform.position.x - offset, transform.position.y + 1, transform.position.z - offset), mode.spawnPrefab.transform.rotation);
                offsetBool = true;
            }


        }
        graph.GetComponent<SkinnedMeshRenderer>().material = mode.meshTexture;
        yield return new WaitForSeconds(switchDelay);
        StartCoroutine(SwitchClock());
    }

    private SwitchMode GetRandomSwitchMode()
    {
        int index = UnityEngine.Random.Range(0, modes.Count);

        return modes[index];
    }


    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        EngageTarget();
        
    }
    private void EngageTarget()
    {
        FaceTarget();

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            animator.SetTrigger("idle");
        }
    }

    private void ChaseTarget()
    {
        try
        {
            navMeshAgent.SetDestination(target.position);
        }
        catch (Exception ex)
        {
            Debug.Log("Navmesh could not set location");
        }

        
        animator.SetTrigger("move");
    }

    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void DropMaterial()
    {
        Instantiate(drop, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), drop.transform.rotation);        
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
