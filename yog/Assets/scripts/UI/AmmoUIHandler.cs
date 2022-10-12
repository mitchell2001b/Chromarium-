using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoNumber;
    [SerializeField] Ammo ammoInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        ChangeAmmoNumberUI(ammoInventory.GetCurrentAmmoAmount(ammoInventory.GetCurrentAmmoType()).ToString());
        //Debug.Log(ammoInventory.GetCurrentAmmoAmount(ammoInventory.GetCurrentAmmoType()).ToString());
    }

    public void ChangeAmmoNumberUI(string newText)
    {        
        ammoNumber.text = newText;
    }
}
