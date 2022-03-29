using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class KeyboardInputDevice : InputDevice
    {
        public override Vector2 ReadAxisMove()
        {
            axisMove.x = Input.GetAxis("Horizontal");
            axisMove.y = Input.GetAxis("Vertical");
            return axisMove;
        }

        public override Vector2 ReadAxisRotate()
        {
            axisRotate.x = Input.GetAxis("Mouse X");
            axisRotate.y = Input.GetAxis("Mouse Y");
            return axisRotate ;
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

