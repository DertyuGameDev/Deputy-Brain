using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Random = UnityEngine.Random;

public class Active_option : MonoBehaviour
{
    public Image lamp;
    public Sprite gray, red, green, yellow;
    private int t;
    public Slider slider;
    int timer;
    List<GameObject> details;
    List<int> position;
    public static Event activeEvent;
    public Event a;
    public GameObject p, phone;
    public static bool problem;
    public PhoneCall[] phoneCall;
    public static PhoneCall actPhoneCall;
    private void Update()
    {
        a = activeEvent;
        if (activeEvent != null)
        {
            if (activeEvent.timeHour > t)
            {
                t = activeEvent.timeHour;
            }
            timer = activeEvent.timeHour;
            details = activeEvent.detail.ToList();
            position = activeEvent.position.ToList();
            lamp.sprite = yellow;
        }
        if (activeEvent != null && timer == 0)
        {
            activeEvent.timeHour = t;
            activeEvent = null;
            timer = 0;
            details = null;
            position = null;
            slider.value = 0;
            Destroy(p);
            p = null;
            StartCoroutine(color(red, gray));
            Fines.fines += 1;
        }
        if(slider.value == 1 && activeEvent != null)
        {
            Checker();
        }
        if (GameObject.FindGameObjectWithTag("EDA") != null)
        {
            p = GameObject.FindGameObjectWithTag("EDA");
            if (activeEvent.position[1] != -1)
            {
                p.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = activeEvent.position[1].ToString();
            }
            else
            {
                p.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = "-";
            }
            if (activeEvent.position[0] != -1)
            {
                p.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = activeEvent.position[0].ToString();
            }
            else
            {
                p.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>().text = "-";
            }
            p.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = activeEvent.timeHour.ToString();
        }
    }
    public void Checker()
    {
        if (this.transform.parent.parent.name == "Grid")
        {
            bool IsOk = true;
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].transform.parent.parent.name != "Grid")
                {
                    IsOk = false;
                    break;
                }
                if (details[i].name == " ¬")
                {
                    if (details[i].GetComponent<Slide>().value != position[i] && position[i] != -1)
                    {
                        IsOk = false;
                        break;
                    }
                }
                if (details[i].name == " œ")
                {
                    if (details[i].transform.GetChild(7).GetComponent<Slider>().value != position[i] && position[i] != -1)
                    {
                        IsOk = false;
                        break;
                    }
                }
            }
            if (IsOk)
            {
                activeEvent = null;
                timer = 0;
                details = null;
                position = null;
                int r = 51;
                if (r > 50)
                {
                    problem = true;
                    actPhoneCall = phoneCall[0];
                    phone.SetActive(true);
                }
                else
                {
                    problem = false;
                    actPhoneCall = null;
                    StartCoroutine(color(green, gray));
                }
                slider.value = 0;
                Destroy(p);
                p = null;
            }
            else
            {
                activeEvent = null;
                timer = 0;
                details = null;
                position = null;
                StartCoroutine(color(red, gray));
                slider.value = 0;
                Destroy(p);
                p = null;
                Fines.fines += 1;
            }
        }
        else
        {
            slider.value = 0;
        }
    }
    public IEnumerator color(Sprite k1, Sprite k2)
    {
        lamp.sprite = k1;
        yield return new WaitForSeconds(1);
        lamp.sprite = k2;
    }
}
