using UnityEngine;

public class PlayerDodgeState : IState
{
    private readonly PlayerStateMachine _stateMachine;

    public PlayerDodgeState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[Dodge State]: Entered");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

    public void FixedExecute() { }
}
