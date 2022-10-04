using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidExplosion : MonoBehaviour
{
    public float explosionRadius;
    public float explosionDamage;
    public ParticleSystem vfx;
    public LayerMask mask;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {     
        if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            return;
        }
        vfx.Play();
        RaycastHit[] entitiesHit;
        entitiesHit = Physics.SphereCastAll(other.transform.position, explosionRadius, transform.up);
        foreach (RaycastHit entity in entitiesHit)
        {
            if (entity.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("enemy takes damage");
            }
        }

        Destroy(this.gameObject, 1);

    }
}
