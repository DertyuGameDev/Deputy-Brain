using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OutlineMine : MonoBehaviour
{
    public Sprite i, i1, b;
    public Image k, k1;
    void Update()
    {
        if(k.sprite == b)
        {
            k1.sprite = i;
        }
        else
        {
            k1.sprite = i1;
        }
    }
}
