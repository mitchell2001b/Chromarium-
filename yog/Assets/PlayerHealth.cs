using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float MaxHealth = 100f;
    [SerializeField] float Heallth = 100f;
    [SerializeField] TextMeshProUGUI HealthTextNumber;
    // Start is called before the first frame update
    void Start()
    {
        UpdateUIHealth(Heallth.ToString() + "/" + MaxHealth.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageCount)
    {
        Heallth = Heallth - damageCount;
        if (Heallth < 0 || Heallth == 0)
        {           
            GetComponent<DeathHandler>().HandleDeath();
        }
        UpdateUIHealth(Heallth.ToString() + "/" + MaxHealth.ToString());
    }

    public void ChangeMaxHealth(float newMaxHealthToAddOnTopOfCurrentMaxHealth)
    {
        MaxHealth = MaxHealth + newMaxHealthToAddOnTopOfCurrentMaxHealth;
        HealPlayer(MaxHealth);
    }

    public void ResetMaxHealth()
    {
        MaxHealth = 100;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public void HealPlayer(float HealAmount)
    {
        Heallth = Heallth + HealAmount;
        if(Heallth > MaxHealth)
        {
            Heallth = MaxHealth;
        }

        UpdateUIHealth(Heallth.ToString() + "/" + MaxHealth.ToString());

    }

    private void UpdateUIHealth(string newText)
    {
        HealthTextNumber.text = newText;
    }
}
