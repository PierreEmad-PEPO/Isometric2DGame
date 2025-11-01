using UnityEngine;

public class PlayerRunState : IState
{
    private readonly PlayerStateMachine _stateMachine;

    public PlayerRunState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        Debug.Log("[Run State]: Entered");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }

    public void FixedExecute() { }
}
