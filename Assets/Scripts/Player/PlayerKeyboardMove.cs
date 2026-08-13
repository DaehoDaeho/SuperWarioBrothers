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
        else if(leftInput == true && rightInput == false)
        {
            xDirection = -1.0f;
        }

        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float xSpeed = xDirection * moveSpeed;
        body.linearVelocity = new Vector2(xSpeed, body.linearVelocity.y);

        if(jumpPressed == true && isGrounded == true)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);
        }

        jumpPressed = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
