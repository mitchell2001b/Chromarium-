using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    UpgradeSection upgradeSection;

    private void OnEnable() {
        upgradeSection.RefreshUpgrades();
    }
}
