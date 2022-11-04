using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class VictoryUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI damageNumberText;
    [SerializeField] TextMeshProUGUI attackSpeedNumberText;
    [SerializeField] TextMeshProUGUI critChanceNumberText;
    [SerializeField] TextMeshProUGUI critModifierNumberText;
    [SerializeField] TextMeshProUGUI rangeModifierNumberText;
    [SerializeField] TextMeshProUGUI aoeModifierNumberText;
    [SerializeField] TextMeshProUGUI movementSpeedNumberText;
    [SerializeField] GameSceneLoader gameSceneLoader;

    private void OnEnable() {
        PlayerAttributes attributes = FindObjectOfType<PlayerAttributes>();
        damageNumberText.text = (attributes.GetDamageModifier() * 100) + "%";
        attackSpeedNumberText.text = (attributes.GetAttackSpeedModifier() * 100) + "%";
        critChanceNumberText.text = attributes.GetCritChance() + "%";
        critModifierNumberText.text = (attributes.GetCritModifier() * 100) + "%";
        rangeModifierNumberText.text = (attributes.GetRangeModifier() * 100) + "%";
        aoeModifierNumberText.text = (attributes.GetAoERangeModifier() * 100) + "%";
        movementSpeedNumberText.text = Mathf.Round(attributes.GetMovementSpeedModifier() * attributes.GetBaseMovementSpeed() *100)/100 + " m/s";
        Time.timeScale = 0;
        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void MainMenu()
    {
        PauseScreenHandler.UnPause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameSceneLoader.MainMenu();
    }

    public void Restart()
    {
        PauseScreenHandler.UnPause();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameSceneLoader.RestartGame();
    }
}
