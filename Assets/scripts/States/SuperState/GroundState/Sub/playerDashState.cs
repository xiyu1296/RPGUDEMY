using UnityEngine;

public class playerDashState : playerGroundState
{

    private float DashcoolDown;
    public playerDashState( player _player,playerStateMachine _playerStateMachine, string _aniboolname) : base(_player, _playerStateMachine, _aniboolname)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        Player.setVelocity(Player.dashspeed * Player.dashDir,0);
        DashcoolDown = Player.dashduration;
    }

    public override void Update()
    {
        base.Update();
        DashcoolDown -= Time.deltaTime;
        if (DashcoolDown < 0)
        {
            Player.setVelocity(0, rb.linearVelocity.y);
            Player.PlayerStateMachine.ChangeState(Player.IdleState);

        }
    }

    public override void Exit()
    {

        base.Exit();

    }
}
