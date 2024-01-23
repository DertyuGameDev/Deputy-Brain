using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Book : MonoBehaviour, IDragHandler
{
    RectTransform rect;
    [TextArea]
    public List<string> pages;
    public int ind = 0;
    public TextMeshProUGUI left, right;
    public Action<string> add;
    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }
    void Start()
    {
        rect = GetComponent<RectTransform>();
        left.text = pages[ind];
        right.text = pages[ind + 1];
        add += AddPage;
    }
    private void Update()
    {
        if (pages.Count % 2 != 0)
        {
            pages.Add("");
        }
    }
    public void forward()
    {
        if (ind + 2 <= pages.Count - 2)
        {
            ind += 2;
            left.text = pages[ind];
            right.text = pages[ind + 1];
        }
    }
    public void back()
    {
        if (ind - 2 >= 0)
        {
            ind -= 2;
            left.text = pages[ind];
            right.text = pages[ind + 1];
        }
    }
    public void first()
    {
        ind = 0;
        left.text = pages[ind];
        right.text = pages[ind + 1];
    }
    public void AddPage(string text)
    {
        if (pages[pages.Count - 1] == "")
        {
            pages[pages.Count - 1] = text;
        }
        else
        {
            pages.Add(text);
        }
    }
}
