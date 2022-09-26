using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public float health { get; }
    public void RecieveDamage(float damageAmountToRecieve);
    
}
