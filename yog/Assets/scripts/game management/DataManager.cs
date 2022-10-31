using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    int currency = 0;
    float maxHealth = 100;
    float damageModifier = 1f;
    float attackSpeedModifier = 1f;
    int critChance = 0;
    float critModifier = 1f;
    float rangeModifier = 1f;
    float aoeRangeModifier = 1f;
    float baseMovementSpeed = 5f;
    float movementSpeedModifier = 1f;
    List<PlanetType> completedPlanets = new List<PlanetType>();
    int planetsToComplete = 3;

    public static DataManager instance { get; private set; }
    
    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);       
    }

    public void SaveData(   int currentCurrency,
                            float currentMaxHealth,
                            float currentDamageModifier,
                            float currentAttackSpeedModifier,
                            int currentCritChance,
                            float currentCritModifier,
                            float currentRangeModifier,
                            float currentAoERangeModifier,
                            float currentMovementSpeedModifier)
    {
        currency = currentCurrency;
        maxHealth = currentMaxHealth;
        damageModifier = currentDamageModifier;
        attackSpeedModifier = currentAttackSpeedModifier;
        critChance = currentCritChance;
        critModifier = currentCritModifier;
        rangeModifier = currentRangeModifier;
        aoeRangeModifier = currentAoERangeModifier;
        movementSpeedModifier = currentMovementSpeedModifier;
    }

    public void LoadData(   out int newCurrency,
                            out float newMaxHealth,
                            out float newDamageModifier,
                            out float newAttackSpeedModifier,
                            out int newCritChance,
                            out float newCritModifier,
                            out float newRangeModifier,
                            out float newAoERangeModifier,
                            out float newBaseMovementSpeed,
                            out float newMovementSpeedModifier)
    {
        newCurrency = currency;
        newMaxHealth = maxHealth;
        newDamageModifier = damageModifier;
        newAttackSpeedModifier = attackSpeedModifier;
        newCritChance = critChance;
        newCritModifier = critModifier;
        newRangeModifier = rangeModifier;
        newAoERangeModifier = aoeRangeModifier;
        newBaseMovementSpeed = baseMovementSpeed;
        newMovementSpeedModifier = movementSpeedModifier;
    }

    public void CompletePlanet(PlanetType planetType)
    {
        if (completedPlanets.Contains(planetType)) return;
        completedPlanets.Add(planetType);
    }

    public List<PlanetType> GetCompletedPlanets()
    {
        return completedPlanets;
    }

    public bool CheckForVictory()
    {
        return completedPlanets.Count >= planetsToComplete;
    }
}
