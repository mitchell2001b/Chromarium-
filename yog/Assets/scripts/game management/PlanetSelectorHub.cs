using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSelectorHub : MonoBehaviour
{
    [SerializeField] Button desertButton;
    [SerializeField] Button jungleButton;
    [SerializeField] Button voidButton;

    private void Start() {
        desertButton.image.color = Color.green;
        jungleButton.image.color = Color.green;
        voidButton.image.color = Color.green;
    }
}
