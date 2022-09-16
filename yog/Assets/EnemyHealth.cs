using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float HitPoints = 100f;
    [SerializeField] ParticleSystem DeathVFX;
    [SerializeField] DestroyedObjectsPooler pooler;
    [SerializeField] PlayerXPHandler XpHandler;

    public DestructableObject DestructableType;
    public string DestructableTag { get; private set; }
    void Start()
    {
        DestructableTag = DestructableType.ObjectType.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageCount)
    {
        Debug.Log(DestructableTag);
        BroadcastMessage("OnDamageTaken");
        HitPoints = HitPoints - damageCount;
        if(HitPoints < 0 || HitPoints == 0)
        {
            Destroy(gameObject);
            pooler.SpawnFromPool(DestructableTag, transform.position, transform.rotation);
            DeathVFX.Play();
            XpHandler.AddXpPoints(50);
        }
    }
}
