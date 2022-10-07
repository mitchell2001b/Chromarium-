using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyExplosion : MonoBehaviour
{
    public float explosionRadius;
    public float explosionDamage;
    public ParticleSystem vfx;
    public LayerMask mask;


   
    public void Explode()
    {      
        vfx.Play();
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

                health.RecieveDamage((this.explosionDamage), AmmoType.Regular);
            }
        }

        //vfx.transform.parent = null;
        //vfx.Play();
        //Destroy(vfx.gameObject, 2f);
        Debug.Log("destroy this");
        Destroy(gameObject, 2f);


    }

    
}
