using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHolyBehavior : BaseAmmoBehaivor
{
    [SerializeField] float timedRange;
    [SerializeField] float explosionRadius;
    [SerializeField] GameObject explosiveTriggerPrefab;
    [SerializeField] float explosiveTriggerMoveSpeed;
    [SerializeField] Transform playerWeapon;
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        GameObject triggerObject = Instantiate(explosiveTriggerPrefab, playerWeapon.position, playerWeapon.rotation);
        triggerObject.GetComponent<HolyExplosion>().explosionDamage = GetBaseDamage() * damageIncrease;
        triggerObject.GetComponent<HolyExplosion>().explosionRadius = explosionRadius * rangeIncrease;
        triggerObject.GetComponent<Rigidbody>().AddForce(playerWeapon.forward * explosiveTriggerMoveSpeed, ForceMode.Impulse);

        triggerObject.GetComponent<HolyExplosion>().Invoke("Explode", timedRange);


        this.PlayMuzzleFlash();
    }
}
