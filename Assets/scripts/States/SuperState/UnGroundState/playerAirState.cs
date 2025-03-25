using UnityEngine;

public class playerAirState : playerState
{
    public playerAirState(player _player, playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
        
        if(rb.linearVelocity.y == 0 )
            Player.PlayerStateMachine.ChangeState(Player.IdleState);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
