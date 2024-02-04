using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class PhoneDisk : MonoBehaviour
{
    public GameObject lim;
    public LayerMask l, l1;
    public Image background, lamp;
    public string phones;
    public static bool nol = true;
    public TextMeshProUGUI text;
    public static Dictionary<string, PhoneCall> calls, extra;
    public TextMeshProUGUI conv;
    public GameObject spawner;
    public PhoneCall[] ph, ex;
    public PhoneCall exit;
    public Sprite s;
    bool c;
    public bool actPr;
    public static int time = -1;
    GameObject o;
    private void Start()
    {
        calls = new Dictionary<string, PhoneCall>();
        extra = new Dictionary<string, PhoneCall>();
        extra.Add("19415", ex[0]);
    }
    public void Update()
    {
        actPr = Active_option.problem;
        if (time == -1 && Active_option.problem == true)
        {
            time = 3;
        }
        else if (time <= 0 && Active_option.problem == true)
        {
            Fines.fines += 1;
            Active_option.problem = false;
            time = -1;
            lamp.sprite = s;
        }
        c = RotationPhone.can;
        text.text = phones;
        Ray r = new Ray(lim.transform.position, new Vector3(0, 0, 1) * 100);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, 10000, l) && c == true)
        {
            o = hit.collider.gameObject;
            if (o.transform.rotation.eulerAngles.z <= 34 && o.transform.rotation.eulerAngles.z > 5 && nol == true && phones.Length < 5)
            {
                phones += 0;
                nol = false;
            }
            else
            {
                if (Input.GetMouseButtonUp(0) && phones.Length < 5 && Physics.Raycast(ray, 10000, l1))
                {
                    phones += o.transform.GetComponent<NumberOnPhone>().num.ToString();
                }
            }
        }
        else
        {
            o = null;
        }
    }
    public void Phone()
    {
        if (Active_option.problem == true && extra.Keys.Contains(phones) && time != 0)
        {
            background.gameObject.SetActive(true);
            extra[phones].Starter(conv, spawner);
            StartCoroutine(TypeSyble(conv, extra[phones].NPConversations));
            phones = "";
            Active_option.problem = false;
            lamp.sprite = s;
        }
        else if (calls.Keys.Contains(phones))
        {
            background.gameObject.SetActive(true);
            calls[phones].Starter(conv, spawner);
            StartCoroutine(TypeSyble(conv, calls[phones].NPConversations));
            phones = "";
        }
        else
        {
            background.gameObject.SetActive(true);
            exit.Starter(conv, spawner);
            StartCoroutine(TypeSyble(conv, exit.NPConversations));
            phones = "";
        }
    }
    public IEnumerator TypeSyble(TextMeshProUGUI conv, string sentense)
    {
        conv.text = "";
        foreach (char c in sentense.ToCharArray())
        {
            conv.text += c;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
