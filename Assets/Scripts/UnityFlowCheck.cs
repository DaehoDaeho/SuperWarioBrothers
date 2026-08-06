using UnityEngine;

public class UnityFlowCheck : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake가 실행되었습니다.");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("현재 위치: " + transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update가 실행 중입니다.");
    }
}
