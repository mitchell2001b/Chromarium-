using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIndicatorHandler : MonoBehaviour
{
    [SerializeField] GameObject bulletIndicator;
    [SerializeField] GameObject bulletIndicatorSide;
    [SerializeField] IndicatorMaterial[] materials;

    [System.Serializable]
    private class IndicatorMaterial
    {
        public AmmoType ammoType;
        public Material material;
    }

    public void ChangeIndicatorMaterial(AmmoType ammoType)
    {
       
        foreach(IndicatorMaterial i in materials)
        {
            if(i.ammoType == ammoType)
            {              
                bulletIndicator.GetComponent<SkinnedMeshRenderer>().material = i.material;
                bulletIndicatorSide.GetComponent<MeshRenderer>().material = i.material;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
