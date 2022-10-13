using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] GameObject victoryPrefab;
    [SerializeField] List<Canvas> canviToDisable;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        PauseScreenHandler.Pause();
        victoryPrefab.SetActive(true);
        foreach (Canvas canvas in canviToDisable)
        {
            canvas.enabled = false;
        }
    }

    public void ActivateShip()
    {
        GetComponent<Animator>().SetTrigger("Activate");
    }
}
