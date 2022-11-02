using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public abstract class SoundOcclusionBase : MonoBehaviour
{
    [SerializeField] private int occlusionHitCount;
    [SerializeField] private Transform PlayerTarget;
    [SerializeField] private float occlusionBetweenWidthSound;
    [SerializeField] private float occlusionBetweenWidthPlayer;
    [SerializeField] private LayerMask occlusionLayerMask;
    [SerializeField] private float detectionRange;
    // Start is called before the first frame update
    void Start()
    {
        
        Debug.Log("hhhhhhhajdfnsfkasjfkjYYYYYYY");
    }

    public int GetOcclusionHitCount()
    {
        return occlusionHitCount;
    }

    public void SetTarget()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public Transform GetTarget()
    {
        return PlayerTarget;
    }

  
    public abstract void OccludeSound();
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);



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
        if (PlayerTarget == null)
        {
            return;
        }
       
        if (Vector3.Distance(transform.position, PlayerTarget.position) <= detectionRange)
        {
            //CastLine(transform.position, PlayerTarget.position);
            //x side +
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x, PlayerTarget.position.y, PlayerTarget.position.z));
            //x side -
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z), new Vector3(PlayerTarget.position.x, PlayerTarget.position.y, PlayerTarget.position.z));
            CastLine(new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y, transform.position.z), new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y, PlayerTarget.position.z));

           // CastLine(new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z));
            //CastLine(new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z));
            //CastLine(new Vector3(PlayerTarget.position.x + occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));

           // CastLine(new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x - occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z));
            //CastLine(new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x + occlusionBetweenWidthSound, transform.position.y + 1, transform.position.z));
           // CastLine(new Vector3(PlayerTarget.position.x - occlusionBetweenWidthPlayer, PlayerTarget.position.y + 1, PlayerTarget.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z));
            OccludeSound();
            occlusionHitCount = 0;
        }
    }
}
