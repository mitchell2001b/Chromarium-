using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class MiscSoundHandler : MonoBehaviour
{
    [SerializeField] EventReference playerHitSound;
    [SerializeField] EventReference affinityBlockSound;
    
    //[SerializeField] EventReference runSound;
    private EventInstance soundInstancePlayerHit;
    private EventInstance soundInstanceAffinityBlock;
    
    // Start is called before the first frame update
    void Start()
    {
        soundInstancePlayerHit = RuntimeManager.CreateInstance(playerHitSound);
        soundInstanceAffinityBlock = RuntimeManager.CreateInstance(affinityBlockSound);
    }
    public void PlayAffinityBlockSound()
    {
        soundInstanceAffinityBlock.start();
    }

    public void PlayPlayerHitSound()
    {
        soundInstancePlayerHit.start();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {       
        soundInstancePlayerHit.release();
        soundInstanceAffinityBlock.release();

    }
}
