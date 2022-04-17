using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFramework
{
    public class CameraArm : MonoBehaviour
    {
        public float length = 2.5f;
        public Vector3 offset = Vector3.zero;
        public GameObject targetObj;

        [SerializeField]
        private float pitchAngle = -20.0f;

        public void SetPitchAngle(object angle)
        {
            pitchAngle = Mathf.Clamp(pitchAngle + (float)angle, -45.0f, 45.0f);
        }

        private void Awake()
        {
        }

        private void Start()
        {
            if (targetObj == null)
            {
                enabled = false;
                return;
            }
            transform.position = CalculateHardTargetPos();
        }

        private void LateUpdate()
        {
            MoveCamera();
            RotateCamera();
        }

        protected virtual void RotateCamera()
        {
                transform.LookAt(targetObj.transform.position + offset);
        }

        protected virtual void MoveCamera()
        {
            MoveToHardTargetPos();
        }

        protected Vector3 CalculateHardTargetPos()
        {
                Vector3 startPos = targetObj.transform.position + offset;
                Quaternion forwardQuat = Quaternion.LookRotation(Vector3.ProjectOnPlane(-targetObj.transform.forward, Vector3.up), Vector3.up);
                forwardQuat = forwardQuat * Quaternion.Euler(pitchAngle, 0, 0);
                Vector3 targetPos = startPos + (forwardQuat * Vector3.forward) * length;
                return targetPos;
        }

        private void MoveToHardTargetPos()
        {
            transform.position = targetObj.transform.position + targetObj.transform.TransformVector(offset);
            transform.forward = Vector3.ProjectOnPlane(-targetObj.transform.forward, Vector3.up);
            transform.Rotate(pitchAngle, 0, 0, Space.Self);
            transform.position = transform.position + transform.forward * length;
        }
    }
}

