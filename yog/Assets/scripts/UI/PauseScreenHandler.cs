using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class PauseScreenHandler : MonoBehaviour
{
    [SerializeField] GameSceneLoader sceneLoader;
    [SerializeField] EnemyWaveHandler waveHandler;
    [SerializeField] PlayerAttributes attributes;
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] List<Canvas> otherCanvi;
    [SerializeField] TextMeshProUGUI waveIndicatorText;
    [SerializeField] TextMeshProUGUI enemiesRemainingText;
    [SerializeField] TextMeshProUGUI damageModifierText;
    [SerializeField] TextMeshProUGUI attackSpeedModifierText;
    [SerializeField] TextMeshProUGUI critChanceText;
    [SerializeField] TextMeshProUGUI critModifierText;
    [SerializeField] TextMeshProUGUI rangeModifierText;
    [SerializeField] TextMeshProUGUI aoeModifierText;
    [SerializeField] TextMeshProUGUI movementSpeedText;
    private bool isPaused = false;

    void Update()
    {
        if(Input.GetButton("Pause") && !isPaused)
        {
            isPaused = true;
            Pause();
            pauseCanvas.enabled = true;
            foreach (Canvas canvas in otherCanvi)
            {
                canvas.enabled = false;
            }
            LoadData();
        }
    }

    public static void Pause()
    {
        Time.timeScale = 0;
        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void UnPause()
    {
        Time.timeScale = 1;
        FindObjectOfType<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void LoadData()
    {
        LoadWaveData();
        LoadAttributeData();
    }

    private void LoadWaveData()
    {
        int currentWaveNumber = waveHandler.currentActiveWaveIndex;
        waveIndicatorText.text = currentWaveNumber.ToString();
        enemiesRemainingText.text = (waveHandler.waves[currentWaveNumber - 1].enemyCount - waveHandler.GetEnemiesDefeated()).ToString();
    }

    private void LoadAttributeData()
    {
        damageModifierText.text = attributes.GetDamageModifier() * 100 + "%";
        attackSpeedModifierText.text = attributes.GetAttackSpeedModifier() * 100 + "%";
        critChanceText.text = attributes.GetCritChance() + "%";
        critModifierText.text = attributes.GetCritModifier() * 100 + "%";
        rangeModifierText.text = attributes.GetRangeModifier() * 100 + "%";
        aoeModifierText.text = attributes.GetAoERangeModifier() * 100 + "%";
        movementSpeedText.text = Mathf.Round(attributes.GetBaseMovementSpeed() * attributes.GetMovementSpeedModifier() * 100) / 100 + " m/s";
    }

    public void ContinueGame()
    {
        pauseCanvas.enabled = false;
        foreach (Canvas canvas in otherCanvi)
        {
            canvas.enabled = true;
        }
        UnPause();
        isPaused = false;
    }

    public void QuitToMainMenu()
    {
        sceneLoader.MainMenu();
    }
}
