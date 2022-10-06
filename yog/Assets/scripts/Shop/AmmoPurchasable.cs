using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoPurchasable : MonoBehaviour
{
    public AmmoType ammoType;
    public int ammoCount = 10;
    public int cost = 10;

    [SerializeField]
    TextMeshProUGUI ammoTitleText;

    [SerializeField]
    Button button;

    [SerializeField]
    TextMeshProUGUI costText;
    PlayerAttributes playerAttributes;
    Ammo ammoHandler;

    private void Start() {
        playerAttributes = FindObjectOfType<PlayerAttributes>();
        ammoHandler = FindObjectOfType<Ammo>();
        ammoTitleText.text = ammoType.ToString() + " x" + ammoCount;
        costText.text = cost + "$";
    }

    void Update()
    {
        if (playerAttributes.HasEnoughCurrency(cost)) button.image.color = Color.green;
        else button.image.color = Color.red;
    }

    public void Buy()
    {
        if (!playerAttributes.HasEnoughCurrency(cost)) return;
        playerAttributes.RemoveCurrency(cost);
        ammoHandler.IncreaseAmmo(ammoCount, ammoType);
    }
}
