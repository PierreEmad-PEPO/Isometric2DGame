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
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }

    public void FixedExecute() { }
}
