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
    [Range(0, 1)]
    float weaknessModifier = .5f;
    public float hitPoints { get; private set; }
    public bool isDead { get; private set; } = false;

    [SerializeField] bool NoEraseAnimation = false;
    
    void Start()
    {
        hitPoints = maxHealth;
    }

    

    public void RecieveDamage(float damageAmount, AmmoType ammoTypeUsed)
    {
        if (elementalAffinity == AmmoType.Regular) hitPoints -= damageAmount;
        else if (elementalAffinity == ammoTypeUsed) hitPoints -= damageAmount * (1 - resistanceModifier);
        else
        {
            switch (elementalAffinity)
            {
                case AmmoType.Fire:
                    if (ammoTypeUsed == AmmoType.Ice) hitPoints -= damageAmount * (1 + weaknessModifier);
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Ice:
                    if (ammoTypeUsed == AmmoType.Fire) hitPoints -= damageAmount * (1 + weaknessModifier);
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Earth:
                    if (ammoTypeUsed == AmmoType.Wind) hitPoints -= damageAmount * (1 + weaknessModifier);
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Wind:
                    if (ammoTypeUsed == AmmoType.Earth) hitPoints -= damageAmount * (1 + weaknessModifier);
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Holy:
                    if (ammoTypeUsed == AmmoType.Void) hitPoints -= damageAmount * (1 + weaknessModifier);
                    else hitPoints -= damageAmount;
                    break;
                case AmmoType.Void:
                    if (ammoTypeUsed == AmmoType.Holy) hitPoints -= damageAmount * (1 + weaknessModifier);
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

        GameObject.Find("WaveSystem").GetComponent<EnemyWaveHandler>().UpdateCurrentWaveKillCount();
        // Disable NavMeshAgent
        GetComponent<NavMeshAgent>().enabled = false;

        // Trigger death animation when present
        if (GetComponent<Animator>() != null) GetComponent<Animator>().SetTrigger("die");

        // Disable components, depending on enemy AI script
        if (GetComponent<EnemyAI>() != null)
        {
            GetComponent<EnemyAI>().enabled = false;
            if (NoEraseAnimation)
            {
                GetComponent<EnemyAI>().DropMaterial();
                Destroy(gameObject);
            }
        }
        else if (GetComponent<EnemyAI_Ranged>() != null)
        {           
            GetComponent<EnemyAI_Ranged>().enabled = false;
            GetComponent<EnemyWeapon>().enabled = false;
            if(NoEraseAnimation)
            {
                GetComponent<EnemyAI_Ranged>().DropMaterial();
                Destroy(gameObject);
            }
        }
        else if (GetComponent<EnemyAI_Boss>() != null)
        {
            GetComponent<EnemyAI_Boss>().enabled = false;
        }
        else if(GetComponent<EnemyAiKamikaze>() != null)
        {
            GetComponent<EnemyAiKamikaze>().enabled = false;
            
            //Destroy(gameObject);
        }
        
    }
}
