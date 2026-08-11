using UnityEngine;

public class PlayerKeyboardMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        bool rightInput = Input.GetKey(KeyCode.RightArrow) == true || Input.GetKey(KeyCode.D) == true;

        bool leftInput = Input.GetKey(KeyCode.LeftArrow) == true || Input.GetKey(KeyCode.A) == true;

        float xDirection = 0.0f;

        if (rightInput == true && leftInput == false)
        {
            xDirection = 1.0f;
        }
        else if(leftInput == true && rightInput == false)
        {
            xDirection = -1.0f;
        }

        // 이동량 = 방향 * 속도 * 시간.
        // 다음 위치 = 현재 위치 + 이동량.
        // Time.deltaTime : 이전 프레임에서 현재 프레임까지 오는 데 소요된 시간.
        float movement = xDirection * moveSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(movement, 0.0f, 0.0f);
    }
}
