using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    Rigidbody2D body;
    float xDirection;

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
    }

    void FixedUpdate()
    {
        float xSpeed = xDirection * moveSpeed;
        body.linearVelocity = new Vector2(xSpeed, body.linearVelocity.y);
    }
}
