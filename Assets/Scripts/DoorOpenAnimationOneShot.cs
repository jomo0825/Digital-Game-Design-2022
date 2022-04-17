using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework {

    public class DoorOpenAnimationOneShot : Actuator
    {
        public AnimationCurve tweenCurve;

        private float curTime = 0;
        private bool isPlaying = false;

        private void Update()
        {
            if (isPlaying)
            {
                transform.position = new Vector3(transform.position.x, tweenCurve.Evaluate(curTime), transform.position.z);
                curTime += Time.deltaTime;
            }
        }

        public override void Process(object data)
        {
            curTime = 0;
            isPlaying = true;
        }
    }
}


