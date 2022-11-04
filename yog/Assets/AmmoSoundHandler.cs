using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AmmoSoundHandler : MonoBehaviour
{

    [SerializeField] AmmoSound[] ammoSounds;

    [System.Serializable]
    private class AmmoSound
    {
        public AmmoType ammoType;
        public EventReference shootSoundRef;
        public EventInstance shootSoundInstance;

        public void SetUpSound()
        {
            shootSoundInstance = RuntimeManager.CreateInstance(shootSoundRef);
        }
        public void PlaySound()
        {
            shootSoundInstance.start();
        }


        public void ReleaseAndStopSound()
        {
            shootSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            shootSoundInstance.release();

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(AmmoSound soundLibrary in ammoSounds)
        {
            soundLibrary.SetUpSound();
        }
    }

    public void PlayAmmoShootSound(AmmoType ammoType)
    {
        foreach (AmmoSound soundLibrary in ammoSounds)
        {
            if(soundLibrary.ammoType == ammoType)
            {
                soundLibrary.PlaySound();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnDisable()
    {
        foreach (AmmoSound soundLibrary in ammoSounds)
        {
            soundLibrary.ReleaseAndStopSound();
        }
    }
}
