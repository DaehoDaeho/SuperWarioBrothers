using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);
    public float followSpeed = 5.0f;

    public float shakeTime = 0.5f;  // 흔들림을 유지할 시간.
    public float strength = 0.15f;  // 흔들림 강도.

    float shakeTimer;   // 흔들림을 유지할 시간까지 체크할 타이머.
    Vector3 followPosition; // 카메라가 플레이어를 따라갈 위치를 저장할 변수.

    private void Start()
    {
        // 게임이 시작되면 카메라의 시작 위치를 저장해 둔다.
        followPosition = transform.position;
    }

    private void LateUpdate()
    {
        // 벡터끼리의 덧셈.
        // (x1, y1, z1) + (x2, y2, z2) = (x1+x2, y1+y2, z1+z2)
        Vector3 targetPosition = target.position + offset;

        // 보간 함수를 사용해서 카메라를 부드럽게 이동.
        followPosition = Vector3.Lerp(followPosition, targetPosition, followSpeed * Time.deltaTime);

        UpdateShake();
    }

    /// <summary>
    /// 카메라 흔들기는 시작하기 위한 함수.
    /// 이 함수는 외부에서 호출해서 흔들림 연출을 시작하도록 만든다.
    /// 강한 공격을 받았거나 기타 카메라 흔들림 연출이 필요할 경우 호출.
    /// </summary>
    public void StartShake()
    {
        // 타이머 초기화.
        shakeTimer = shakeTime;
    }

    private void UpdateShake()
    {
        Vector3 shakeOffset = Vector3.zero;
        if (shakeTimer > 0.0f)  // 흔들림 유지 시간동안 계속 실행.
        {
            // Random.insideUnitCircle : 반지름이 1 Unit인 원 안에서 랜덤하게 x, y 값을 추출한다.
            // 추출한 x, y 값에 흔들림 강도를 곱한다.
            shakeOffset = Random.insideUnitCircle * strength;

            // 타이머 갱신.
            shakeTimer -= Time.deltaTime;            
        }

        // 따라가기 위한 위치에 흔들림 강도를 더해서 카메라를 흔들어 준다.
        // 카메라 흔들림 연출 시간이 다 돼서 흔들림 강도가 0일 경우에는 따라가는 위치만 갱신한다.
        transform.position = followPosition + shakeOffset;
    }
}
