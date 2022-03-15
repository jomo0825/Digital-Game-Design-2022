using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SPStudios.Tools;

public class DebugUI : MonoSingleton
{
    public Text txt;

    public void Print(string value)
    {

        if (txt != null)
        {
            txt.text = value;
        }
    }
}
