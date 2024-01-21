using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.SetAsLastSibling();
    }
}
