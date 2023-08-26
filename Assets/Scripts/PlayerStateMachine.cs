using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private GameObject ShieldPrefab;
    private Rigidbody rb;
    private PlayerControl input;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        input = new PlayerControl();
    }
    public PlayerBaseState CurrentState { get; private set; }
    private void Start()
    {
        SwitchState(new PlayerMovement()); 
    }
    private void Update()
    {
        CurrentState.UpdateState(this);
    }
    public void SwitchState(PlayerBaseState baseState)
    {
        CurrentState = baseState;
        CurrentState.EnterState(this);
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    public PlayerControl GetPlayerControl()
    {
        return input;
    }
    public GameObject GetShieldPrefab()
    {
        return ShieldPrefab;
    }
}
