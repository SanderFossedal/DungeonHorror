using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public static TextManager instance;
    private void Awake()
    {
        instance= this;
    }

    public void changeText(string text)
    {
        textMeshPro.text = text;
    }

    public void disableText()
    {
        textMeshPro.text = "";
    }
}
