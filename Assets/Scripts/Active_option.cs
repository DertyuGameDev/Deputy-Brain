using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Active_option : MonoBehaviour
{
    public Image lamp;
    public Slider slider;
    public bool IsDeleted = false;
    public int timer;
    public List<GameObject> details;
    public List<int> position;
    public static Event activeEvent;
    public Event a;
    public GameObject p;
    private void Update()
    {
        a = activeEvent;
        if (activeEvent != null)
        {
            timer = activeEvent.timeHour;
            details = activeEvent.detail.ToList();
            position = activeEvent.position.ToList();
        }
        if (activeEvent != null && timer <= 0)
        {
            activeEvent = null;
            timer = 0;
            details = null;
            position = null;
            slider.value = 0;
            Destroy(p);
            p = null;
            // רענאפ
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
                if (details[i].name == "ÊÂ")
                {
                    if (details[i].GetComponent<Slide>().value != position[i] && position[i] != -1)
                    {
                        IsOk = false;
                        break;
                    }
                }
                if (details[i].name == "ÊÏ")
                {
                    if (details[i].transform.GetChild(4).GetComponent<Slider>().value != position[i] && position[i] != -1)
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
                lamp.color = Color.green;
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
                lamp.color = Color.red;
                slider.value = 0;
                Destroy(p);
                p = null;
                //רענאפ
            }
        }
        else
        {
            slider.value = 0;
        }
    }
}
