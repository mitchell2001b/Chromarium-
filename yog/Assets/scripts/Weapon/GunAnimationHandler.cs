using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimationHandler : MonoBehaviour
{  
    private Animator animator;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WeaponChangeActive()
    {
        player.GetComponent<Ammo>().WeaponChangeComplete();
        //weaponChangeComplete = true;
    }

    

    
    
    public void TriggerShootAnimation()
    {
        animator.SetTrigger("shoot");
    }
    public void ChangeGunAnimation(AmmoType ammoType)
    {
        switch(ammoType)
        {
            case AmmoType.Regular:
                animator.SetTrigger("reset");
                animator.SetBool("ice", false);
                animator.SetBool("fire", false);
                animator.SetBool("earth", false);
                animator.SetBool("air", false);
                animator.SetBool("holy", false);
                animator.SetBool("void", false);
                break;

            case AmmoType.Fire:
                animator.SetTrigger("reset");
                animator.SetBool("fire", true);
                animator.SetBool("ice", false);
                animator.SetBool("earth", false);
                animator.SetBool("air", false);
                animator.SetBool("holy", false);
                animator.SetBool("void", false);
                break;

            case AmmoType.Ice:
                animator.SetTrigger("reset");
                animator.SetBool("ice", true);
                animator.SetBool("fire", false);
                animator.SetBool("earth", false);
                animator.SetBool("air", false);
                animator.SetBool("holy", false);
                animator.SetBool("void", false);
                break;
            case AmmoType.Wind:
                animator.SetTrigger("reset");
                animator.SetBool("fire", false);
                animator.SetBool("ice", false);
                animator.SetBool("earth", false);
                animator.SetBool("holy", false);
                animator.SetBool("air", true);
                animator.SetBool("void", false);
                break;

            case AmmoType.Earth:
                animator.SetTrigger("reset");
                animator.SetBool("fire", false);
                animator.SetBool("ice", false);
                animator.SetBool("air", false);
                animator.SetBool("holy", false);
                animator.SetBool("earth", true);
                animator.SetBool("void", false);
                break;
            case AmmoType.Holy:
                animator.SetTrigger("reset");
                animator.SetBool("fire", false);
                animator.SetBool("ice", false);
                animator.SetBool("earth", false);
                animator.SetBool("holy", true);
                animator.SetBool("air", false);
                animator.SetBool("void", false);
                break;
            case AmmoType.Void:
                animator.SetTrigger("reset");
                animator.SetBool("fire", false);
                animator.SetBool("ice", false);
                animator.SetBool("earth", false);
                animator.SetBool("holy", false);
                animator.SetBool("air", false);
                animator.SetBool("void", true);
                break;
        }
    }
}
