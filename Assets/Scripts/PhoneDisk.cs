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
    public LayerMask l;
    public Image background, thisback;
    public string phones;
    public static bool nol = true;
    public TextMeshProUGUI text;
    public Dictionary<string, PhoneCall> calls;
    public TextMeshProUGUI conv;
    public GameObject spawner;
    public PhoneCall[] ph;
    public PhoneCall exit;
    private void Start()
    {
        calls = new Dictionary<string, PhoneCall>();
        calls.Add("19415", ph[0]);
    }
    void Update()
    {
        text.text = phones;
        Ray r = new Ray(lim.transform.position, new Vector3(0, 0, 1) * 100);
        if(Physics.Raycast(r, out RaycastHit hit, 10000, l) && RotationPhone.can == true)
        {
            if (hit.collider.transform.rotation.eulerAngles.z <= 34 && hit.collider.transform.rotation.eulerAngles.z > 5 && nol == true && phones.Length < 5)
            {
                phones += 0;
                nol = false;
            }
            else
            {
                if(Input.GetMouseButtonUp(0) == true && RotationPhone.can == true && phones.Length < 5)
                {
                    phones += hit.collider.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
                }
            }
        }
    }
    public void StartDisk()
    {
        thisback.gameObject.SetActive(true);
        thisback.transform.SetAsLastSibling();
        phones = "";
    }
    public void Phone()
    {
        if(calls.Keys.Contains(phones))
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
