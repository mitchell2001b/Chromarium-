using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoFireBehavior : BaseAmmoBehaivor
{
    public GameObject fireConeObject;
    [SerializeField] ParticleSystem fire;

    private bool backupSaved = false;
    private Vector3 backupScale;
    
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        if(!backupSaved)
        {
            backupScale = new Vector3(fireConeObject.transform.localScale.x, fireConeObject.transform.localScale.y, fireConeObject.transform.localScale.z);
            backupSaved = true;
        }
        fireConeObject.transform.localScale = new Vector3(backupScale.x * rangeIncrease, backupScale.y * rangeIncrease, backupScale.z * rangeIncrease);
        foreach(Collider c in fireConeObject.GetComponent<FireCone>().GetColliders())
        {
            if(c.gameObject.tag == "Enemy")
            {
                EnemyHealth health = c.transform.gameObject.GetComponent<EnemyHealth>();
                if (health == null)
                {
                    return;
                }

                health.RecieveDamage((this.GetBaseDamage() * damageIncrease), AmmoType.Fire);
            }
        }
        fire.Play();
        this.PlayMuzzleFlash();
        //fireConeObject.transform.localScale = backupScale;
        
    }

    
}
