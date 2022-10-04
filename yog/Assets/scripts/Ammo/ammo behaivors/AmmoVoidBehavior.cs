using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoVoidBehavior : BaseAmmoBehaivor
{

    [SerializeField] float timedRange;
    [SerializeField] float explosionRadius;
    [SerializeField] GameObject explosiveTriggerPrefab;
    [SerializeField] float explosiveTriggerMoveSpeed;
    //[SerializeField] Transform playerWeapon;

    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        GameObject triggerObject = Instantiate(explosiveTriggerPrefab, this.GetPlayerWeaponPoint().transform.position, this.GetPlayerWeaponPoint().transform.rotation);
        triggerObject.GetComponent<VoidExplosion>().explosionDamage = GetBaseDamage() + damageIncrease;
        triggerObject.GetComponent<VoidExplosion>().explosionRadius = explosionRadius;
        triggerObject.GetComponent<Rigidbody>().AddForce(this.GetPlayerWeaponPoint().transform.forward * explosiveTriggerMoveSpeed, ForceMode.Impulse);
        Destroy(triggerObject, timedRange);
        /*RaycastHit hit;
        if (Physics.Raycast(this.GetPlayerCam().transform.position, this.GetPlayerCam().transform.forward, out hit, (this.GetBaseRange() + rangeIncrease)))
        {
            Debug.Log("joehoe");
        }*/
        this.PlayMuzzleFlash();
    }

    

    

}
