using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] int currency = 0;
    [SerializeField] float maxHealth = 100;
    [SerializeField] float damageModifier = 1f;
    [SerializeField] float attackSpeedModifier = 1f;
    [SerializeField] int critChance = 0;
    [SerializeField] float critModifier = 1f;
    [SerializeField] float rangeModifier = 1f;
    [SerializeField] float aoeRangeModifier = 1f;
    [SerializeField] float baseMovementSpeed = 5f;
    [SerializeField] float movementSpeedModifier = 1f;
    [SerializeField] List<PlanetType> completedPlanets = new List<PlanetType>();
    [SerializeField] int planetsToComplete = 3;
    [SerializeField] Ammo.AmmoSlot[] ammoSlots;

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

    public void LoadAmmoSlots(out Ammo.AmmoSlot[] ammoSlots)
    {
        ammoSlots = this.ammoSlots;
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
