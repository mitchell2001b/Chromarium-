using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    GameSceneLoader gameSceneLoader;

    void Start()
    {
        gameSceneLoader = GetComponent<GameSceneLoader>();
    }

    public void StartNewGame()
    {
        Debug.Log("Game Loading");
        gameSceneLoader.StartGame();
    }
}
