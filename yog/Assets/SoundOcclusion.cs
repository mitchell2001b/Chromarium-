using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class SoundOcclusion : MonoBehaviour
{
    [SerializeField] int occlusionHitCount;
    [SerializeField] Transform PlayerTarget;
    [SerializeField] float occlusionBetweenWidthSound;
    [SerializeField] float occlusionBetweenWidthPlayer;
    [SerializeField] LayerMask occlusionLayerMask;
   
    [SerializeField] EventReference moveSound;
    [SerializeField] EventReference moveSound2;
    private EventInstance soundInstance;
    private EventInstance soundInstance2;
    [SerializeField] bool isProjectile;

    [SerializeField] float detectionRange;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        soundInstance = RuntimeManager.CreateInstance(moveSound);
        soundInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        soundInstance2 = RuntimeManager.CreateInstance(moveSound2);
        soundInstance2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        if (!isProjectile)
        {
            soundInstance.start();
        }
        
        //RuntimeManager.PlayOneShotAttached(sound, gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);



    }
    // Update is called once per frame
    void Update()
    {
        soundInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
    }
    private void CastLine(Vector3 begin, Vector3 end)
    {
        RaycastHit hit;
        Physics.Linecast(begin, end, out hit, ~occlusionLayerMask);

        if (hit.collider)
        {
            occlusionHitCount++;
            Debug.DrawLine(begin, end, Color.red);
        }
        else
        {
            Debug.DrawLine(begin, end, Color.blue);
        }
            
        
    }
    private void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, PlayerTarget.position) <= detectionRange)
        {
            CastLine(transform.position, PlayerTarget.position);
            //x side +
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x, PlayerTarget.position.y, PlayerTarget.position.z));
            //x side -
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x, PlayerTarget.position.y, PlayerTarget.position.z));
            //CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));

            OccludeSound();
            occlusionHitCount = 0;
        }
        
    }

    private void OccludeSound()
    {
        soundInstance.setParameterByName("Occlusion", occlusionHitCount / 6);
    }

    public void PlaySound()
    {
        //soundInstance = RuntimeManager.CreateInstance(moveSound);
        soundInstance.start();
    }

    public void PlayShootSound()
    {
        soundInstance2.start();
    }

    private void OnDisable()
    {
        if(!isProjectile)
        {
            soundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        
        soundInstance.release();
        soundInstance2.release();
    }


}
