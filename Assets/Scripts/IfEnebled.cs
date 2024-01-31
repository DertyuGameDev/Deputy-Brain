using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfEnebled : MonoBehaviour
{
    public Sprite s;
    void Update()
    {
        if(this.GetComponent<BoxCollider>().enabled == false)
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 0f);
        }
        else
        {
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1f);
        }
    }
}
