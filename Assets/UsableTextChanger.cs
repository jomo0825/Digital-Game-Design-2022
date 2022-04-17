using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyFramework
{
    public class UsableTextChanger : Actuator
    {
        public Text txt;

        public override void Enable(object data)
        {
            txt.enabled = true;
            txt.text = (string)data;
        }

        public override void Disable(object data)
        {
            txt.enabled = false;
        }
    }
}

