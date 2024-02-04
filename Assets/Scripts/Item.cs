using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject Drag;
    public GameObject par;
    public bool Onec = true;
    public bool EQ = true;
    public LayerMask LayerMask;
    public LayerMask Slot;
    public LayerMask Equipment;
    private Vector3 pos = new Vector3(0, 0, 0);
    private void Start()
    {
        Onec = true;
    }
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hi, 1000, LayerMask))
        {
            par = hi.collider.gameObject;
        }
        if (Input.GetMouseButtonDown(0) && Onec == false && Drag != null)
        {
            if (EQ == false)
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
                    Drag.transform.parent.SetAsLastSibling();
                    if (Drag.name == "Eda" || Drag.name == "Sleep")
                    {
                        Drag.transform.GetChild(7).GetComponent<Slider>().enabled = true;
                    }
                    else if (Drag.name == "ÊÂ")
                    {
                        Drag.transform.GetChild(7).GetComponent<Slider>().enabled = true;
                    }
                    else if (Drag.name == "ÊÏ")
                    {
                        Drag.transform.GetChild(7).GetComponent<Slider>().enabled = true;
                    }
                    else if (Drag.name == "ÏÑ")
                    {
                        Drag.transform.GetChild(5).GetComponent<Slider>().enabled = true;
                    }

                    Drag = null;
                    pos = new Vector3(0, 0, 0);
                    Onec = true;
                }
            }
            else
            {
                Drag.GetComponent<dRAGdROP>().Check();
                Drag = null;
                Onec = true;
                EQ = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Onec == true)
            {
                if (Physics.Raycast(r, out RaycastHit hit, 1000, LayerMask))
                {
                    if (Onec && hit.collider.gameObject.tag == "Detail")
                    {
                        Drag = hit.collider.gameObject;
                        Onec = false;
                        pos = Drag.transform.rotation.eulerAngles;
                        Drag.transform.SetAsLastSibling();
                        Drag.transform.parent.SetAsLastSibling();
                        Drag.transform.parent.parent.SetAsLastSibling();
                        if (Drag.name == "Eda" || Drag.name == "Sleep")
                        {
                            Drag.transform.GetChild(7).GetComponent<Slider>().enabled = false;
                        }
                        else if (Drag.name == "ÊÂ")
                        {
                            Drag.transform.GetChild(7).GetComponent<Slider>().enabled = false;
                        }
                        else if (Drag.name == "ÊÏ")
                        {
                            Drag.transform.GetChild(7).GetComponent<Slider>().enabled = false;
                        }
                        else if (Drag.name == "ÏÑ")
                        {
                            Drag.transform.GetChild(5).GetComponent<Slider>().enabled = false;
                        }
                    }
                }
                else if (Physics.Raycast(r, out RaycastHit h, 1000, Equipment))
                {
                    if (Onec)
                    {
                        EQ = true;
                        Drag = h.collider.gameObject;
                        Onec = false;
                        Drag.transform.SetParent(Drag.transform.parent.parent.parent);
                        Drag.transform.SetAsLastSibling();
                        Drag.transform.parent.SetAsLastSibling();
                        Drag.transform.parent.parent.SetAsLastSibling();
                        Drag.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(Drag != null && EQ == false)
            {
                pos += new Vector3(0, 0, -90);
            }
        }
        if (Drag != null)
        {
            Drag.transform.position = Vector3.Lerp(Drag.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 0.3f), 10f * Time.deltaTime);
            Drag.transform.localRotation = Quaternion.RotateTowards(Drag.transform.rotation, Quaternion.Euler(pos), 540 * Time.deltaTime);
        }
    }
}
