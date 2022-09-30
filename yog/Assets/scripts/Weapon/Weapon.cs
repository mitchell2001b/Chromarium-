using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    //[SerializeField] float range = 100f;
    [SerializeField] GameObject cam;
    [SerializeField] float damageIncrease;
    [SerializeField] float rangeIncrease;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoHandler;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI AmmoNumber;
    [SerializeField] GameObject ammoTypeBehaviorManager;

    public bool CanShoot = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        AmmoNumber.text = ammoHandler.GetCurrentAmmoAmount(ammoHandler.GetCurrentAmmoType()).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1") && CanShoot)
        {
            StartCoroutine(Shoot());
            CanShoot = false;
            //Shoot();
        }
    }

    public void CreateHitImpact(RaycastHit hit)
    {
       GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 1);
    }

    void WeaponCanShootActive()
    {
        CanShoot = true;
    }

    IEnumerator Shoot()
    {
        if (ammoHandler.GetCurrentAmmoAmount(ammoHandler.GetCurrentAmmoType()) > 0)
        {
            ammoTypeBehaviorManager.GetComponent<AmmoBehaviorHandler>().AmmoTypeBehaviorShootEvent(ammoHandler.GetCurrentAmmoType(), damageIncrease, rangeIncrease);
            ammoHandler.ReduceAmmo(1, ammoHandler.GetCurrentAmmoType());
            yield return new WaitForSeconds(ammoTypeBehaviorManager.GetComponent<AmmoBehaviorHandler>().GetAmmoShootCooldown(ammoHandler.GetCurrentAmmoType()));
            CanShoot = true;

            /*RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100))
            {
                //EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                Transform target = null;
                Debug.Log(hit.collider.gameObject.name);
                CreateHitImpact(hit);

                if (target == null)
                {

                    yield return new WaitForSeconds(ammoTypeBehaviorManager.GetComponent<AmmoBehaviorHandler>().GetAmmoShootCooldown(ammoHandler.GetCurrentAmmoType()));
                    CanShoot = true;
                }
                else
                {
                    //target.TakeDamage(Damage);
                }




               
            }
            else
            {
                yield return new WaitForSeconds(ammoTypeBehaviorManager.GetComponent<AmmoBehaviorHandler>().GetAmmoShootCooldown(ammoHandler.GetCurrentAmmoType()));
                CanShoot = true;
            }*/
        }

        yield return new WaitForSeconds(ammoTypeBehaviorManager.GetComponent<AmmoBehaviorHandler>().GetAmmoShootCooldown(ammoHandler.GetCurrentAmmoType()));
        CanShoot = true;
       
    }
}
