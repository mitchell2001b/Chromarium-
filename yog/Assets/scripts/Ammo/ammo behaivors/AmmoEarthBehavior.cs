using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEarthBehavior : BaseAmmoBehaivor
{
    [SerializeField] LayerMask mask;
    [SerializeField] int spreadCount;
    [SerializeField] GameObject hitEffect;
    [Range(0, 90)]
    public float spreadAngle = 0;
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        for (int i = 0; i < spreadCount; i++)
        {
            RaycastHit hit;
            Vector3 randomVector =
                            Quaternion.AngleAxis(Random.Range(-spreadAngle, spreadAngle), Vector3.Cross((this.GetPlayerWeaponPoint().transform.forward).normalized, Vector3.up)) * (this.GetPlayerWeaponPoint().transform.forward).normalized +
                            Quaternion.AngleAxis(Random.Range(-spreadAngle, spreadAngle), Vector3.Cross((this.GetPlayerWeaponPoint().transform.forward).normalized, Vector3.right)) * (this.GetPlayerWeaponPoint().transform.forward).normalized;


            if (Physics.Raycast(this.GetPlayerWeaponPoint().transform.position, randomVector, out hit, (this.GetBaseRange() * rangeIncrease), ~mask))
            {             
                if(hit.collider.transform.gameObject.tag == "Enemy")
                {
                    EnemyHealth health = hit.collider.transform.gameObject.GetComponent<EnemyHealth>();
                    if (health == null)
                    {
                        return;
                    }

                    health.RecieveDamage((this.GetBaseDamage() * damageIncrease), AmmoType.Earth);
                }
                CreateHitImpact(hit);
            }

          
        }
       
        this.PlayMuzzleFlash();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
