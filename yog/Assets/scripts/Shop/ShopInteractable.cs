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
        PauseScreenHandler.Pause();
        shopCanvas.gameObject.SetActive(true);
        attributeCanvas.gameObject.SetActive(false);
        healthAmmoCanvas.gameObject.SetActive(false);
        waveCanvas.gameObject.SetActive(false);
    }

    public void SpawnShop()
    {
        GetComponent<Animator>().SetTrigger("Arrive");
    }
}
