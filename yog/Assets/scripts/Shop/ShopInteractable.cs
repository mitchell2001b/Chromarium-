using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShopInteractable : MonoBehaviour
{
    [SerializeField] Canvas shopCanvas;
    [SerializeField] Canvas attributeCanvas;
    [SerializeField] Canvas healthAmmoCanvas;
    [SerializeField] Canvas waveCanvas;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        Debug.Log("Hi");
        Time.timeScale = 0;
        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        shopCanvas.gameObject.SetActive(true);
        attributeCanvas.gameObject.SetActive(false);
        healthAmmoCanvas.gameObject.SetActive(false);
        waveCanvas.gameObject.SetActive(false);
    }

    private void EnableBoxCollider()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}
