using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject p;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
    public void pause()
    {
        p.SetActive(true);
        Time.timeScale = 0;
    }
    public void cont()
    {
        Time.timeScale = 1;
        p.SetActive(false);
    }
}
