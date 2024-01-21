using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class dRAGdROP : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static Scene s;
    RectTransform rect;
    GameObject canvas;
    GameObject spawn;
    Image i;
    public LayerMask l;
    public void OnBeginDrag(PointerEventData eventData)
    {
        rect.SetParent(canvas.transform);
        i.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out RaycastHit hit, 1000, l))
        {
            Television.scene = s;
            Television.IsStart = true;
            Destroy(this.gameObject);
        }
        else
        {
            rect.SetParent(spawn.transform);
            rect.anchoredPosition = new Vector2(Random.Range(-104, 104), Random.Range(-169, 169));
            i.raycastTarget = true;
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
