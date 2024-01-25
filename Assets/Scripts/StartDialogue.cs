using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public class StartDialogue : MonoBehaviour
{
    public int ind = 0;
    public Image background;
    public PhoneCall[] BaseStarters;
    public TextMeshProUGUI conv;
    public GameObject spawner, phone;
    public static Action<Transition> update;
    public GameObject portrait;
    private void Start()
    {
        update += Continue;
    }
    public void Click()
    {
        background.gameObject.SetActive(true);
        ind = Clock.indPhone;
        BaseStarters[ind].Starter(conv, spawner);
        StartCoroutine(TypeSyble(conv, BaseStarters[ind].NPConversations));
        portrait.SetActive(true);
        phone.SetActive(false);
    }
    public void Continue(Transition newConv)
    {
        if (newConv.transitions != null)
        {
            StopAllCoroutines();
            GameObject[] obj = GameObject.FindGameObjectsWithTag("OptionChoice");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i]);
            }
            StartCoroutine(TypeSyble(conv, newConv.transitions.NPConversations));
            for (int i = 0; i < newConv.transitions.Choices.Length; i++)
            {
                GameObject t = Instantiate(newConv.transitions.PrefChoice, spawner.transform);
                t.GetComponent<TextMeshProUGUI>().text = newConv.transitions.Choices[i];
            }
        }
        else
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag("OptionChoice");
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i]);
            }
            conv.text = "";
            portrait.SetActive(false);
            background.gameObject.SetActive(false);
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
