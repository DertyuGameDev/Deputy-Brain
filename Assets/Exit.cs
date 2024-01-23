using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void Exit1()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}
