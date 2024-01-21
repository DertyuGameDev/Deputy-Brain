using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public PhoneCall transitions;
    public void cl()
    {
        StartDialogue.update(this.GetComponent<Transition>());
    }
}
