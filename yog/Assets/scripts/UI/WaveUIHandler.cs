using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveNumber;
    [SerializeField] EnemyWaveHandler waveHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveNumber.text = waveHandler.currentActiveWaveIndex.ToString();
    }
}
