using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "Call", menuName = "Call", order = 1)]
public class PhoneCall : ScriptableObject
{
    public string NPConversations;
    public string[] Choices;
    public PhoneCall[] transitions;
    public GameObject PrefChoice;
    public void Starter(TextMeshProUGUI conv, GameObject spawn)
    {
        for (int i = 0; i < Choices.Length; i++)
        {
            GameObject t = Instantiate(PrefChoice, spawn.transform);
            t.GetComponent<TextMeshProUGUI>().text = Choices[i];
            t.GetComponent<Transition>().transitions = transitions[i];
        }
    }
}
