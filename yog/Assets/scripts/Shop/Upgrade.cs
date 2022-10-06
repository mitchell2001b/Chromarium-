using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    string upgradeTitle;

    [SerializeField]
    UpgradeVariants upgradeVariant;

    [SerializeField]
    TextMeshProUGUI upgradeTitleText;

    [SerializeField]
    float value;

    [SerializeField]
    int cost;

    [SerializeField]
    TextMeshProUGUI costText;

    [SerializeField]
    Button button;

    PlayerAttributes playerAttributes;

    private void Start() {
        playerAttributes = FindObjectOfType<PlayerAttributes>();
        if(upgradeVariant == UpgradeVariants.maxHP) upgradeTitleText.text = upgradeTitle + " - " + value.ToString() + " HP";
        else if (upgradeVariant == UpgradeVariants.critChance) upgradeTitleText.text = upgradeTitle + " - " + value.ToString() + "%";
        else upgradeTitleText.text = upgradeTitle + " - " + (Mathf.RoundToInt(value * 100)).ToString() + "%";
        costText.text = cost.ToString() + "$";
    }

    private void Update() {
        if (playerAttributes.HasEnoughCurrency(cost)) button.image.color = Color.green;
        else button.image.color = Color.red;
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
