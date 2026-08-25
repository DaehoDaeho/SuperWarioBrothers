using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float patrolDistance = 3.0f;
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public float idleTime = 2.0f;

    private Vector2 startPosition;

    private float moveDirection = 1.0f;
    private float nextDirection = 1.0f;
    private bool isMoving = true;
    private float idleTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        // 순찰 범위 끝에 도달했는지 확인.
        CheckTurnPoint();

        Idle();

        // 실제 이동.
        Move();

        // 스프라이트 방향을 전환.
        UpdateFacingDirection();
    }

    private void Move()
    {
        if(isMoving == false)
        {
            return;
        }

        float xSpeed = moveDirection * moveSpeed;

        body.linearVelocity = new Vector2(xSpeed, body.linearVelocity.y);
    }

    void CheckTurnPoint()
    {
        if(isMoving == false)
        {
            return;
        }

        float xDistance = transform.position.x - startPosition.x;
        if(xDistance >= patrolDistance)
        {
            //moveDirection = -1.0f;
            StartIdleState(-1.0f);
        }
        else if(xDistance <= -patrolDistance)
        {
            //moveDirection = 1.0f;
            StartIdleState(1.0f);
        }
    }

    void StartIdleState(float direction)
    {
        isMoving = false;
        idleTimer = 0.0f;
        body.linearVelocity = new Vector2(0.0f, body.linearVelocity.y);
        nextDirection = direction;
    }

    void UpdateFacingDirection()
    {
        if(isMoving == false)
        {
            return;
        }

        spriteRenderer.flipX = moveDirection < 0.0f;
    }

    void Idle()
    {
        if (isMoving == false)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                isMoving = true;
                moveDirection = nextDirection;
            }
        }
    }

    void UpdateAnimation()
    {
        animator.SetBool("IsMoving", isMoving);
    }
}
