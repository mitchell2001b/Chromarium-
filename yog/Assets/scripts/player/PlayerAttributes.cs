using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerAttributes : MonoBehaviour
{
    int currency = 0;
    [SerializeField] TextMeshProUGUI currencyTextNumber;
    float damageModifier = 1f;
    [SerializeField] TextMeshProUGUI damageModifierTextNumber;
    float attackSpeedModifier = 1f;
    [SerializeField] TextMeshProUGUI attackSpeedModifierTextNumber;
    int critChance = 0;
    [SerializeField] TextMeshProUGUI critChanceTextNumber;
    float critModifier = 2f;
    [SerializeField] TextMeshProUGUI critModifierTextNumber;
    float rangeModifier = 1f;
    [SerializeField] TextMeshProUGUI rangeModifierTextNumber;
    //float baseMovementSpeed;
    //float movementSpeedModifier = 1f;
    float aoeRangeModifier = 1f;
    [SerializeField] TextMeshProUGUI aoeModifierTextNumber;
    
    private void Start() {
        currencyTextNumber.text = currency.ToString();
        damageModifierTextNumber.text = damageModifier.ToString();
        attackSpeedModifierTextNumber.text = attackSpeedModifier.ToString();
        critChanceTextNumber.text = critChance.ToString();
        critModifierTextNumber.text = critModifier.ToString();
        rangeModifierTextNumber.text = rangeModifier.ToString();
        aoeModifierTextNumber.text = aoeRangeModifier.ToString();
    }
    public bool HasEnoughCurrency(int requiredAmount)
    {
        return currency >= requiredAmount;
    }

    public void IncreaseCurrency(int extraCurrency)
    {
        currency += extraCurrency;
        currencyTextNumber.text = currency.ToString();
    }

    public void RemoveCurrency(int currencyLoss)
    {
        currency -= currencyLoss;
        currencyTextNumber.text = currency.ToString();
    }

    public void IncreaseDamageModifier(float modifierIncrease)
    {
        damageModifier += modifierIncrease;
        damageModifierTextNumber.text = damageModifier.ToString();
    }

    public void DecreaseDamageModifier(float modifierDecrease)
    {
        damageModifier -= modifierDecrease;
        damageModifierTextNumber.text = damageModifier.ToString();
    }

    public void IncreaseAttackSpeed(float modifierIncrease)
    {
        attackSpeedModifier += modifierIncrease;
        attackSpeedModifierTextNumber.text = attackSpeedModifier.ToString();
    }

    public void DecreaseAttackSpeed(float modifierDecrease)
    {
        attackSpeedModifier -= modifierDecrease;
        attackSpeedModifierTextNumber.text = attackSpeedModifier.ToString();
    }

    public int GetCritChance()
    {
        return critChance;
    }

    public void IncreaseCritChance(int extraCritChance)
    {
        critChance += extraCritChance;
        critChanceTextNumber.text = critChance.ToString();
    }

    public void DecreaseCritChance(int critChanceLoss)
    {
        critChance -= critChanceLoss;
        critChanceTextNumber.text = critChance.ToString();
    }

    public void IncreaseCritModifier(float modifierIncrease)
    {
        critModifier += modifierIncrease;
        critModifierTextNumber.text = critModifier.ToString();
    }

    public void DecreaseCritModifier(float modifierDecrease)
    {
        critModifier -= modifierDecrease;
        critModifierTextNumber.text = critModifier.ToString();
    }

    public void IncreaseRangeModifier(float modifierIncrease)
    {
        rangeModifier += modifierIncrease;
        rangeModifierTextNumber.text = rangeModifier.ToString();
    }

    public void DecreaseRangeModifier(float modifierDecrease)
    {
        rangeModifier -= modifierDecrease;
        rangeModifierTextNumber.text = rangeModifier.ToString();
    }

    // public void IncreaseMovementSpeedModifier(float modifierIncrease)
    // {
    //     movementSpeedModifier += modifierIncrease;
    // }

    // public void DecreaseMovementSpeedModifier(float modifierDecrease)
    // {
    //     movementSpeedModifier -= modifierDecrease;
    // }

    public void IncreaseAoERangeModifier(float modifierIncrease)
    {
        aoeRangeModifier += modifierIncrease;
        aoeModifierTextNumber.text = aoeRangeModifier.ToString();
    }

    public void DecreaseAoERangeModifier(float modifierDecrease)
    {
        aoeRangeModifier -= modifierDecrease;
        aoeModifierTextNumber.text = aoeRangeModifier.ToString();
    }
}
