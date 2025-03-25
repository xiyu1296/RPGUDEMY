using UnityEngine;

public class playerMoveState : playerGroundState
{
    public playerMoveState( player _player,playerStateMachine _playerStateMachine, string _aniboolname) : base( _player, _playerStateMachine,_aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
        
        Player.setVelocity(xInput * Player.movespeed,rb.linearVelocity.y);
        
        if(xInput == 0 )
            Player.PlayerStateMachine.ChangeState(Player.IdleState);
        
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
