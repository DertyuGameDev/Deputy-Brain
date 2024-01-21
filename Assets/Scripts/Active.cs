using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{
    public void ActiveShield(GameObject a)
    {
        this.gameObject.SetActive(false);
        a.SetActive(true);
    }
}
