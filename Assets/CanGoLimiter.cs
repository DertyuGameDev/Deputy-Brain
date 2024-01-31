using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanGoLimiter : MonoBehaviour
{
    public GameObject phone, pause;
    public bool t = false;
    void Update()
    {
        if(phone.activeSelf == true)
        {
            pause.SetActive(true);
            Clock.CanGo = false;
            t = true;
        }
        else
        {
            t = false;
        }
    }
}
