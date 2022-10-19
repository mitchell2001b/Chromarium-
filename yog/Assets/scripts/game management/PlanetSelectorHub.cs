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
