using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class EnemySoundHandler : MonoBehaviour
{
    [SerializeField] EventReference moveSound;
    [SerializeField] EventReference attackSound;
    [SerializeField] EventReference deathSound;
    [SerializeField] EventReference runSound;
    private EventInstance soundInstanceMove;
    private EventInstance soundInstanceAttack;
    private EventInstance soundInstanceDeath;
    private EventInstance soundInstanceRun;

    [SerializeField] bool debug;
    // Start is called before the first frame update
    void Start()
    {
        soundInstanceMove = RuntimeManager.CreateInstance(moveSound);
        soundInstanceMove.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        soundInstanceAttack = RuntimeManager.CreateInstance(attackSound);
        soundInstanceAttack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        soundInstanceDeath = RuntimeManager.CreateInstance(deathSound);
        soundInstanceDeath.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        soundInstanceRun = RuntimeManager.CreateInstance(runSound);
        soundInstanceRun.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

        soundInstanceMove.start();
        if(debug)
        {
            //PlayRunSound();
            //soundInstanceRun.start();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSoundPlayLocation();
    }

    private void UpdateSoundPlayLocation()
    {
        soundInstanceDeath.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        soundInstanceAttack.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        soundInstanceMove.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        soundInstanceRun.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
    }

    public EventInstance GetSoundInstanceMove()
    {
        return soundInstanceMove;
    }

    public EventInstance GetSoundInstanceAttack()
    {
        return soundInstanceAttack;
    }

    public EventInstance GetSoundInstanceDeath()
    {
        return soundInstanceDeath;
    }

    public void PlayMoveSound()
    {
        soundInstanceMove.setParameterByNameWithLabel("run", "walking");
        //soundInstanceRun.setPaused(true);
        //soundInstanceMove.setPaused(false);
        //soundInstanceRun.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //soundInstanceMove.start();
    }
    public void PlayRunSound()
    {
        soundInstanceMove.setParameterByNameWithLabel("run", "running");
        //soundInstanceMove.setPaused(true);
        //soundInstanceRun.setPaused(false);
        //soundInstanceMove.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
       
        
    }
    public void PlayAttackSound()
    {
        soundInstanceAttack.start();
    }
    public void PlayDeathSound()
    {
        StopAllSounds();
        soundInstanceDeath.start();
    }
    public void StopAllSounds()
    {
        soundInstanceMove.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundInstanceMove.release();

        soundInstanceRun.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundInstanceRun.release();

        soundInstanceAttack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundInstanceAttack.release();

        //soundInstanceDeath.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //soundInstanceDeath.release();
    }

    private void OnDisable()
    {
        //soundInstanceMove.release();
        StopAllSounds();
    }
}
