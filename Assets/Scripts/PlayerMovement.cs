using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControl input;
    [SerializeField] private int speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerControl();
    }
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
}
