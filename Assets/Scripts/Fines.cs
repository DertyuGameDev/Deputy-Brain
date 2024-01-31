using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fines : MonoBehaviour
{
    public static int fines;
    public Image[] fines_image;
    public Scene thirdFine;
    public Sprite red;
    void Update()
    {
        if (fines > 0)
        {
            fines_image[fines - 1].sprite = red;
        }
        if (fines >= 3)
        {
            Television.scene = thirdFine;
            Television.IsStart = true;
        }
    }
}
