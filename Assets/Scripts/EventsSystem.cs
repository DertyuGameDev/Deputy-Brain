using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EventsSystem : MonoBehaviour
{ 
    public List<GameObject> details;
    public Active_option t;
    public Transform stenogram;
    public Event[] events;
    public static Action<GameObject[], int> set_detail;
    public int[] position;
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
        set_detail += SetDetail;
        if (Clock.day == 1 && Clock.hour == 18 && Clock.second == 0 || Clock.day == 2 && Clock.hour == 14 && Clock.second == 0)
        {
            AddEventEDA();
        }
    }
    public void AddEventEDA()
    {
        if (Active_option.activeEvent == null)
        {
            for (int i = 0; i < events.Length; i++)
            {
                if (events[i].nameEvent == "ÅÄÀ" && t.IsDeleted == false)
                {
                    Active_option.activeEvent = events[i];
                    break;
                }
            }
        }
        if (Active_option.activeEvent != null && stenogram.Find("ÅÄÀ(Clone)") == null)
        {
            Instantiate(prefabsEvents[0], stenogram);
        }
    }
    public void SetDetail(GameObject[] d, int ind)
    {
        d[ind] = details[ind];
    }
}
