using UnityEngine;

public class PlayerIdleState : IState
{
    private readonly PlayerStateMachine _stateMachine;

    public PlayerIdleState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter() 
    {
        Debug.Log("[Idle State]: Entered");

        // Stop Player Movement.
        _stateMachine.PlayerController.PlayerMovement.SetIdleMovement();
    }

    public void FixedExecute()
    {
        // Move by zero (Force Stop).
        _stateMachine.PlayerController.PlayerMovement.Move();
    }

    public void Execute()
    {
        // ----- Transitions -----
        // Check the sqrMagnitude instead of Magnitude for better performance.
        if (InputManager.Instance.MoveValue.sqrMagnitude > 0.1f)
        {
            _stateMachine.ChangeState(_stateMachine.WalkState);
        }
        else if (InputManager.Instance.DodgePressed)
        {
            _stateMachine.ChangeState(_stateMachine.DodgeState);
        }
    }

    public void Exit() {  }
}