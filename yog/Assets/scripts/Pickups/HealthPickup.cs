using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healingValue = 25;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerHealth>().HealPlayer(healingValue);
            Destroy(gameObject);
        }  
    }
}
