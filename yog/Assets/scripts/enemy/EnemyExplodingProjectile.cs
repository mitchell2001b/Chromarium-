using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodingProjectile : MonoBehaviour
{
    [SerializeField] float projectileDamage;

    [SerializeField] float explosionRadius;

    [SerializeField] float turnSpeed;
    [SerializeField] ParticleSystem vfx;

    private Transform target;

    private EnemySoundHandler sound;
    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").transform;
       sound = GetComponent<EnemySoundHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z), Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {          
            return;
        }

        RaycastHit[] entitiesHit;
        entitiesHit = Physics.SphereCastAll(other.transform.position, explosionRadius, transform.up);
        foreach (RaycastHit entity in entitiesHit)
        {           
            if (entity.collider.gameObject.tag == "Player")
            {
                
                PlayerHealth health = entity.collider.transform.gameObject.GetComponent<PlayerHealth>();
                if (health == null)
                {
                    return;
                }

                health.ReceiveDamage(projectileDamage);
            }
        }
        vfx.transform.parent = null;
        
        vfx.Play();
        sound.PlayDeathSound();


        Destroy(this.gameObject);
        Destroy(vfx, 2);


    }
}
