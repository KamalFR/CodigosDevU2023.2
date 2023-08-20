using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    private Rigidbody rb;
    private PlayerControl input;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerControl();
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void OnJump (InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
