using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour, IAttackable
{
    [SerializeField] private float maxHealth = 100f;
    public float health { get; set; }

    [SerializeField] TextMeshProUGUI HealthTextNumber;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateUIHealth(health.ToString() + "/" + maxHealth.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecieveDamage(float damageCount)
    {
        health = health - damageCount;
        if (health < 0 || health == 0)
        {           
            GetComponent<DeathHandler>().HandleDeath();
        }
        UpdateUIHealth(health.ToString() + "/" + maxHealth.ToString());
    }

    public void ChangeMaxHealth(float newMaxHealth)
    {
        maxHealth = newMaxHealth;
        HealPlayer(maxHealth);
    }

    public void IncreaseMaxHealth(float extraHealth)
    {
        maxHealth += extraHealth;
        HealPlayer(maxHealth);
    }

    public void ResetMaxHealth()
    {
        maxHealth = 100f;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void HealPlayer(float HealAmount)
    {
        health += HealAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateUIHealth(health.ToString() + "/" + maxHealth.ToString());

    }

    private void UpdateUIHealth(string newText)
    {
        HealthTextNumber.text = newText;
    }
}
