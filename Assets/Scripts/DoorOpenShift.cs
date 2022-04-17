using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class DoorOpenShift : Actuator
    {
        public override void Process(object data)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }
    }
}

