using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPStudios.Tools;

namespace MyFramework
{
    public class Usable : Sensor
    {
        public string textToDisplay = "Press E to interact.";

        private bool readyToUse = false;
        private bool used = false;

        // Hook/release character motor functions to input manager.
        private void OnEnable()
        {
            // Use singleton plugin.
            Singletons.Get<MyFramework.InputManager>().IsBtnAttack.AddListener(Use);
        }

        private void OnDisable()
        {
            Singletons.Get<MyFramework.InputManager>().IsBtnAttack.RemoveListener(Use);
        }

        private void Use(bool actionState)
        {
            if (actionState && used == false && readyToUse == true)
            {
                Process();
                used = true;
                readyToUse = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (used == false)
            {
                readyToUse = true;
                Enable((object)textToDisplay);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (used == false)
            {
                readyToUse = false;
                Disable((object)textToDisplay);
            }
        }
    }
}

