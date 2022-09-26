using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] GameObject cam;
    [SerializeField] float damage = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoHandler;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI AmmoNumber;

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

   
    IEnumerator Shoot()
    {
        if (ammoHandler.GetCurrentAmmoAmount(ammoHandler.GetCurrentAmmoType()) > 0)
        {
            PlayMuzzleFlash();
            ammoHandler.ReduceAmmo(1, ammoHandler.GetCurrentAmmoType());
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                //EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                Transform target = null;
                Debug.Log(hit.collider.gameObject.name);
                CreateHitImpact(hit);

                if (target == null)
                {

                    yield return new WaitForSeconds(timeBetweenShots);
                    CanShoot = true;
                }
                else
                {
                    //target.TakeDamage(Damage);
                }




               
            }
            else
            {
                yield return new WaitForSeconds(timeBetweenShots);
                CanShoot = true;
            }
        }

        yield return new WaitForSeconds(timeBetweenShots);
        CanShoot = true;
       
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
