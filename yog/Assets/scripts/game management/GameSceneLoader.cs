using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameSceneLoader : MonoBehaviour
{
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadGame()
    {       
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        //Player.GetComponent<FirstPersonController>().enabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Succesfull Game Load");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        //Implement Return to Main Menu
        Debug.Log("MainMenu");
    }

    public void RestartGame()
    {
        //Implement Restart Game
        Debug.Log("Restart Game");
    }
}
