using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

public enum UpgradeVariants
{
    [Description("Damage")]
    damage,
    [Description("Attack Speed")]
    attackSpeed,
    [Description("Crit Chance")]
    critChance,
    [Description("Crit Modifier")]
    critModifier,
    [Description("Extra HP")]
    maxHP,
    [Description("AoE Range")]
    aoeRange
} 
