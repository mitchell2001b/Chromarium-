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
    [Range(0, 20)]
    float bulletSpeed = 1f;

    [SerializeField]
    [Range(0, 10)]
    float bulletDecayTime = 8f;

    Transform target;
    bool readyToShoot = true;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (readyToShoot) StartCoroutine(FireWeapon());
    }

    private IEnumerator FireWeapon()
    {
        readyToShoot = false;
        GameObject instance = Instantiate(bulletPrefab, transform.position, transform.rotation);
        instance.GetComponent<Rigidbody>().AddForce((target.position - transform.position).normalized * bulletSpeed, ForceMode.Impulse);
        Destroy(instance, bulletDecayTime);
        yield return new WaitForSeconds(fireDelay);
        readyToShoot = true;
    }
}
