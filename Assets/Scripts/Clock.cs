using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Clock : MonoBehaviour
{
    public static bool CanGo = true;
    public static int day = 1;
    public TextMeshProUGUI clock;
    public Image newDay;
    public static int hour, second;
    public GameObject Kaseta;
    public Transform spawner;
    public Scene[] scene;
    public GameObject phone, diskPhone;
    public Animator phoneAnim;
    public static int ind = 0;
    public static int indPhone = -1;
    public static Action f;
    void Start()
    {
        f += OnTimeTracker;
        second = 0;
        hour = 17;
        StartCoroutine(timeTicker());
    }

    public IEnumerator timeTicker()
    {
        if (CanGo)
        {
            yield return new WaitForSeconds(1f);
            if (hour == 15 && second == 0)
            {
                indPhone += 1;
                phone.SetActive(true);
            }
            if (hour == 23)
            {
                second = 0;
                hour = 7;
                day += 1;
                dRAGdROP.s = scene[ind];
                Instantiate(Kaseta, spawner);
                ind += 1;
                CanGo = false;
            }
            if (CanGo)
            {
                second += 15;
                if (second == 60)
                {
                    hour += 1;
                    second = 0;
                    MinusTime();
                }
            }
            StartCoroutine(timeTicker());
        }
    }
    void Update()
    {
        clock.text = hour.ToString("D2") + ":" + second.ToString("D2");
    }
    public void OnTimeTracker()
    {
        CanGo = true;
        StartCoroutine(timeTicker());
        second = 0;
        hour = 7;
        newDay.gameObject.SetActive(false);
    }
    public void MinusTime()
    {
        if(Active_option.activeEvent != null)
        {
            Active_option.activeEvent.timeHour -= 1;
        }
    }
}
