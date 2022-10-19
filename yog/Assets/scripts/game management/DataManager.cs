using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    int currency;
    float maxHealth;
    float damageModifier;
    float attackSpeedModifier;
    int critChance;
    float critModifier;
    float rangeModifier;
    float aoeRangeModifier;
    float baseMovementSpeed;
    float movementSpeedModifier;
    List<PlanetType> completedPlanets;

    public static DataManager instance;
    
    private void Awake() {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
