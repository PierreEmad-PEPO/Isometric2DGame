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
    }

    public void FixedExecute()
    {

    }

    public void Execute()
    {
        

    }

    public void Exit() {  }
}