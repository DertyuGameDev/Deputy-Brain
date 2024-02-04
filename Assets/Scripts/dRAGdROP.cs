using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Random = UnityEngine.Random;

public class dRAGdROP : MonoBehaviour
{
    public static Scene s;
    RectTransform rect;
    GameObject canvas;
    GameObject spawn;
    Image i;
    public Change ch;
    public LayerMask l, grid, book;
    public GameObject page;
    public enum Change
    {
        kaseta,
        energy,
        page
    }
    public void Check()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ch == Change.kaseta)
        {
            if (Physics.Raycast(r, out RaycastHit hit, 1000, l) && GameObject.FindGameObjectWithTag("task").transform.childCount < 1)
            {
                Television.scene = s;
                Television.IsStart = true;
                Destroy(this.gameObject);
            }
            else
            {
                rect.SetParent(spawn.transform);
                rect.transform.position = spawn.transform.position;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                rect.anchoredPosition = new Vector2(Random.Range(-80, 80), 283);
                i.raycastTarget = true;
            }
        }
        else if (ch == Change.energy)
        {
            if (Physics.Raycast(r, out RaycastHit hit, 1000, grid))
            {
                ActiveGrid.ind += 1;
                Destroy(this.gameObject);
            }
            else
            {
                rect.SetParent(spawn.transform);
                rect.transform.position = spawn.transform.position;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                rect.anchoredPosition = new Vector2(Random.Range(-80, 80), 283);
                i.raycastTarget = true;
            }
        }
        else if (ch == Change.page)
        {
            if (Physics.Raycast(r, out RaycastHit hit, 1000, book))
            {
                Share.book.GetComponent<Book>().add(page);
                Destroy(this.gameObject);
            }
            else
            {
                rect.SetParent(spawn.transform);
                rect.transform.position = spawn.transform.position;
                this.gameObject.GetComponent<Rigidbody>().useGravity = true;
                rect.anchoredPosition = new Vector2(Random.Range(-80, 80), 283);
                i.raycastTarget = true;
            }
        }
    }
    void Start()
    {
        rect = GetComponent<RectTransform>();
        spawn = this.transform.parent.gameObject;
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        i = GetComponent<Image>();
    }
}
