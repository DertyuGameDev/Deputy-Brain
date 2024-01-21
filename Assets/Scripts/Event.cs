using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "Event", menuName = "Event", order = 1)]
public class Event : ScriptableObject
{
    public string nameEvent;
    public int timeHour;
    public List<int> position;
    public List<GameObject> detail;
    public string Starter()
    {
        return this.nameEvent;
    }
    public Event(string nameEvent, int timeHour, List<int> position, List<GameObject> detail)
    {
        this.nameEvent = nameEvent;
        this.timeHour = timeHour;
        this.position = position;
        this.detail = detail;
    }
}
