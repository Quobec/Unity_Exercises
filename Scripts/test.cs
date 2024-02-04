using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public GameObject sunlight;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Keypad0)){
            sunlight.SetActive(!sunlight.activeSelf);
        }
    }
}
