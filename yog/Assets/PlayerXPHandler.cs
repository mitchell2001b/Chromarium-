using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerXPHandler : MonoBehaviour
{
    [SerializeField] PlayerAttributes playerAttributes;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] TextMeshProUGUI LevelNumber;
    // Start is called before the first frame update
    void Start()
    {
        //playerAttributes = GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void AddXpPoints(float pointCount)
    {
        playerAttributes.XpCount = playerAttributes.XpCount + pointCount;
        LevelUpIfPossible();

    }


    public void LevelUpIfPossible()
    {
        if(playerAttributes.XpCount == 100 || playerAttributes.XpCount > 100)
        {
            if(playerAttributes.PlayerLevel == 0)
            {
                playerAttributes.PlayerLevel = 1;
            }
            playerAttributes.PlayerLevel = playerAttributes.PlayerLevel + 1;
            playerAttributes.XpCount = 0;
            Debug.Log(playerAttributes.PlayerLevel + " level");
            LevelNumber.text = playerAttributes.PlayerLevel.ToString();
            playerGameObject.GetComponent<PlayerHealth>().ChangeMaxHealth(50f);
        }
    }
}
