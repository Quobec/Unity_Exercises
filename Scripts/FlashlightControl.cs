using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightControl : MonoBehaviour
{

    public Light flashlight;
    float modifier;
    public float maxAngle;
    public float minAngle;

    public float maxRange;
    public float minRange;

    public float intensityRatio;


    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1) && Input.GetAxis("Mouse ScrollWheel") != 0f){
            modifier = Mathf.Clamp(modifier + Input.GetAxis("Mouse ScrollWheel"), 0, 1);
            flashlight.range     =  minRange + ((maxRange - minRange) * modifier);
            flashlight.spotAngle =  minAngle + ((maxAngle - minAngle) * (1 - modifier));
            flashlight.intensity = flashlight.range/intensityRatio;
        }
    }
}
