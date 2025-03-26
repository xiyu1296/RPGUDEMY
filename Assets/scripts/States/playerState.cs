using UnityEngine;

public class playerState
{
    protected playerStateMachine StateMachine;
    protected player Player;

    private string aniboolname;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    
    public playerState( player _player, playerStateMachine _playerStateMachine,string _aniboolname)
    {
        this.aniboolname = _aniboolname;
        this.StateMachine = _playerStateMachine;
        this.Player = _player;
        this.rb = _player.rb;
    }

    public virtual void Enter()
    {
        Player.animator.SetBool(aniboolname,true);
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

    }
    
    public virtual void Exit()
    {
        Player.animator.SetBool(aniboolname,false);
    }

}
