using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponProjectileBehaviour : MonoBehaviour
{
    [SerializeField]
    float bulletDamage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.tag == "Player") other.GetComponent<PlayerHealth>().ReceiveDamage(bulletDamage);

        if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Projectile" && other.gameObject.layer != LayerMask.NameToLayer("Bullet")  && other.gameObject.tag != "PlayerWeaponObject") Destroy(gameObject);
    }
}
