using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpPower = 10.0f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D body;
    float xDirection;

    bool jumpPressed;
    bool isGrounded;

    // [2단 점프 추가]
    // 현재 몇 번 점프했는지 저장합니다.
    int jumpCount = 0;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool rightInput = Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D) == true;

        bool leftInput = Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A) == true;

        xDirection = 0.0f;

        if (rightInput == true && leftInput == false)
        {
            xDirection = 1.0f;
        }
        else if (leftInput == true && rightInput == false)
        {
            xDirection = -1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        float xSpeed = xDirection * moveSpeed;
        body.linearVelocity = new Vector2(xSpeed, body.linearVelocity.y);

        // [2단 점프 추가]
        // 플레이어가 바닥에 내려오면 점프 횟수를 다시 0으로 만듭니다.
        // y 방향 속도가 0 이하일 때만 초기화해서
        // 첫 번째 점프 직후 다시 초기화되는 것을 방지합니다.
        if (isGrounded == true && body.linearVelocity.y <= 0.0f)
        {
            jumpCount = 0;
        }

        // [2단 점프 수정]
        // 바닥에 있는지를 검사하는 대신
        // 지금까지 점프한 횟수가 2번보다 적은지를 확인합니다.
        if (jumpPressed == true && jumpCount < 2)
        {
            body.linearVelocity = new Vector2(
                body.linearVelocity.x,
                jumpPower
            );

            // [2단 점프 추가]
            // 점프할 때마다 점프 횟수를 1 증가시킵니다.
            jumpCount++;
        }

        jumpPressed = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(
            groundCheck.position,
            groundCheckRadius
        );
    }
}