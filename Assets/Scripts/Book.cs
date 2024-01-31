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
    public Transform leftsp, rightsp;
    public List<GameObject> pages;
    public int ind = 0;
    public GameObject empty;
    public Action<GameObject> add;
    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }
    void Start()
    {
        rect = GetComponent<RectTransform>();
        Instantiate(pages[ind], leftsp);
        Instantiate(pages[ind + 1], rightsp);
        add += AddPage;
    }
    private void Update()
    {
        if (pages.Count % 2 != 0)
        {
            pages.Add(empty);
        }
    }
    public void forward()
    {
        if (ind + 2 <= pages.Count - 2)
        {
            ind += 2;
            Destroy(leftsp.GetChild(0).gameObject);
            Destroy(rightsp.GetChild(0).gameObject);
            Instantiate(pages[ind], leftsp);
            Instantiate(pages[ind + 1], rightsp);
        }
    }
    public void back()
    {
        if (ind - 2 >= 0)
        {
            ind -= 2;
            Destroy(leftsp.GetChild(0).gameObject);
            Destroy(rightsp.GetChild(0).gameObject);
            Instantiate(pages[ind], leftsp);
            Instantiate(pages[ind + 1], rightsp);
        }
    }
    public void first()
    {
        ind = 0;
        Destroy(leftsp.GetChild(0).gameObject);
        Destroy(rightsp.GetChild(0).gameObject);
        Instantiate(pages[ind], leftsp);
        Instantiate(pages[ind + 1], rightsp);
    }
    public void AddPage(GameObject page)
    {
        if (pages[pages.Count - 1] == empty)
        {
            pages[pages.Count - 1] = page;
        }
        else
        {
            pages.Add(page);
        }
    }
}
