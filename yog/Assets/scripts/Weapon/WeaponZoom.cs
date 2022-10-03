using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] float ZoomedOutFOV = 60f;
    [SerializeField] float ZoomedInFOV = 20f;
    [SerializeField] public FirstPersonController Fpc;

    bool ZoomedInToggle = false;
    // Start is called before the first frame update
    void Start()
    {
       // Fpc = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(!ZoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }

    }


    public void ZoomIn()
    {
        ZoomedInToggle = true;
        Cam.fieldOfView = ZoomedInFOV;
        //GetComponent<WeaponHandler>().GetCurrentSelectedWeapon().GetComponent<Animator>().SetBool("zoom", true);
        GetComponent<Animator>().SetBool("zoom", true);
        Fpc.m_MouseLook.YSensitivity = 0.5f;
        Fpc.m_MouseLook.XSensitivity = 0.5f;
    }

    public void ZoomOut()
    {
        ZoomedInToggle = false;
        Cam.fieldOfView = ZoomedOutFOV;
        //GetComponent<WeaponHandler>().GetCurrentSelectedWeapon().GetComponent<Animator>().SetBool("zoom", false);
        GetComponent<Animator>().SetBool("zoom", false);
        Fpc.m_MouseLook.YSensitivity = 2f;
        Fpc.m_MouseLook.XSensitivity = 2f;
    }
}
