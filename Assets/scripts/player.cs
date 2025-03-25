using System;
using UnityEngine;

public class player :MonoBehaviour
{
    [Header("Move info")] 
    [SerializeField] public float movespeed;
    
    [Header("Jump info")]
    [SerializeField] public float jumpforce;

    [Header("Collision Check")] 
    [SerializeField]private Transform groundcheck;
    [SerializeField]private float groundDistance;
    [SerializeField]private Transform wallcheck;
    [SerializeField]private float wallDistance;
    [SerializeField]private LayerMask whatIsGround;
    
    
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public playerStateMachine PlayerStateMachine { get; private set; }
    
    
    public playerMoveState MoveState { get; private set; }
    public playerIdleState IdleState { get; private set; }
    public playerJumpState JumpState { get; private set; }
    public playerAirState AirState { get; private set; }

    public void Awake()
    {
        PlayerStateMachine = new playerStateMachine();

        rb = GetComponent<Rigidbody2D>();

        MoveState = new playerMoveState(this, PlayerStateMachine, "Move");
        IdleState = new playerIdleState(this, PlayerStateMachine, "Idle");
        JumpState = new playerJumpState(this, PlayerStateMachine, "Jump");
        AirState = new playerAirState(this, PlayerStateMachine, "Jump");
        
    }

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
        PlayerStateMachine.Initialize(IdleState);
    }

    public void Update()
    {
        PlayerStateMachine.currentState.Update();
    }

    public void setVelocity(float _xvelocity,float _yvelocity)
    {
        rb.linearVelocity = new Vector2(_xvelocity, _yvelocity);
    }

    public bool isGroundedCheck() =>
        Physics2D.Raycast(groundcheck.position, Vector2.down, groundDistance, whatIsGround);

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundcheck.position, new Vector3(groundcheck.position.x,groundcheck.position.y - groundDistance));
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x + wallDistance,wallcheck.position.y));
    }
}
