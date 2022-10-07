using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBehaviorHandler : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetAmmoShootCooldown(AmmoType ammoType)
    {
        switch (ammoType)
        {

            case AmmoType.Void:
                return GetComponent<AmmoVoidBehavior>().GetBaseFiringDelay();
                
            case AmmoType.Fire:
                return GetComponent<AmmoFireBehavior>().GetBaseFiringDelay();               

            case AmmoType.Regular:
                return GetComponent<AmmoRegularBehavior>().GetBaseFiringDelay();

            case AmmoType.Wind:
                return GetComponent<AmmoAirBehavior>().GetBaseFiringDelay();

            case AmmoType.Ice:
                return GetComponent<AmmoIceBehavior>().GetBaseFiringDelay();
                

            case AmmoType.Earth:
                return GetComponent<AmmoEarthBehavior>().GetBaseFiringDelay();

            case AmmoType.Holy:
                return GetComponent<AmmoHolyBehavior>().GetBaseFiringDelay();

        }

        //nothing found
        throw new System.NullReferenceException("no matching ammotype has been found");
    }

    public void AmmoTypeBehaviorShootEvent(AmmoType ammoType, float damageIncrease, float rangeIncrease, float aoeIncrease)
    {
        switch(ammoType)
        {

            case AmmoType.Void:
                GetComponent<AmmoVoidBehavior>().AmmoShootEvent(damageIncrease, aoeIncrease);
                break;

            case AmmoType.Fire:
                GetComponent<AmmoFireBehavior>().AmmoShootEvent(damageIncrease, rangeIncrease);
                break;

            case AmmoType.Regular:
                GetComponent<AmmoRegularBehavior>().AmmoShootEvent(damageIncrease, rangeIncrease);
                break;
            case AmmoType.Earth:
                GetComponent<AmmoEarthBehavior>().AmmoShootEvent(damageIncrease, rangeIncrease);
                break;

            case AmmoType.Ice:
                GetComponent<AmmoIceBehavior>().AmmoShootEvent(damageIncrease, rangeIncrease);
                break;

            case AmmoType.Holy:
                GetComponent<AmmoHolyBehavior>().AmmoShootEvent(damageIncrease, aoeIncrease);
                break;
            case AmmoType.Wind:
                GetComponent<AmmoAirBehavior>().AmmoShootEvent(damageIncrease, rangeIncrease);
                break;
        }
    }


}
