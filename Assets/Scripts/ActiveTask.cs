using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTask : MonoBehaviour
{
    bool Op = false;
    public Vector3 v;
    public void B(GameObject g)
    {
        if (Op == true)
        {
            g.GetComponent<RectTransform>().anchoredPosition = v + new Vector3(0, 0, -17);
            this.gameObject.SetActive(false);
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            g.GetComponent<RectTransform>().anchoredPosition = new Vector3(90000, 0, -17);
            this.gameObject.SetActive(true);
        }
        Op = !Op;
    }
    private void Start()
    {
        Op = true;
    }
}
