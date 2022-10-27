using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class SoundOcclusionEnemy : SoundOcclusionBase
{
    [SerializeField] EnemySoundHandler soundHandler;
    // Start is called before the first frame update
    void Start()
    {
        this.SetTarget();
        soundHandler = GetComponent<EnemySoundHandler>();
    }

    public override void OccludeSound()
    {
        soundHandler.GetSoundInstanceMove().setParameterByName("Occlusion", this.GetOcclusionHitCount() / 6);
        soundHandler.GetSoundInstanceAttack().setParameterByName("Occlusion", this.GetOcclusionHitCount() / 6);
        soundHandler.GetSoundInstanceDeath().setParameterByName("Occlusion", this.GetOcclusionHitCount() / 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
