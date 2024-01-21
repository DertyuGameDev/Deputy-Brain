using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class Scene : ScriptableObject
{
    [TextArea(1, 2)]
    public string[] text;
    public Sprite[] picture;
}
