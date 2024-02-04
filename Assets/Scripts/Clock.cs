using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class Clock : MonoBehaviour
{
    public static bool CanGo = true;
    public static int day = 0;
    public static bool sleepwake = true;
    public float delay = 1;
    public int d;
    public TextMeshProUGUI clock;
    public Image newDay;
    public static int hour, second;
    public GameObject Kaseta, Energy, Page;
    public List<GameObject> pages = new List<GameObject>();
    public Transform spawner;
    public Scene[] scene;
    public GameObject phone, diskPhone;
    public Animator phoneAnim;
    public static int ind = 0;
    public static int indPhone = 0;
    public static Action<int, int> f;
    public bool cg, sl;
    void Start()
    {
        f += OnTimeTracker;
        second = 0;
        hour = 7;
        StartCoroutine(timeTicker());
    }

    public IEnumerator timeTicker()
    {
        if (CanGo)
        {
            yield return new WaitForSeconds(delay);
            if (hour == 15 && second == 0)
            {
                indPhone += 1;
                phone.SetActive(true);
            }
            if (hour == 23)
            {
                sleepwake = true;
<<<<<<< HEAD
                dRAGdROP.s = scene[ind];
                ind += 1;
=======
>>>>>>> c6e024004757b7c2c69d36cec401489adc4fa18c
                Instantiate(Kaseta, spawner);
                Instantiate(Energy, spawner);
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
            if (hour == 7 && second == 0)
            {
                sleepwake = true;
<<<<<<< HEAD
=======
                dRAGdROP.s = scene[ind];
                ind += 1;
>>>>>>> c6e024004757b7c2c69d36cec401489adc4fa18c
                if (day > 1)
                {
                    GameObject p = Instantiate(Energy, spawner);
                    p.transform.SetParent(spawner.transform);
                    p.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-104, 104), Random.Range(-169, 169));
                }
                GameObject p1 = Instantiate(Page, spawner);
                p1.transform.SetParent(spawner.transform);
                p1.GetComponent<dRAGdROP>().page = pages[ind - 1];
                p1.transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-104, 104), Random.Range(-169, 169));
            }
            StartCoroutine(timeTicker());
        }
    }
    void Update()
    {
        sl = sleepwake;
        cg = CanGo;
        d = day;
        clock.text = hour.ToString("D2") + ":" + second.ToString("D2");
    }
    public void OnTimeTracker(int h, int s)
    {
        if (Clock.hour < 23)
        {
            CanGo = true;
            StartCoroutine(timeTicker());
            second = s;
            hour = h;
            newDay.gameObject.SetActive(false);
        }
    }
    public void MinusTime()
    {
        if(Active_option.activeEvent != null)
        {
            Active_option.activeEvent.timeHour -= 1;
        }
        if (Active_option.problem == true)
        {
            PhoneDisk.time -= 1;
        }
    }
}
