using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{

    public class DoorOpenAnimationRewind : Actuator
    {
        public AnimationCurve tweenCurve;

        private float curTime = 0;
        private bool isPlaying = false;
        private bool isForward = true;

        private void Update()
        {
            if (isPlaying)
            {
                transform.position = new Vector3(transform.position.x, tweenCurve.Evaluate(curTime), transform.position.z);
                curTime += Time.deltaTime * (isForward ? 1.0f : -1.0f);
                curTime = Mathf.Clamp(curTime, 0, tweenCurve.keys[tweenCurve.length - 1].time);
            }
        }

        public override void Process(object data)
        {
            isPlaying = true;
            isForward = true;
        }
        public override void Rewind(object data)
        {
            isPlaying = true;
            isForward = false;
        }
    }
}


