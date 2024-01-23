using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetail : MonoBehaviour
{
    public bool may;
    public GameObject l;
    void Update()
    {
        Ray ray = new Ray(this.transform.position, Vector3.forward * 1000);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            l = hit.collider.gameObject;
            if (l.tag == "Detail" || l.tag == "Map" || l.tag == "TV" || l.transform.childCount > 0)
            {
                may = false;
            }
            else
            {
                may = true;
            }
        }
    }
}
