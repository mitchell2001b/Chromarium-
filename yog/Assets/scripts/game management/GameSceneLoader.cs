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
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;      
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //Time.timeScale = 1;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        // Implement Return to Main Menu
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        // Implement Restart Game
        Destroy(DataManager.instance.gameObject);
        SceneManager.LoadScene(1);
    }

    public void LoadPlanetSelectorHub()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadDesertPlanet()
    {
        // Insert Desert Planet Scene
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void LoadJunglePlanet()
    {
        // Insert Jungle Planet Scene
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }

    public void LoadVoidPlanet()
    {
        // Insert Void Planet Scene
        //SceneManager.LoadScene(4);
    }
}
