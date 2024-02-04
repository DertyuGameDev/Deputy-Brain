using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PS : MonoBehaviour
{
    public Image lamp;
    public Sprite gray, red, green, yellow;
    public Slider slider;
    int position;
    public static Event sleep;
    public Event s;
    public GameObject p, ps;
    public static bool problem;
    public bool fine;
    private void Start()
    {
        problem = false;
    }
    private void Update()
    {
        s = sleep;
        if (sleep != null)
        {
            position = sleep.position[0];
            lamp.sprite = yellow;
        }
        if (slider.value == 1 && sleep != null && Clock.sleepwake == true)
        {
            Checker();
        }
        if (GameObject.FindGameObjectWithTag("SLEEP") != null)
        {
            p = GameObject.FindGameObjectWithTag("SLEEP");
            p.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = s.position[0].ToString();
        }
    }
    public void Checker()
    {
        if (this.transform.parent.parent.name == "Grid")
        {
            bool IsOk = true;
            if (ps.transform.parent.parent.name != "Grid")
            {
                IsOk = false;
            }
            if (ps.transform.GetChild(5).GetComponent<Slider>().value != position)
            {
                IsOk = false;
            }
            if (IsOk)
            {
                sleep = null;
                position = 0;
                int r = Random.Range(1, 101);
                if (r > 50)
                {
                    Active_option.problem = true;
                }
                else
                {
                    problem = false;
                    StartCoroutine(color(green, gray));
                }
                Destroy(p);
                p = null;
                Clock.sleepwake = false;
                Clock.CanGo = true;
                Clock.f(Clock.hour, Clock.second);
            }
            else
            {
                sleep = null;
                position = 0;
                StartCoroutine(color(red, gray));
                slider.value = 0;
                Fines.fines += 1;
                fine = true;
            }
        }
        if (fine)
        {
            StartCoroutine(stop());
            fine = false;
        }
        slider.value = 0;
    }
    public IEnumerator color(Sprite k1, Sprite k2)
    {
        lamp.sprite = k1;
        yield return new WaitForSeconds(1);
        lamp.sprite = k2;
    }
    public IEnumerator stop()
    {
        Clock.sleepwake = false;
        yield return new WaitForSeconds(1f);
        slider.value = 0;
        Clock.sleepwake = true;
    }
}
