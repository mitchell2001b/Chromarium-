using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    [SerializeField] GameObject WeaponParentObject;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(WeaponParentObject.transform.childCount + " kids");
        Debug.Log(GetCurrentSelectedWeapon().name);
    }

    // Update is called once per frame
    void Update()
    {
        

        ProcessKeyInput();
        ProcessScrollInput();

        
    }

    public GameObject GetCurrentSelectedWeapon()
    {
        GameObject weapon = null;
        for (int i = 0; i < WeaponParentObject.transform.childCount; i++)
        {
            if (WeaponParentObject.transform.GetChild(i).gameObject.activeSelf)
            {
                weapon = WeaponParentObject.transform.GetChild(i).gameObject;
            }
        }
        return weapon;
    }

    private void ProcessKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(1);
        }
    }

    private void ProcessScrollInput()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(GetCurrentSelectedWeaponIndex() >= WeaponParentObject.transform.childCount - 1)
            {
                SetWeapon(0);
            }
            else
            {
                SetWeapon(GetCurrentSelectedWeaponIndex() + 1);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (GetCurrentSelectedWeaponIndex() <= 0)
            {
                SetWeapon(WeaponParentObject.transform.childCount - 1);
            }
            else
            {
                SetWeapon(GetCurrentSelectedWeaponIndex() - 1);
            }
        }
    }

    public int GetCurrentSelectedWeaponIndex()
    {
        int weaponIndex = 0;
        for (int i = 0; i < WeaponParentObject.transform.childCount; i++)
        {
            if (WeaponParentObject.transform.GetChild(i).gameObject.activeSelf)
            {
                weaponIndex = i;
            }
        }
        return weaponIndex;
    }

    private void SetWeapon(int index)
    {
        GameObject weapon = null;
        for (int i = 0; i < WeaponParentObject.transform.childCount; i++)
        {
            if(i == index)
            {
                
                weapon = WeaponParentObject.transform.GetChild(i).gameObject;
               
            }
        }

        if(weapon == null)
        {
            Debug.Log("no weapon found");
        }
        else
        {
            GameObject weapon2 = GetCurrentSelectedWeapon();
            weapon2.GetComponent<Weapon>().CanShoot = true;
            WeaponZoom zoomScript = weapon2.GetComponent<WeaponZoom>();
            if (zoomScript != null)
            {
                zoomScript.ZoomOut();
            }
            
            weapon2.SetActive(false);
            weapon.SetActive(true);
        }
       
    }
}
