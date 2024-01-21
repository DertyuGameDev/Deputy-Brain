using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPhone : MonoBehaviour
{
    public Vector3 screenPos;
    public float angle = 0;
    public float angleSecond = 0;
    public Collider col;
    public static bool can;
    public bool click, drag, obratno;
    public bool move;
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
            if (click == true && can == true)
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider == col)
                    {
                        screenPos = Camera.main.WorldToScreenPoint(transform.position);
                        Vector3 vec3 = Input.mousePosition - screenPos;
                        angle = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                    }
                }
            }
            else if (drag == true && can == true)
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider == col)
                    {
                        Vector3 vec3 = Input.mousePosition - screenPos;
                        float angleL = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                        angleSecond = angleL;
                        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(0, 0, angleL + angle)), 0.1f);
                    }
                }
            }
        }
        if (!drag && !click)
        {
            can = false;
            click = false;
            drag = false;
            if (transform.eulerAngles.z > -2 && transform.eulerAngles.z < 2)
            {
                transform.rotation = Quaternion.identity;
                move = true;
                PhoneDisk.nol = true;
            }
            if (transform.eulerAngles.z > 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 1)), Time.deltaTime * 100);
                move = false;
            }
            if (transform.eulerAngles.z < 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, 1)), Time.deltaTime * 100);
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
            }
            if (transform.eulerAngles.z > 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 1)), Time.deltaTime * 100);
                move = false;
            }
            if (transform.eulerAngles.z < 1)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles - new Vector3(0, 0, 1)), Time.deltaTime * 100);
                move = false;
            }
        }
    }
}
