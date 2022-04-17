using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class PressurePadRewind : Sensor
    {
        private void OnTriggerStay(Collider other)
        {
            //SendMessage("Send", (object)InteractionType.Activate);
            Process();
        }

        private void OnTriggerExit()
        {
            //SendMessage("Send", (object)InteractionType.Reset);
            Rewind();
        }
    }
}

