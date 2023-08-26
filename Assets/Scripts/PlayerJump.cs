using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : PlayerBaseState
{
    private int jumpForce = 5;
    private Rigidbody rb;
    private PlayerControl input;
    private void OnEnable()
    {
        input.Enable();
        input.Player.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Jump.performed -= OnJump;
    }
    private void OnJump (InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void EnterState(PlayerStateMachine stateMachine)
    {
        rb = stateMachine.GetRigidbody();
        input = stateMachine.GetPlayerControl(); ;
        OnEnable();
    }

    public void UpdateState(PlayerStateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnDisable();
            stateMachine.SwitchState(new SummonShield());
        }
        if(Input.GetKeyDown(KeyCode.S) ||Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)) {
            OnDisable();
            stateMachine.SwitchState(new PlayerMovement());
        }
    }
}
