using UnityEngine;

public class playerAttackState :playerState
{
    public playerAttackState( player _player,playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }
    
    public override void Update()
    {
        base.Update();
        Player.setVelocity(0,0);
        if(AnimationFinishtrigger == true)
            Player.PlayerStateMachine.ChangeState(Player.IdleState);


    }
    
    public override void Exit()
    {
        base.Exit();
    }
}
