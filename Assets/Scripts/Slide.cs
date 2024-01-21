using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slide : MonoBehaviour
{
    public Slider sl, sl1;
    public Transform h, h1;
    public int value;
    public Slider act;
    public bool nado;
    void Update()
    {
        value = Convert.ToInt32(act.value);
        if (act.value == 1 && nado)
        {
            if (act == sl)
            {
                h.gameObject.SetActive(false);
                h1.gameObject.SetActive(true);
                sl1.transform.SetAsLastSibling();
                act = sl1;
                nado = false;
            }
            else
            {
                h1.gameObject.SetActive(false);
                h.gameObject.SetActive(true);
                sl.transform.SetAsLastSibling();
                act = sl;
                nado = false;
            }
        }
        if (act.value != 1)
        {
            nado = true;
        }
    }
}
