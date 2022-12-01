using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineMac : MonoBehaviour
{
    public CinemachineFreeLook camMouse; //free look comandata dal mouse
    //public CinemachineFreeLook camJoy;// free look comandata dal controller
    public CinemachineFreeLook camPlay4; // controller playstation 4

    // Update is called once per frame
    void Update()
    {
        float avanti = Input.GetAxis("Mouse X");
        float destra = Input.GetAxis("Mouse Y");
        //float destra2 = Input.GetAxis("SecondaryY");
        //float avanti2 = Input.GetAxis("SecondaryX");
        float avanti3 = Input.GetAxis("Play4X");
        float destra3 = Input.GetAxis("Play4Y");


        if (avanti>0f || destra>0f)
        {
            camMouse.enabled = true;
            //camJoy.enabled = false;
            camPlay4.enabled = false;
            camMouse.Priority = 11;
        }

        /*else if (destra2>0f || avanti2 >0f)
        {
            camPlay4.enabled = false;
            camMouse.enabled = false;
            //camJoy.enabled = true;
            //camJoy.Priority = 12;
        } */

        else if (avanti3 >0f || destra3>0f)
        {
            camPlay4.enabled = true;
            camMouse.enabled = false;
            //camJoy.enabled = false;
            camPlay4.Priority = 13;
        }
    }
}
