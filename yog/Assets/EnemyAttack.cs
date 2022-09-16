using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth Target;
    [SerializeField] float Damage = 40f;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if(Target == null)
        {
            return;
        }
        Target.GetComponent<PlayerHealth>().TakeDamage(Damage);
        Debug.Log("bam bam");
    }
}
