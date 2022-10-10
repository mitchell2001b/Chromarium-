using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyNumber;
    PlayerAttributes attributes;
    private void Start() {
        attributes = FindObjectOfType<PlayerAttributes>();
    }
    private void Update() {
        currencyNumber.text = attributes.GetCurrentCurrency() + "$";
    }
    private void OnDisable() {
        Time.timeScale = 1;
        FindObjectOfType<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
