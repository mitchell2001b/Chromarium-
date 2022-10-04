using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    UpgradeVariants upgradeVariant;

    [SerializeField]
    TextMeshProUGUI upgradeTitle;

    [SerializeField]
    float value;

    [SerializeField]
    int cost;

    [SerializeField]
    TextMeshProUGUI costText;

    PlayerAttributes playerAttributes;

    private void Start() {
        playerAttributes = FindObjectOfType<PlayerAttributes>();
        upgradeTitle.text = upgradeVariant.ToString() + " - " + (Mathf.RoundToInt(value * 100)).ToString() + "%";
        costText.text = cost.ToString() + "$";
    }

    public void Buy()
    {
        if (!playerAttributes.HasEnoughCurrency(cost)) return;
        playerAttributes.RemoveCurrency(cost);
        switch (upgradeVariant)
        {
            case UpgradeVariants.damage:
                playerAttributes.IncreaseDamageModifier(value);
                break;
            case UpgradeVariants.attackSpeed:
                playerAttributes.IncreaseAttackSpeed(value);
                break;
            case UpgradeVariants.critChance:
                playerAttributes.IncreaseCritChance((int)value);
                break;
            case UpgradeVariants.critModifier:
                playerAttributes.IncreaseCritModifier(value);
                break;
            case UpgradeVariants.maxHP:
                FindObjectOfType<PlayerHealth>().IncreaseMaxHealth(value);
                break;
            case UpgradeVariants.aoeRange:
                playerAttributes.IncreaseAoERangeModifier(value);
                break;
            default:
                Debug.Log("Something went wrong...");
                break;
        }
    }
}
