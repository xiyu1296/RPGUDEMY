using System;
using UnityEngine;

public class player :MonoBehaviour
{
    [Header("Move info")] 
    [SerializeField] public float movespeed;
    
    [Header("Jump info")]
    [SerializeField] public float jumpforce;
    [SerializeField] public float bounceforce;
    
    [Header("Dash info")]
    [SerializeField] public float dashspeed;
    [SerializeField] public float dashduration;
    [SerializeField] public float dashDir;
    [SerializeField] private float dashcooldown;
    private float dashTimer;

    
    
    [Header("Collision Check")] 
    [SerializeField]private Transform groundcheck;
    [SerializeField]private float groundDistance;
    [SerializeField]private Transform wallcheck;
    [SerializeField]private float wallDistance;
    [SerializeField]private LayerMask whatIsGround;
    
    //Flip parameter
    public int faceDir { get; private set; } = 1;
    public bool isFacingRight { get; private set; } = true;
    
    //init parameters
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }
    public playerStateMachine PlayerStateMachine { get; private set; }
    
    //playerstates
    public playerMoveState MoveState { get; private set; }
    public playerIdleState IdleState { get; private set; }
    public playerJumpState JumpState { get; private set; }
    public playerAirState AirState { get; private set; }
    public playerDashState DashState { get; private set; }
    public playerSlideWallState SlideWall { get; private set;}
    public playerJumpWallState JumpWall { get; private set; }

    public void Awake()
    {
        PlayerStateMachine = new playerStateMachine();

        rb = GetComponent<Rigidbody2D>();

        MoveState = new playerMoveState(this, PlayerStateMachine, "Move");
        IdleState = new playerIdleState(this, PlayerStateMachine, "Idle");
        JumpState = new playerJumpState(this, PlayerStateMachine, "Jump");
        AirState = new playerAirState(this, PlayerStateMachine, "Jump");
        DashState = new playerDashState(this, PlayerStateMachine, "Dash");
        SlideWall = new playerSlideWallState(this, PlayerStateMachine, "SlideWall");
        JumpWall = new playerJumpWallState(this, PlayerStateMachine, "Jump");
        
    }

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
        AnimationController();
        
        PlayerStateMachine.Initialize(IdleState);
    }

    public void Update()
    {
        PlayerStateMachine.currentState.Update();
        DashController();
    }

    public void DashController()
    {
        dashTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer < 0)
        {
            dashTimer = dashcooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = faceDir;
            
            PlayerStateMachine.ChangeState(DashState);
        }
    }
    public void AnimationController()
    {
        animator.SetFloat("yVelocity",rb.linearVelocity.y);
    }

    public void setVelocity(float _xvelocity,float _yvelocity)
    {
        rb.linearVelocity = new Vector2(_xvelocity, _yvelocity);
        FlipController(_xvelocity);

    }

    public bool isGroundedCheck() =>
        Physics2D.Raycast(groundcheck.position, Vector2.down, groundDistance, whatIsGround);

    public bool isWalledCheck() =>
        Physics2D.Raycast(wallcheck.position, Vector2.right, wallDistance, whatIsGround)||        
        Physics2D.Raycast(wallcheck.position, Vector2.left, wallDistance, whatIsGround);
        
    
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundcheck.position, new Vector3(groundcheck.position.x,groundcheck.position.y - groundDistance));
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x + wallDistance,wallcheck.position.y));
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x - wallDistance,wallcheck.position.y));

    }

    public void Flip()
    {
        faceDir = -1 * faceDir;
        isFacingRight = !isFacingRight;
        transform.Rotate(0,180,0);
    }

    public void FlipController(float _x)
    {
        if(_x > 0 && !isFacingRight)
            Flip();
        if(_x < 0 && isFacingRight)
            Flip();
    }
}
