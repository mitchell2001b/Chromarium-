using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    //[SerializeField] int AmmoAmount = 10;
    // Start is called before the first fra;me update

    [SerializeField] AmmoSlot[] ammoSlots;
    [SerializeField] TextMeshProUGUI ammoNumber;
    [SerializeField] AmmoSlot currentAmmoSlot;

    
    [SerializeField] AmmoIndicatorAnimationHandler indicatorHandler;
    [SerializeField] GunAnimationHandler gunAnimationHandler;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType typeOfAmmo;
        public int ammoAmount;       
    }

    
    private void SetCurrentAmmoSlot(AmmoType ammoType)
    {
        indicatorHandler.ChangeIndicatorMaterial(ammoType);
        currentAmmoSlot = GetAmmoSlot(ammoType);
        if(this.gameObject.activeSelf)
        {
            gunAnimationHandler.ChangeGunAnimation(ammoType);
        }
        
        

        //ammoNumber.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
        
    }
    public void WeaponChangeComplete()
    {
        BroadcastMessage("WeaponCanShootActive");
    }
    public int GetCurrentAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;       
    }
    public int GetCurrentAmmoIndex(AmmoType ammotype)
    {
        int index = 0;
        for (int i = 0; i < ammoSlots.Length; i++)
        {
            if (ammoSlots[i].typeOfAmmo == ammotype)
            {
                index = i;
                break;
            }
        }

        return index;
    }
   
    public AmmoType GetCurrentAmmoType()
    {
        return currentAmmoSlot.typeOfAmmo;
    }
    

    public void ReduceAmmo(int reduceCount, AmmoType ammoType)
    {
        gunAnimationHandler.TriggerShootAnimation();
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount - reduceCount;
        //ammoNumber.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
    }

    public void IncreaseAmmo(int increaseCount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount + increaseCount;
        ammoNumber.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
    }

   

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        
        foreach(AmmoSlot slot in ammoSlots)
        {
            if(slot.typeOfAmmo == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
    void Start()
    {
       
        //SetCurrentAmmoSlot(AmmoType.Regular);
               
    }

    // Update is called once per frame
    void Update()
    {
        ProcessScrollInput();
    }

    private void ProcessScrollInput()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (GetCurrentAmmoIndex(GetCurrentAmmoType()) >= ammoSlots.Length - 1)
            {
                SetCurrentAmmoSlot(ammoSlots[0].typeOfAmmo);
            }
            else
            {               
                SetCurrentAmmoSlot(ammoSlots[GetCurrentAmmoIndex(GetCurrentAmmoType()) + 1].typeOfAmmo);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetCurrentAmmoIndex(GetCurrentAmmoType()) <= 0)
            {
                SetCurrentAmmoSlot(ammoSlots[ammoSlots.Length - 1].typeOfAmmo);
            }
            else
            {                
                SetCurrentAmmoSlot(ammoSlots[GetCurrentAmmoIndex(GetCurrentAmmoType()) - 1].typeOfAmmo);
            }
        }
    }
}
