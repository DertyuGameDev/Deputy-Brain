using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGrid : MonoBehaviour
{
    public GameObject[] actGrid;
    public GameObject[] actGrid2;
    public GameObject[] actGrid3;
    public static int ind = 0;
    void Update()
    {
        if(ind == 0)
        {
            for(int i = 0; i < actGrid.Length; i++)
            {
                actGrid[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (ind == 1)
        {
            for (int i = 0; i < actGrid2.Length; i++)
            {
                actGrid2[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
        if (ind == 2)
        {
            for (int i = 0; i < actGrid3.Length; i++)
            {
                actGrid3[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
