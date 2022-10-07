using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikazeAttack : MonoBehaviour
{
    [SerializeField] float explosionDamage;
    [SerializeField] float explosionRadius;
    [SerializeField] ParticleSystem vfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);      
    }
    public void Explode()
    {     
        RaycastHit[] entitiesHit;
        entitiesHit = Physics.SphereCastAll(transform.position, explosionRadius, transform.up);
        foreach (RaycastHit entity in entitiesHit)
        {
            if (entity.collider.gameObject.tag == "Enemy")
            {
                EnemyHealth health = entity.collider.transform.gameObject.GetComponent<EnemyHealth>();
                if (health == null)
                {
                    return;
                }

                health.RecieveDamage(explosionDamage, AmmoType.Regular);
            }

            if(entity.collider.gameObject.tag == "Player")
            {

                PlayerHealth health = entity.collider.transform.gameObject.GetComponent<PlayerHealth>();
                if (health == null)
                {
                    return;
                }

                health.ReceiveDamage(explosionDamage);
            }
        }
        vfx.transform.parent = null;
        //vfx.transform.position = gameObject.transform.position;
        vfx.Play();
        Destroy(this.gameObject);
        Destroy(vfx.gameObject, 2f);
    }

    public void AttackHitEvent()
    {
        Explode();
    }

}
