using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] GameObject cam;
    [SerializeField] float Damage = 100f;
    [SerializeField] ParticleSystem MuzzleFlash;
    [SerializeField] GameObject HitEffect;
    [SerializeField] LayerMask mask;
    [SerializeField] Ammo AmmoSlot;
    [SerializeField] AmmoType TypeOfAmmo;
    [SerializeField] float TimeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI AmmoNumber;

    public bool CanShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        AmmoNumber.text = AmmoSlot.GetCurrentAmmoAmount(TypeOfAmmo).ToString();
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
       GameObject impact = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
       Destroy(impact, 1);
    }

   
    IEnumerator Shoot()
    {
        if (AmmoSlot.GetCurrentAmmoAmount(TypeOfAmmo) > 0)
        {
            PlayMuzzleFlash();
            AmmoSlot.ReduceAmmo(1, TypeOfAmmo);
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                Debug.Log(hit.collider.gameObject.name);
                CreateHitImpact(hit);

                if (target == null)
                {

                    yield return new WaitForSeconds(TimeBetweenShots);
                    CanShoot = true;
                }
                else
                {
                    target.TakeDamage(Damage);
                }




               
            }
            else
            {
                yield return new WaitForSeconds(TimeBetweenShots);
                CanShoot = true;
            }
        }

        yield return new WaitForSeconds(TimeBetweenShots);
        CanShoot = true;
       
    }

    private void PlayMuzzleFlash()
    {
        MuzzleFlash.Play();
    }
}
