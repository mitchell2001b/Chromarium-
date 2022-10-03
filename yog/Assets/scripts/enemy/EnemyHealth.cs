using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    [SerializeField]
    AmmoType elementalAffinity = AmmoType.Regular;

    [SerializeField]
    [Range(0, 1)]
    float resistanceModifier = .5f;

    [SerializeField]
    [Range(1, 2)]
    float weaknessModifier = 1.5f;
    public float hitPoints { get; private set; }
    public bool isDead { get; private set; } = false;

    void Start()
    {
        hitPoints = maxHealth;
    }

    public void RecieveDamage(float damageAmount, AmmoType ammoTypeUsed)
    {
        if (elementalAffinity == AmmoType.Regular) hitPoints -= damageAmount;
        else if (elementalAffinity == ammoTypeUsed) hitPoints -= damageAmount * resistanceModifier;
        else
        {
            switch (elementalAffinity)
            {
                case AmmoType.Fire:
                    if (ammoTypeUsed == AmmoType.Ice) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Ice:
                    if (ammoTypeUsed == AmmoType.Fire) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Earth:
                    if (ammoTypeUsed == AmmoType.Wind) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Wind:
                    if (ammoTypeUsed == AmmoType.Earth) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Holy:
                    if (ammoTypeUsed == AmmoType.Void) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Void:
                    if (ammoTypeUsed == AmmoType.Holy) hitPoints -= damageAmount * weaknessModifier;
                    else hitPoints -= damageAmount;
                    break;
                default:
                    hitPoints -= damageAmount;
                    Debug.Log("Couldn't find elemental relation");
                    break;
            }
        }

        if(hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        // Disable NavMeshAgent
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
