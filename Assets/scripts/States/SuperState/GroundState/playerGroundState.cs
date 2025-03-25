using UnityEngine;

public class playerGroundState : playerState
{
    public playerGroundState(player _player, playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
        
        if(Input.GetKeyDown(KeyCode.Space) && Player.isGroundedCheck())
            Player.PlayerStateMachine.ChangeState(Player.JumpState);
        
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
