using UnityEngine;

public class playerAttackState :playerState
{
    public playerAttackState( player _player,playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        if (Player.AttackNum > 2 || Time.time > Player.LastAttackTime + Player.ComboWindow)
            Player.AttackNum = 0;

    }
    
    public override void Update()
    {
        base.Update();
        
        float attackDir = Player.faceDir;
        
        if (xInput != 0)
            attackDir = xInput;
        
        Player.setVelocity(Player.AttackMovement[Player.AttackNum] * attackDir ,rb.linearVelocity.y);

        if(AnimationFinishtrigger == true)
            Player.PlayerStateMachine.ChangeState(Player.IdleState);
        
    }
    
    public override void Exit()
    {
        Player.ZeroVelocity();

        Player.AttackNum++;
        Player.LastAttackTime = Time.time;
        
        base.Exit();
    }
}
