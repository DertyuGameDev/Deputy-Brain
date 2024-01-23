using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTask : MonoBehaviour
{
    public Animator animator;
    bool Op = true;
    public void B(GameObject g)
    {
        animator.SetBool("OpenTask", Op);
        Op = !Op;
    }
}
