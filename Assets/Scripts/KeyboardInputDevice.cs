using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class KeyboardInputDevice : InputDevice
    {
        public override Vector2 ReadAxis()
        {
            axis.x = Input.GetAxis("Horizontal");
            axis.y = Input.GetAxis("Vertical");
            return axis;
        }

        public override bool ReadBtnAttack()
        {
            btnAttack = Input.GetButton("Fire1");
            return btnAttack;
        }

        public override void SetDisplay(bool value)
        {
            return;
        }
    }
}

