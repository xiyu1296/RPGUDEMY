using UnityEngine;

public class playerStateMachine
{
    public playerState currentState { get; private set; }

    public void Initialize(playerState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(playerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    

}
