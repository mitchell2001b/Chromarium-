using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] GameObject victoryPrefab;
    [SerializeField] List<Canvas> canviToDisable;
    [SerializeField] PlanetType planetType;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Player") return;
        StoreData();
        PauseScreenHandler.Pause();
        foreach (Canvas canvas in canviToDisable)
        {
            canvas.enabled = false;
        }
        if (DataManager.instance.CheckForVictory()) victoryPrefab.SetActive(true);
        else FindObjectOfType<GameSceneLoader>().LoadPlanetSelectorHub();
    }

    public void ActivateShip()
    {
        GetComponent<Animator>().SetTrigger("Activate");
    }

    private void StoreData()
    {
        PlayerAttributes attributes = FindObjectOfType<PlayerAttributes>();
        float maxHealth = FindObjectOfType<PlayerHealth>().GetMaxHealth();
        DataManager.instance.SaveData(  attributes.GetCurrentCurrency(),
                                        maxHealth,
                                        attributes.GetDamageModifier(),
                                        attributes.GetAttackSpeedModifier(),
                                        attributes.GetCritChance(),
                                        attributes.GetCritModifier(),
                                        attributes.GetRangeModifier(),
                                        attributes.GetAoERangeModifier(),
                                        attributes.GetMovementSpeedModifier());
        DataManager.instance.CompletePlanet(planetType);
    }
}
