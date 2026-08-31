using UnityEngine;

public class CourseReactionController : MonoBehaviour
{
    public GameObject clearSign;

    private bool isClear = false;

    private int coinCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 오브젝트를 비활성화 처리.
        clearSign.SetActive(false);
    }

    /// <summary>
    /// 오브젝트가 Trigger 방식으로 충돌했을 때 자동으로 호출되는 함수.
    /// </summary>
    /// <param name="other">충돌한 대상의 콜라이더</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isClear == true)
        {
            return;
        }

        if(other.CompareTag("Coin") == true)
        {
            // 획득 처리.
            CollectCoin(other.gameObject);
        }
        else if(other.CompareTag("Goal") == true)
        {
            // 클리어 처리.
            GameManager.Instance.GameClear();
        }
    }

    void CollectCoin(GameObject coinObject)
    {
        coinCount++;

        coinObject.SetActive(false);

        Debug.Log("획득 코인: " + coinCount);
    }

    void ClearStage()
    {
        isClear = true;

        clearSign.SetActive(true);
    }
}
