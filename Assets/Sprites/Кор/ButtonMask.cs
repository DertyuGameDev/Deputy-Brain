using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ButtonMask : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float alpha = 1f;
    private Image i;
    void Start()
    {
        i = gameObject.GetComponent<Image>(); 
        i.alphaHitTestMinimumThreshold = alpha; 
    }
}
