using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SummonShield :  PlayerBaseState
{
    private GameObject ShieldPrefab;
    private Rigidbody rb;
    private PlayerControl input;
    private void OnEnable()
    {
        input.Enable();
        input.Player.Summon.performed += OnSummon;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Summon.performed -= OnSummon;
    }
    void OnSummon(InputAction.CallbackContext context)
    {
        MonoBehaviour.Instantiate(ShieldPrefab, rb.transform.position + Vector3.forward, Quaternion.identity);
    }

    public void EnterState(PlayerStateMachine stateMachine)
    {
        input = stateMachine.GetPlayerControl();
        ShieldPrefab = stateMachine.GetShieldPrefab();
        rb = stateMachine.GetRigidbody();
        OnEnable();
    }

    public void UpdateState(PlayerStateMachine stateMachine)
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
            OnDisable();
            stateMachine.SwitchState(new PlayerMovement());
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnDisable();
            stateMachine.SwitchState(new PlayerJump());
        }
    }
}
