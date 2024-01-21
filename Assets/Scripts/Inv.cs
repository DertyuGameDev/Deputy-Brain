using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inv : MonoBehaviour
{
    public Sprite i, j;
    public Animator animator;
    bool Op = true;
    public void B(GameObject g)
    {
        animator.SetBool("Open", Op);
        Op = !Op;
        if (this.GetComponent<Image>().sprite == i)
        {
            this.GetComponent<Image>().sprite = j;
        }
        else
        {
            this.GetComponent<Image>().sprite = i;
        }
    }
}
