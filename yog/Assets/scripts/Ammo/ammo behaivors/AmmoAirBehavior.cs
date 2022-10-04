using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAirBehavior : BaseAmmoBehaivor
{

    [SerializeField] GameObject hitEffect;
    [SerializeField] LayerMask mask;
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        RaycastHit hit;
        if (Physics.Raycast(this.GetPlayerWeaponPoint().transform.position, this.GetPlayerWeaponPoint().transform.forward, out hit, (this.GetBaseRange() + rangeIncrease), ~mask))
        {
            if(hit.collider.transform.gameObject.tag == "Enemy")
            {
                Debug.Log("damaging enemy");
            }
            CreateHitImpact(hit);
            
        }
        this.PlayMuzzleFlash();
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
