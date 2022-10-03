using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{

    [SerializeField] int AmmoAmount = 5;
    [SerializeField] AmmoType TypeOfAmmo = AmmoType.Regular;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Ammo ammoHandler = FindObjectOfType<Ammo>();
            ammoHandler.IncreaseAmmo(AmmoAmount, TypeOfAmmo);
            Destroy(gameObject);
        }
    }
}
