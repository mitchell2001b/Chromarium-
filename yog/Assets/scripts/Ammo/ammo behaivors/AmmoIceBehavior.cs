using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIceBehavior : BaseAmmoBehaivor
{
    //[SerializeField] TrailRenderer iceTrail;
    //[SerializeField] Transform weaponPoint;
    [SerializeField] GameObject iceTrailEffect;
    [SerializeField] LayerMask mask;
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        RaycastHit hit;
        GameObject triggerObject = Instantiate(iceTrailEffect, this.GetPlayerWeaponPoint().transform.position, this.GetPlayerWeaponPoint().transform.rotation);
        triggerObject.GetComponent<Rigidbody>().AddForce(this.GetPlayerWeaponPoint().transform.forward * 10, ForceMode.Impulse);
        Destroy(triggerObject, 1);

        if (Physics.Raycast(this.GetPlayerWeaponPoint().transform.position, this.GetPlayerWeaponPoint().transform.forward, out hit, (this.GetBaseRange() * rangeIncrease), ~mask))
        {
            if(hit.transform.gameObject.tag == "Enemy")
            {
                EnemyHealth health = hit.collider.transform.gameObject.GetComponent<EnemyHealth>();
                if (health == null)
                {
                    return;
                }

                health.RecieveDamage((this.GetBaseDamage() * damageIncrease), AmmoType.Ice);
            }
            
            //TrailRenderer trail = Instantiate(iceTrail, weaponPoint.position, Quaternion.identity);
            //StartCoroutine(SpawnTrail(trail, hit));
        }


        this.PlayMuzzleFlash();
    }

    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while(time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }

        trail.transform.position = hit.point;

        Destroy(trail.gameObject, trail.time);
    }
}
