using UnityEngine;

public class playerJumpWallState : playerState
{
    public playerJumpWallState(player _player, playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        
        Player.setVelocity(Player.bounceforce * -Player.faceDir,Player.jumpforce);
    }
    
    public override void Update()
    {
        base.Update();
        if(rb.linearVelocity.y < 0)
            Player.PlayerStateMachine.ChangeState(Player.AirState);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
