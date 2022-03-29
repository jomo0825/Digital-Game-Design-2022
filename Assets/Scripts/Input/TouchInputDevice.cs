using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class TouchInputDevice : InputDevice
    {
        public Joystick joystickMove;
        public Joystick joystickRotate;
        public JoystickButton buttonA;

        public override Vector2 ReadAxisMove()
        {
            if (joystickMove == null)
            {
                return Vector2.zero;
            }
            axisMove.x = joystickMove.Horizontal;
            axisMove.y = joystickMove.Vertical;
            return axisMove;
        }

        public override Vector2 ReadAxisRotate()
        {
            if (joystickRotate == null)
            {
                return Vector2.zero;
            }
            axisRotate.x = joystickRotate.Horizontal;
            axisRotate.y = joystickRotate.Vertical;
            return axisRotate;
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
            joystickMove.gameObject.SetActive(value);
            buttonA.gameObject.SetActive(value);
        }
    }
}

