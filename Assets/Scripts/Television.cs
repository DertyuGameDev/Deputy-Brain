using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Television : MonoBehaviour
{
    public static Scene scene;
    public static bool IsStart = false;
    public Image picture;
    public TextMeshProUGUI title;
    public TextMeshProUGUI contiinue;
    public float speedTypeText;
    public GameObject cut;
    public int ind = 0;
    public IEnumerator TypeSyble(string sentense)
    {
        title.text = "";
        foreach (char c in sentense.ToCharArray())
        {
            title.text += c;
            yield return new WaitForSeconds(speedTypeText);
        }
    }
    private void Start()
    {
        ind = 0;
    }
    public void Update()
    {
        if (IsStart)
        {
            cut.SetActive(true);
            StartCoroutine(TypeSyble(scene.text[ind]));
            picture.sprite = scene.picture[ind];
            IsStart = false;
        }
    }
    public void Continue()
    {
        StopAllCoroutines();
        ind++;
        if (ind < scene.text.Length - 1)
        {
            contiinue.text = "Continue";
            StartCoroutine(TypeSyble(scene.text[ind]));
            picture.sprite = scene.picture[ind];
        }
        else if (ind == scene.text.Length - 1)
        {
            contiinue.text = "Exit";
            StartCoroutine(TypeSyble(scene.text[ind]));
            picture.sprite = scene.picture[ind];
        }
        else if (ind > scene.text.Length - 1)
        {
            contiinue.text = "Continue";
            Clock.CanGo = true;
            Clock.f();
            ind = 0;
        }
    }
}
