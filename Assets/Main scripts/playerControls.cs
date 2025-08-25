using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControls : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    private Vector3 moveInputValue;

    private void OnMovment(InputValue value)
    {
        moveInputValue = value.Get<Vector3>();
        Debug.Log("its Working!!");
    }

    private void MoveLogicMethod()
    {
        Vector3 result = moveInputValue * speed * Time.fixedDeltaTime;
        rb.velocity = result;
    }

    private void FixedUpdate()
    {
        MoveLogicMethod();
    }

}
