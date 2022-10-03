using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAirBehavior : BaseAmmoBehaivor
{
    public override void AmmoShootEvent(float damageIncrease, float rangeIncrease)
    {
        RaycastHit hit;
        if (Physics.Raycast(this.GetPlayerCam().transform.position, this.GetPlayerCam().transform.forward, out hit, (this.GetBaseRange() + rangeIncrease)))
        {
            Debug.Log("joehoe");
        }
        this.PlayMuzzleFlash();
    }
}
