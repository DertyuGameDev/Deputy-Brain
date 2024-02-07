using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPhone : MonoBehaviour
{
    Vector3 screenPos;
    float angle = 0;
    float angleSecond = 0;
    public Collider col;
    public static bool can, click, drag, obratno;
    bool move;
    public LayerMask l, limit, nums;
    public float speed;
    bool flag, IsLim;
    public GameObject o;
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (transform.rotation.eulerAngles.z <= 34 && transform.rotation.eulerAngles.z > 5)
        { 
            can = false;
            click = false;
            drag = false;
            obratno = true;
        }
        else if (!obratno && move == true)
        {
            can = true;
            click = Input.GetMouseButtonDown(0);
            drag = Input.GetMouseButton(0);
            if (IsLim == false)
            {
                if (click == true && can == true)
                {
                    if (Physics.Raycast(ray, out RaycastHit h2, 10000, nums))
                    {
                        o = h2.collider.gameObject;
                    }
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider == col)
                        {
                            screenPos = Camera.main.WorldToScreenPoint(transform.position);
                            Vector3 vec3 = Input.mousePosition - screenPos;
                            angle = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                            flag = true;
                        }
                    }
                }
                else if (drag == true && can == true && flag == true)
                {
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angleL = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    angleSecond = angleL;
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angleL + angle)), 0.1f);
                }
            }
            if (o != null)
            {
                if (Physics.Raycast(new Ray(o.transform.position, Vector3.back), 10000, limit))
                {
                    IsLim = true;
                }
            }
        }
        if (!drag && !click)
        {
            flag = false;
            if (transform.eulerAngles.z > -5 && transform.eulerAngles.z < 5)
            {
                transform.rotation = Quaternion.identity;
                move = true;
                PhoneDisk.nol = true;
                IsLim = false;
            }
            if (transform.eulerAngles.z > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, speed)), 1);
                move = false;
            }
            if (transform.eulerAngles.z < 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, speed)), 1);
                move = false;
            }
        }
        if (obratno == true)
        {
            can = false;
            click = false;
            drag = false;
            if (transform.eulerAngles.z > -2 && transform.eulerAngles.z < 2)
            {
                obratno = false;
                move = true;
                PhoneDisk.nol = true;
                IsLim = false;
            }
            if (transform.eulerAngles.z > 1 || transform.eulerAngles.z < 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 1)), Time.deltaTime * speed);
                move = false;
            }
        }
    }
}
