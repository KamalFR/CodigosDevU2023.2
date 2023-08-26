using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerBaseState
{
    public void EnterState(PlayerStateMachine stateMachine);
    public void UpdateState(PlayerStateMachine stateMachine);
}
