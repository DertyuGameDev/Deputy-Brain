using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShield : MonoBehaviour
{
    bool Op = false;
    public Vector3 v, v1;
    public GameObject shield, cap;
    public void B()
    {
        if (Op == true)
        {
            shield.GetComponent<RectTransform>().anchoredPosition = v + new Vector3(0, 0, -17);
            cap.GetComponent<RectTransform>().anchoredPosition = new Vector3(90000, 0, -17);
        }
        else
        {
            shield.GetComponent<RectTransform>().anchoredPosition = new Vector3(90000, 0, -17);
            cap.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, -216);
        }
        Op = !Op;
    }
    private void Start()
    {
        Op = true;
    }
}
