using UnityEngine;

public class PlayerWalkState : IState
{
    private readonly PlayerStateMachine _stateMachine;

    public PlayerWalkState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[Walk State]: Entered");

        _stateMachine.PlayerController.PlayerAnimator.Play("Walk");

    }

    public void FixedExecute() 
    {
        // ----- Core Logic -----
        // Update Direction by input at real-time.
        _stateMachine.PlayerController.PlayerMovement.SetWalkMovement(InputManager.Instance.MoveValue);
        // Apply the movement.
        _stateMachine.PlayerController.PlayerMovement.Move();
    }

    public void Execute()
    {
        // ----- Transitions -----
        // Check the sqrMagnitude instead of Magnitude for better performance.
        if (InputManager.Instance.MoveValue.sqrMagnitude < 0.1f)
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
        else if (InputManager.Instance.RunIsPressing)
        {
            // Runnig state (bonus)
            _stateMachine.ChangeState(_stateMachine.RunState);
        }
        else if (InputManager.Instance.DodgePressed)
        {
            _stateMachine.ChangeState(_stateMachine.DodgeState);
        }
    }

    public void Exit()
    {
        
    }
}
