using UnityEngine;

public class playerIdleState : playerGroundState
{
    public playerIdleState( player _player,playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
        if(xInput != 0)
            Player.PlayerStateMachine.ChangeState(Player.MoveState);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
