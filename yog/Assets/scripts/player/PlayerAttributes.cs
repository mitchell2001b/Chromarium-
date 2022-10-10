using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
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
    float baseMovementSpeed;
    [SerializeField] TextMeshProUGUI movementSpeedTextNumber;
    float movementSpeedModifier = 1f;
    float aoeRangeModifier = 1f;
    [SerializeField] TextMeshProUGUI aoeModifierTextNumber;
    
    private void Start() {
        currencyTextNumber.text = currency.ToString() + "$";
        damageModifierTextNumber.text = Mathf.RoundToInt(damageModifier * 100).ToString() + "%";
        attackSpeedModifierTextNumber.text = Mathf.RoundToInt(attackSpeedModifier * 100).ToString() + "%";
        critChanceTextNumber.text = critChance.ToString() + "%";
        critModifierTextNumber.text = Mathf.RoundToInt(critModifier * 100).ToString() + "%";
        rangeModifierTextNumber.text = Mathf.RoundToInt(rangeModifier * 100).ToString() + "%";
        aoeModifierTextNumber.text = Mathf.RoundToInt(aoeRangeModifier * 100).ToString() + "%";
        baseMovementSpeed = GetComponent<FirstPersonController>().GetMovementSpeed();
        movementSpeedTextNumber.text = (Mathf.Round(baseMovementSpeed * movementSpeedModifier * 100) / 100).ToString() + " m/s";
    }
    public bool HasEnoughCurrency(int requiredAmount)
    {
        return currency >= requiredAmount;
    }

    public int GetCurrentCurrency()
    {
        return currency;
    }

    public void IncreaseCurrency(int extraCurrency)
    {
        currency += extraCurrency;
        currencyTextNumber.text = currency.ToString() + "$";
    }

    public void RemoveCurrency(int currencyLoss)
    {
        currency -= currencyLoss;
        currencyTextNumber.text = currency.ToString() + "$";
    }

    public void IncreaseDamageModifier(float modifierIncrease)
    {
        damageModifier += modifierIncrease;
        damageModifierTextNumber.text = Mathf.RoundToInt(damageModifier * 100).ToString() + "%";
    }

    public float GetDamageModifier()
    {
        return damageModifier;
    }

    public void IncreaseAttackSpeed(float modifierIncrease)
    {
        attackSpeedModifier += modifierIncrease;
        attackSpeedModifierTextNumber.text = Mathf.RoundToInt(attackSpeedModifier * 100).ToString() + "%";
    }

    public float GetAttackSpeedModifier()
    {
        return attackSpeedModifier;
    }

    public int GetCritChance()
    {
        return critChance;
    }

    public void IncreaseCritChance(int extraCritChance)
    {
        critChance += extraCritChance;
        critChanceTextNumber.text = critChance.ToString() + "%";
    }

    public void IncreaseCritModifier(float modifierIncrease)
    {
        critModifier += modifierIncrease;
        critModifierTextNumber.text = Mathf.RoundToInt(critModifier * 100).ToString() + "%";
    }

    public float GetCritModifier()
    {
        return critModifier;
    }

    public void IncreaseRangeModifier(float modifierIncrease)
    {
        rangeModifier += modifierIncrease;
        rangeModifierTextNumber.text = Mathf.RoundToInt(rangeModifier * 100).ToString() + "%";
    }

    public float GetRangeModifier()
    {
        return rangeModifier;
    }

    public void IncreaseMovementSpeedModifier(float modifierIncrease)
    {
        movementSpeedModifier += modifierIncrease;
        movementSpeedTextNumber.text = (Mathf.Round(baseMovementSpeed * movementSpeedModifier * 100) / 100).ToString() + " m/s";
        GetComponent<FirstPersonController>().ChangeMovementSpeeds(baseMovementSpeed * movementSpeedModifier);
    }

    public float GetMovementSpeedModifier()
    {
        return movementSpeedModifier;
    }

    public void IncreaseAoERangeModifier(float modifierIncrease)
    {
        aoeRangeModifier += modifierIncrease;
        aoeModifierTextNumber.text = Mathf.RoundToInt(aoeRangeModifier * 100).ToString() + "%";
    }

    public float GetAoERangeModifier()
    {
        return aoeRangeModifier;
    }
}
