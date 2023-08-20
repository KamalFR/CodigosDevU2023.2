using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SummonShield : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPrefab;
    private PlayerControl input;
    private void Awake()
    {
        input = new PlayerControl();
    }
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
        Instantiate(ShieldPrefab, transform.position + Vector3.forward, Quaternion.identity);
    }
}
