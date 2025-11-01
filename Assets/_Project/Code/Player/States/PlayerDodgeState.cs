using UnityEngine;

public class PlayerDodgeState : IState
{
    private readonly PlayerStateMachine _stateMachine;

    private readonly float _dodgeSpeed = 10;
    private readonly float _dodgeTime = 0.2f;
    private float _elapsedTime = 0;
    private Vector2 _dodgeDirection;

    public PlayerDodgeState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[Dodge State]: Entered");

        _elapsedTime = 0;
        _dodgeDirection = InputManager.Instance.MoveValue;
        _stateMachine.PlayerController.PlayerMovement.SetIdleMovement();
    }

    public void FixedExecute()
    {
        _stateMachine.PlayerController.PlayerMovement.ForceSetVelocity(
            _dodgeDirection.normalized * _dodgeSpeed);

        _elapsedTime += Time.fixedDeltaTime;
    }

    public void Execute()
    {
        if (_elapsedTime >= _dodgeTime)
        {
            _stateMachine.ReturnToPreviousState();
        }
    }

    public void Exit()
    {

    }
}
