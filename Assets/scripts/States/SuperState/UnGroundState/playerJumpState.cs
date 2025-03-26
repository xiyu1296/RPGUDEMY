using UnityEngine;

public class playerJumpState : playerState
{
    public playerJumpState(player _player, playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Player.jumpforce);
    }
    
    public override void Update()
    {
        base.Update();
        
        if(rb.linearVelocity.y < 0)
            Player.PlayerStateMachine.ChangeState(Player.AirState);
        Player.setVelocity(xInput*Player.movespeed,rb.linearVelocity.y);

    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
