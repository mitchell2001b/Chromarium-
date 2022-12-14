using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAmmoBehaivor : MonoBehaviour
{
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseFiringDelay;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float baseRange;
    [SerializeField] private GameObject weaponPoint;

 
    public abstract void AmmoShootEvent(float damageIncrease, float rangeIncrease);

    void Start()
    {
        //cam = GameObject.FindGameObjectWithTag("Player");
    }
    public float GetBaseDamage()
    {
        return baseDamage;
    }

    public GameObject GetPlayerWeaponPoint()
    {
        return weaponPoint;
    }

    public float GetBaseRange()
    {
        return baseRange;
    }

    public float GetBaseFiringDelay()
    {
        return baseFiringDelay;
    }

    public void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }





}
