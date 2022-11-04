using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoIndicatorHandler : MonoBehaviour
{
    [SerializeField] GameObject bulletIndicator;
    [SerializeField] GameObject bulletIndicatorSide;
    [SerializeField] IndicatorMaterial[] materials;

    [SerializeField] Material reloadMaterial;
    [System.Serializable]
    private class IndicatorMaterial
    {
        public AmmoType ammoType;
        public Material material;
        public GameObject indicatorMesh;
    }

    public void ChangeIndicatorMaterial(AmmoType ammoType)
    {
        bulletIndicator.SetActive(false);
        
        foreach(IndicatorMaterial i in materials)
        {
            if(i.ammoType == ammoType)
            {
                bulletIndicator = i.indicatorMesh;
                bulletIndicator.SetActive(true);
                bulletIndicator.GetComponent<SkinnedMeshRenderer>().material = i.material;
                bulletIndicatorSide.GetComponent<MeshRenderer>().material = i.material;
            }
        }
        
    }

    public void ChangeIndicatorToReloadMaterial()
    {
        bulletIndicator.GetComponent<SkinnedMeshRenderer>().material = reloadMaterial;
        bulletIndicatorSide.GetComponent<MeshRenderer>().material = reloadMaterial;
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
