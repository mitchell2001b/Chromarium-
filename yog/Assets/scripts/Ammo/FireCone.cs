using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCone : MonoBehaviour
{

    private List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders()
    {
        List<Collider> colliderList = new List<Collider>();
        foreach(Collider c in colliders)
        {
            if(c != null)
            {
                colliderList.Add(c);
            }
            else
            {
                colliderList.Remove(c);
            }
            
        }
        //ClearList();
        return colliderList;    
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (!colliders.Contains(other) && other.gameObject.tag == "Enemy")
        {
            colliders.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == null)
        {
            return;
        }
        colliders.Remove(other);
    }
}
