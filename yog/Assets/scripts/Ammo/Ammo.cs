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

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType typeOfAmmo;
        public int ammoAmount;
    }

    
    private void SetCurrentAmmoSlot(AmmoType ammoType)
    {
        currentAmmoSlot = GetAmmoSlot(ammoType);
    }
    public int GetCurrentAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;       
    }

    public AmmoType GetCurrentAmmoType()
    {
        return currentAmmoSlot.typeOfAmmo;
    }
    

    public void ReduceAmmo(int reduceCount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount = GetAmmoSlot(ammoType).ammoAmount - reduceCount;
        ammoNumber.text = GetAmmoSlot(ammoType).ammoAmount.ToString();
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
        SetCurrentAmmoSlot(AmmoType.Regular);
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
            SetCurrentAmmoSlot(AmmoType.Fire);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SetCurrentAmmoSlot(AmmoType.Regular);
        }
    }
}
