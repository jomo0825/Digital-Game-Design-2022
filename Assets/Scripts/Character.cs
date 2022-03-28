using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPStudios.Tools;

namespace MyFramework
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        public float speed = 5.0f;
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
            Singletons.Get<MyFramework.InputManager>().IsAxis.AddListener(MoveCharacter);
        }

        private void OnDisable()
        {
            Singletons.Get<MyFramework.InputManager>().IsAxis.RemoveListener(MoveCharacter);
        }

        // Character motor function.
        public void MoveCharacter(Vector2 axis)
        {
            moveVec.x = axis.x;
            moveVec.y = 0;
            moveVec.z = axis.y;
            //transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
            cc?.SimpleMove(moveVec * speed);
        }
    }
}
