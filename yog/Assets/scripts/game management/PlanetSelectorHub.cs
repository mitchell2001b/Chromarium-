using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelectorHub : MonoBehaviour
{
    [SerializeField] Button desertButton;
    [SerializeField] Button jungleButton;
    [SerializeField] Button voidButton;
    private GameSceneLoader sceneLoader;

    private void Start() {
        sceneLoader = GetComponent<GameSceneLoader>();
        CheckCompletedPlanets();
    }

    private void CheckCompletedPlanets()
    {
        List<PlanetType> completedPlanets = DataManager.instance.GetCompletedPlanets();
        if (completedPlanets == null) return;
        foreach (PlanetType planetType in completedPlanets)
        {
            switch (planetType)
            {
                case PlanetType.Desert:
                    desertButton.interactable = false;
                    break;
                case PlanetType.Jungle:
                    jungleButton.interactable = false;
                    break;
                case PlanetType.Void:
                    voidButton.interactable = false;
                    break;
                default:
                    break;
            }
        }
    }

    public void LoadDesertPlanet()
    {
        sceneLoader.LoadDesertPlanet();
    }

    public void LoadJunglePlanet()
    {
        sceneLoader.LoadJunglePlanet();
    }

    public void LoadVoidPlanet()
    {
        sceneLoader.LoadVoidPlanet();
    }
}
