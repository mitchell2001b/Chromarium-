using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int hitPoints { get; private set; }
    public bool isDead { get; private set; } = false;

    void Start()
    {
        hitPoints = maxHealth;
    }

    private void Update()
    {
        hitPoints--;
        if(hitPoints <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        hitPoints -= damageAmount;

        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        GetComponent<NavMeshAgent>().enabled = false;
        // Disable Collider
        //GetComponent<Collider>().enabled = false;

        // Trigger death animation when present
        if (GetComponent<Animator>() != null) GetComponent<Animator>().SetTrigger("die");

        // Disable components, depending on enemy AI script
        if (GetComponent<EnemyAI>() != null)
        {
            GetComponent<EnemyAI>().enabled = false;
        }
        else if (GetComponent<EnemyAI_Ranged>() != null)
        {
            GetComponent<EnemyAI_Ranged>().enabled = false;
        }
        else if (GetComponent<EnemyAI_Boss>() != null)
        {
            GetComponent<EnemyAI_Boss>().enabled = false;
        }
    }
}
