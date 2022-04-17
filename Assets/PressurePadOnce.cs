using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class PressurePadOnce : Sensor
    {
        private void OnTriggerEnter(Collider other)
        {
            //print("trigger enter.");
            Process();
        }
    }
}

