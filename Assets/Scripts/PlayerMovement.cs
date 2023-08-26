using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : PlayerBaseState
{
    private Rigidbody rb;
    private PlayerControl input;
    private int speed = 10;
    
    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMove;
        input.Player.Move.started += OnMove;
        input.Player.Move.canceled += OnMove;

    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMove;
        input.Player.Move.started -= OnMove;
        input.Player.Move.canceled -= OnMove;
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementDirection = context.ReadValue<Vector2>();
        rb.velocity = new Vector3(movementDirection.x, 0f, movementDirection.y) * speed;
    }

    public void EnterState(PlayerStateMachine stateMachine)
    {
        rb = stateMachine.GetRigidbody();
        input = stateMachine.GetPlayerControl(); 
        OnEnable();
    }

    public void UpdateState(PlayerStateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDisable();
            stateMachine.SwitchState(new PlayerJump());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnDisable();
            stateMachine.SwitchState(new SummonShield());
        }
    }
}
