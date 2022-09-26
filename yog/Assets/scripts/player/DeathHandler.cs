using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
  
    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void HandleDeath()
    {
        GameOverCanvas.enabled = true;

        Time.timeScale = 0;
        FindObjectOfType<WeaponHandler>().enabled = false;
        GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }
}
