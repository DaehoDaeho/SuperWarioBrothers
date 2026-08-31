using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{
    public int maxLives = 3;
    public Transform startPoint;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public PlayerKeyboardMove playerMoveScript;
    public CameraFollow cameraFollow;

    int currentLives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLives = maxLives;
        UpdateHeartUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hazard") == true)
        {
            // 데미지 처리.
            TakeDamage();

            // 위험물 오브젝트에 닿아서 데미지를 입은 후 카메라 흔들림 시작을 요청.
            if(cameraFollow != null)
            {
                cameraFollow.StartShake();
            }
        }
    }

    void TakeDamage()
    {
        currentLives--;
        // UI 갱신.
        UpdateHeartUI();

        if(currentLives <= 0)
        {
            GameManager.Instance.GameOver();
            playerMoveScript.enabled = false;
        }
    }

    void UpdateHeartUI()
    {
        // 체력이 1 이상이면 첫번째 하트를 활성화.
        heart1.SetActive(currentLives >= 1);

        // 체력이 2 이상이면 두번째 하트를 활성화.
        heart2.SetActive(currentLives >= 2);

        // 체력이 3 이상이면 세번째 하트를 활성화.
        heart3.SetActive(currentLives >= 3);
    }

    void MoveToStartPoint()
    {
        transform.position = startPoint.position;
    }
}
