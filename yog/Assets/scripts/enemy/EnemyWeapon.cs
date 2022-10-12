using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField]
    [Range(0, 3)]
    float fireDelay = 2f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    [Range(0, 200)]
    float bulletSpeed = 1f;

    [SerializeField]
    [Range(0, 10)]
    float bulletDecayTime = 8f;

    Transform target;
    bool readyToShoot = true;

    [SerializeField] bool hasShootAnimation = false;
    [SerializeField] GameObject gunPoint;
    [SerializeField] bool autoFire = true;
    [SerializeField] LayerMask mask;

    public bool canSeePlayer = false;
    private Animator animator;
    void Start()
    {
        if(hasShootAnimation)
        {
            animator = GetComponent<Animator>();
        }
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position, target.position, out hit, ~mask))
        {
            if (hit.collider.tag != "Player")
            {
                canSeePlayer = false;
            }
            else
            {
                canSeePlayer = true;
            }

        }
        if (readyToShoot)
        {
            if (autoFire)
            {
                StartCoroutine(FireWeapon());
            }
            else if(canSeePlayer)
            {
                StartCoroutine(FireWeapon());
            }
        }                  
    }

    private IEnumerator FireWeapon()
    {
        if(hasShootAnimation)
        {
            animator.SetTrigger("shoot");
        }
        readyToShoot = false;
        GameObject instance;
        if (gunPoint != null)
        {
            instance = Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce((target.position - gunPoint.transform.position).normalized * bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            instance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            instance.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * bulletSpeed, ForceMode.Impulse);
        }
       
        Destroy(instance, bulletDecayTime);
        yield return new WaitForSeconds(fireDelay);
        readyToShoot = true;
    }
}
