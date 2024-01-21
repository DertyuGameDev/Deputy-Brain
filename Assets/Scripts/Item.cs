using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour
{
    public GameObject Drag;
    public bool Onec = true;
    public LayerMask LayerMask;
    public LayerMask Slot;
    private Vector3 pos = new Vector3(0, 0, 0);
    private void Start()
    {
        Onec = true;
    }
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Onec == false && Drag != null)
        {
            bool m = true;
            for (int i = 0; i < Drag.transform.childCount; i++)
            {
                if (Drag.transform.GetChild(i).GetComponent<RayDetail>() && Drag.transform.GetChild(i).gameObject.GetComponent<RayDetail>().may == false)
                {
                    m = false; break;
                }
            }
            if (m)
            {
                Drag.transform.SetParent(Drag.transform.GetChild(0).gameObject.GetComponent<RayDetail>().l.transform, true);
                Drag.transform.localPosition = Vector3.zero;
                Drag.transform.rotation = Quaternion.Euler(pos);
                Drag = null;
                pos = new Vector3(0, 0, 0);
                Onec = true;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Onec == true)
            {
                if (Physics.Raycast(r, out RaycastHit hit, 1000, LayerMask))
                {
                    if (Onec)
                    {
                        Drag = hit.collider.gameObject;
                        Onec = false;
                        pos = Drag.transform.rotation.eulerAngles;
                        Drag.transform.SetAsLastSibling();
                        Drag.transform.parent.SetAsLastSibling();
                        Drag.transform.parent.parent.SetAsLastSibling();
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(Drag != null)
            {
                pos += new Vector3(0, 0, -90);
            }
        }
        if (Drag != null)
        {
            Drag.transform.position = Vector3.Lerp(Drag.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward, 10f * Time.deltaTime);
            Drag.transform.localRotation = Quaternion.RotateTowards(Drag.transform.rotation, Quaternion.Euler(pos), 540 * Time.deltaTime);
        }
    }
}
