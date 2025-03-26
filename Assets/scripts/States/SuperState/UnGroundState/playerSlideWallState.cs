using UnityEngine;

public class playerSlideWallState : playerState
{
    public playerSlideWallState(player _player, playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();

        if(yInput < 0)
            Player.setVelocity(xInput*Player.movespeed, rb.linearVelocity.y);
        else
            Player.setVelocity(xInput*Player.movespeed, rb.linearVelocity.y*0.7f);

        
        
        if(Input.GetKeyDown(KeyCode.Space))
            Player.PlayerStateMachine.ChangeState(Player.JumpWall);
        if (!Player.isWalledCheck() && !Player.isGroundedCheck())
            Player.PlayerStateMachine.ChangeState(Player.AirState);
        if(Player.isGroundedCheck())
            Player.PlayerStateMachine.ChangeState(Player.IdleState);
        
        
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
