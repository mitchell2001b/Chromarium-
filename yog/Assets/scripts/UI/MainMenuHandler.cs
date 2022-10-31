using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    GameSceneLoader gameSceneLoader;

    void Start()
    {
        gameSceneLoader = GetComponent<GameSceneLoader>();
        if(DataManager.instance != null) Destroy(DataManager.instance.gameObject);
    }

    public void StartNewGame()
    {
        gameSceneLoader.StartGame();
    }
}
