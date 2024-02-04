using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

    public Image health;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)){
            health.rectTransform.sizeDelta = new Vector2(health.rectTransform.rect.width * 0.75f,health.rectTransform.rect.height);
        }
        if(Input.GetKeyUp(KeyCode.Alpha2) && health.rectTransform.rect.width * 1.25f > 400) {
            health.rectTransform.sizeDelta = new Vector2(400,health.rectTransform.rect.height);
        } else if(Input.GetKeyUp(KeyCode.Alpha2) && health.rectTransform.rect.width < 400){
            health.rectTransform.sizeDelta = new Vector2(health.rectTransform.rect.width * 1.25f,health.rectTransform.rect.height);
        }
    }
}