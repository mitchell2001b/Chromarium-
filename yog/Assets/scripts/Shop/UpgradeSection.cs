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
        Instantiate(upgradePrefabs[Random.Range(0, upgradePrefabs.Count)], gameObject.transform);
        Instantiate(upgradePrefabs[Random.Range(0, upgradePrefabs.Count)], gameObject.transform);
        Instantiate(upgradePrefabs[Random.Range(0, upgradePrefabs.Count)], gameObject.transform);
    }
}
