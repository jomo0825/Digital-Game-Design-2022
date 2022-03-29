using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPStudios.Tools;
using System;

namespace MyFramework
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        public float camYawSpeed = 250f;
        public float camPitchSpeed = 50f;
        public Animator anim;
        public CharacterController cc;

        private Vector3 moveVec;

        private void Start()
        {
            // Make cursor invisible and lock it at center of screen.
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            //Avoid null reference for anim. This happens when you forgot to assign an instance to the variable anim.
            if (anim != null)
            {
                //Test whether or not the animator is under Locomotion state.
                //print(anim.GetCurrentAnimatorStateInfo(0).IsName("Locomotion"));

                if (moveVec.magnitude > .1f)
                {
                    anim.transform.forward = moveVec;
                }

                anim.SetFloat("speed", moveVec.magnitude);
            }
        }

        // Hook/release character motor functions to input manager.
        private void OnEnable()
        {
            // Use singleton plugin.
            Singletons.Get<MyFramework.InputManager>().IsAxisMove.AddListener(MoveCharacter);
            Singletons.Get<MyFramework.InputManager>().IsAxisRotate.AddListener(RotateCamera);
        }

        private void OnDisable()
        {
            Singletons.Get<MyFramework.InputManager>().IsAxisMove.RemoveListener(MoveCharacter);
            Singletons.Get<MyFramework.InputManager>().IsAxisRotate.RemoveListener(RotateCamera);
        }

        private void RotateCamera(Vector2 axis)
        {
            Quaternion modelRot = anim.transform.rotation;
            transform.Rotate(Vector3.up, axis.x * camYawSpeed * Time.deltaTime);
            anim.transform.rotation = modelRot;

            Camera.main.SendMessage("SetPitchAngle", (object)(axis.y * camPitchSpeed * Time.deltaTime), SendMessageOptions.DontRequireReceiver);
        }

        // Character motor function.
        public void MoveCharacter(Vector2 axisMove)
        {
            moveVec.x = axisMove.x;
            moveVec.y = 0;
            moveVec.z = axisMove.y;
            moveVec = transform.TransformVector(moveVec);
            //transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
            cc?.SimpleMove(moveVec * moveSpeed);
        }
    }
}
