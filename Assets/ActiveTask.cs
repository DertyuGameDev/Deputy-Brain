using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTask : MonoBehaviour
{
    bool Op = true;
    public void B(GameObject g)
    {
        if (Op == true)
        {
            g.GetComponent<RectTransform>().anchoredPosition = Vector3.zero + new Vector3(0, 0, -17);
        }
        else
        {
            g.GetComponent<RectTransform>().anchoredPosition = new Vector3(90000, 0, -17);
        }
        Op = !Op;
    }
}
