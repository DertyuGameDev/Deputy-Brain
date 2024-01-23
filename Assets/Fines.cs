using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fines : MonoBehaviour
{
    public static int fines;
    public Image[] fines_image;
    public Scene thirdFine;
    void Update()
    {
        if (fines > 0)
        {
            fines_image[fines - 1].color = Color.red;
        }
        if (fines >= 3)
        {
            Television.scene = thirdFine;
            Television.IsStart = true;
        }
    }
}
