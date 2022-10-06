using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSection : MonoBehaviour
{
    [SerializeField]
    GameObject ammoPrefab;

    private void Start() {
        FillAmmoList();
    }

    private void FillAmmoList()
    {
        CreateAmmoPurchasable(AmmoType.Fire, 100, 10);
        CreateAmmoPurchasable(AmmoType.Ice, 10, 10);
        CreateAmmoPurchasable(AmmoType.Earth, 10, 10);
        CreateAmmoPurchasable(AmmoType.Wind, 20, 10);
        CreateAmmoPurchasable(AmmoType.Holy, 5, 10);
        CreateAmmoPurchasable(AmmoType.Void, 5, 10);
    }

    private void CreateAmmoPurchasable(AmmoType ammoType, int ammoAmount, int cost)
    {
        GameObject newAmmoPurchasable = Instantiate(ammoPrefab, gameObject.transform);
        newAmmoPurchasable.GetComponent<AmmoPurchasable>().ammoType = ammoType;
        newAmmoPurchasable.GetComponent<AmmoPurchasable>().ammoCount = ammoAmount;
        newAmmoPurchasable.GetComponent<AmmoPurchasable>().cost = cost;
    }
}
