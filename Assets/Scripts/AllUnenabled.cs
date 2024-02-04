using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUnenabled : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            Clock.CanGo = false;
        }
    }
}
