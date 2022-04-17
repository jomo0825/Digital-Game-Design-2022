using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class CameraSpringArm : CameraArm
    {
        public float k = 500.0f;
        public float damp = 0.5f;

        private Vector3 springSpeed = Vector3.zero;

        protected override void MoveCamera()
        {
            Vector3 delta = CalculateHardTargetPos() - transform.position;
            Vector3 force = k * delta.magnitude * delta.magnitude * delta.normalized;
            Vector3 acc = force;
            springSpeed += acc * Mathf.Clamp(Time.deltaTime, 0, 0.05f);
            springSpeed = springSpeed * damp;
            transform.position += springSpeed * Mathf.Clamp(Time.deltaTime, 0, 0.05f);
        }
    }
}
