using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSection : MonoBehaviour
{
    [SerializeField]
    List<GameObject> upgradePrefabs;

    
    void Start()
    {
        RefreshUpgrades();
    }

    public void RefreshUpgrades()
    {
        foreach (Transform upgrade in gameObject.transform)
        {
            Destroy(upgrade.gameObject);
        }
        List<UpgradeVariants> pickedUpgradeVariants = new List<UpgradeVariants>();
        GameObject pickedUpgrade;
        while (pickedUpgradeVariants.Count < 3)
        {
            pickedUpgrade = upgradePrefabs[Random.Range(0, upgradePrefabs.Count)];
            if(!pickedUpgradeVariants.Contains(pickedUpgrade.GetComponent<Upgrade>().GetUpgradeType()))
            {
                pickedUpgradeVariants.Add(pickedUpgrade.GetComponent<Upgrade>().GetUpgradeType());
                Instantiate(pickedUpgrade, gameObject.transform);
            }
        }
    }
}
