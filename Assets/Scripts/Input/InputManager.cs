using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SPStudios.Tools;

namespace MyFramework
{
    public class InputManager : MonoSingleton
    {
        private InputDevice device;

        public UnityEvent<Vector2> IsAxisMove;
        public UnityEvent<Vector2> IsAxisRotate;
        public UnityEvent<bool> IsBtnAttack;
        public UnityEvent OnBtnAttack;

        private bool lastBtnAttack = false;
        private bool newBtnAttack = false;

        void Start()
        {
            device = FindObjectOfType<TouchInputDevice>();

            if (Application.platform == RuntimePlatform.Android)
            {
                device?.SetDisplay(true);
            }
            else
            {
                device?.SetDisplay(false);
                device = FindObjectOfType<KeyboardInputDevice>();
            }

            if (device == null)
            {
                print("Find input device error.");
                enabled = false;
            }
        }

        void Update()
        {
            Singletons.Get<DebugUI>().Print(device?.ReadAxisMove().ToString() + "\n" + device?.ReadBtnAttack().ToString());
            IsAxisMove?.Invoke(device.ReadAxisMove());
            IsAxisRotate?.Invoke(device.ReadAxisRotate());
            IsBtnAttack?.Invoke(device.ReadBtnAttack());

            newBtnAttack = device.ReadBtnAttack();
            if (newBtnAttack != lastBtnAttack && newBtnAttack == true)
            {
                OnBtnAttack?.Invoke();
            }
            lastBtnAttack = newBtnAttack;
        }
    }


}

