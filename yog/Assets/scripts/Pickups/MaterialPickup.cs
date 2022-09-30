using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPickup : MonoBehaviour
{
    [SerializeField] int materialWorth = 5;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerAttributes>().IncreaseXp(materialWorth);
            Destroy(gameObject);
        }  
    }
}
