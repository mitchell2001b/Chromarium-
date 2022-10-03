using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    float bulletDamage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerHealth>().RecieveDamage(bulletDamage);

        if (other.tag != "Enemy" && other.tag != "Projectile") Destroy(gameObject);
    }
}
