using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammo : MonoBehaviour
{
    //[SerializeField] int AmmoAmount = 10;
    // Start is called before the first fra;me update

    [SerializeField] AmmoSlot[] AmmoSlots;
    [SerializeField] TextMeshProUGUI AmmoNumber;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType TypeOfAmmo;
        public int AmmoAmount;
    }

    public int GetCurrentAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
        
    }
        

    public void ReduceAmmo(int reduceCount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount = GetAmmoSlot(ammoType).AmmoAmount - reduceCount;
        AmmoNumber.text = GetAmmoSlot(ammoType).AmmoAmount.ToString();
    }

    public void IncreaseAmmo(int increaseCount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount = GetAmmoSlot(ammoType).AmmoAmount + increaseCount;
        AmmoNumber.text = GetAmmoSlot(ammoType).AmmoAmount.ToString();
    }



    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        
        foreach(AmmoSlot slot in AmmoSlots)
        {
            if(slot.TypeOfAmmo == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
