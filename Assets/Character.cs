using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SPStudios.Tools;

public class Character : MonoBehaviour
{
    public float speed = 5.0f;
    
    private Vector3 moveVec;
    private Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>()?.material;
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

    public void MoveCharacter(Vector2 axis) {
        moveVec.x = axis.x;
        moveVec.y = 0;
        moveVec.z = axis.y;
        transform.Translate(moveVec * speed * Time.deltaTime, Space.World);
    }

    public void RandomColor()
    {
        mat.color = new Color(Random.value, Random.value, Random.value);
    }


}
