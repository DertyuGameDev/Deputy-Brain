using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click : MonoBehaviour
{
    public GameObject g, t;
    void Update()
    {
        if (g.activeSelf == true)
        {
            t.SetActive(false);
        }
        else
        {
            t.SetActive(true);
        }
    }
}
