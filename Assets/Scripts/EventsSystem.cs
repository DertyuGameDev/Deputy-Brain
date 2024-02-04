using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Random = UnityEngine.Random;

public class EventsSystem : MonoBehaviour
{
    public Active_option t;
    public Transform stenogram;
    public List<GameObject> details;
    public Event[] events;
    public GameObject[] prefabsEvents;
    private void Start()
    {
        for (int i = 0; i < events.Length; i++)
        {
            events[i] = new Event(events[i].nameEvent, events[i].timeHour, events[i].position, details);
        }
    }
    void Update()
    {
        if (Clock.day == 1 && Clock.hour == 18 && Clock.second == 0 || Clock.day == 2 && Clock.hour == 14 && Clock.second == 0)
        {
            AddEventEDA();
        }
        if(Clock.hour == 7 && Clock.second == 0 && PS.sleep == null && Clock.sleepwake == true || Clock.hour == 23 && Clock.second == 0 && PS.sleep == null && Clock.sleepwake == true)
        {
            SleeperWakeUper();
        }
    }
    public void AddEventEDA()
    {
        if (Active_option.activeEvent == null)
        {
            for (int i = 0; i < events.Length; i++)
            {
                if (events[i].nameEvent == "ЕДА")
                {
                    Active_option.activeEvent = events[i];
                    break;
                }
            }
        }
        if (Active_option.activeEvent != null && stenogram.Find("ЕДА(Clone)") == null)
        {
            Instantiate(prefabsEvents[0], stenogram);
        }
    }
    public void SleeperWakeUper()
    {
        if(PS.sleep == null)
        {
            for(int i = 0; i < events.Length; i++)
            {
                if (events[i].nameEvent == "СОН")
                {
                    PS.sleep = events[i];
                    break;
                }
            }
        }
        if (PS.sleep != null && stenogram.Find("SLEEP(Clone)") == null)
        {
            int[] l = new int[1];
            GameObject[] g = new GameObject[1];
            if (Clock.hour == 7) {
                l[0] = 0;
            }
            else
            {
                l[0] = 1;
            }
            Event a = new Event(PS.sleep.nameEvent, 0, l.ToList(), g.ToList());
            if (Clock.hour == 7)
            {
                prefabsEvents[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Пора просыпаться!";
            }
            else
            {
                prefabsEvents[1].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Идите спать!";
            }
            Instantiate(prefabsEvents[1], stenogram);
            Clock.CanGo = false;
        }
    }
}
