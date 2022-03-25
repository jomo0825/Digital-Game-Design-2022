using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPStudios.Tools;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    public float speed = 5.0f;
    public Animator anim;

    private Vector3 moveVec;
    private Material mat;
    private CharacterController cc;

    private void Start()
    {
        mat = GetComponent<Renderer>()?.material;
        cc = GetComponent<CharacterController>();

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
            
            anim.SetFloat("speed", moveVec.magnitude);
            if (moveVec.magnitude > .02f)
            {
                anim.transform.forward = moveVec;
            }
        }
    }

    private void OnEnable()
    {
        Singletons.Get<MyFramework.InputManager>().IsAxis.AddListener(MoveCharacter);
        Singletons.Get<MyFramework.InputManager>().OnBtnAttack.AddListener(RandomColor);
    }

    private void OnDisable()
    {
        Singletons.Get<MyFramework.InputManager>().IsAxis.RemoveListener(MoveCharacter);
        Singletons.Get<MyFramework.InputManager>().OnBtnAttack.RemoveListener(RandomColor);
    }

    public void MoveCharacter(Vector2 axis)
    {
        moveVec.x = axis.x;
        moveVec.y = 0;
        moveVec.z = axis.y;
        //transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
        cc.SimpleMove(moveVec * speed);
    }

    public void RandomColor()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }


}
