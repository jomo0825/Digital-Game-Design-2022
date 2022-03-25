using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class TouchInputDevice : InputDevice
    {
        public Joystick joystick;
        public JoystickButton buttonA;

        public override Vector2 ReadAxis()
        {
            if (joystick == null)
            {
                return Vector2.zero;
            }
            axis.x = joystick.Horizontal;
            axis.y = joystick.Vertical;
            return axis;
        }

        public override bool ReadBtnAttack()
        {
            if (buttonA == null)
            {
                return false;
            }
            btnAttack = buttonA.btnState;
            return btnAttack;
        }

        public override void SetDisplay(bool value)
        {
            joystick.gameObject.SetActive(value);
            buttonA.gameObject.SetActive(value);
        }
    }
}

