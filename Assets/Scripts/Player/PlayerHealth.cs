using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    private int currentHealth;
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartUI();
    }

    public void TakeDamage(int damageAmount)
    {
        if(isDead == true)
        {
            return;
        }

        currentHealth -= damageAmount;
        // UI 갱신.
        UpdateHeartUI();

        if (currentHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    void UpdateHeartUI()
    {
        // 체력이 1 이상이면 첫번째 하트를 활성화.
        heart1.SetActive(currentHealth >= 1);

        // 체력이 2 이상이면 두번째 하트를 활성화.
        heart2.SetActive(currentHealth >= 2);

        // 체력이 3 이상이면 세번째 하트를 활성화.
        heart3.SetActive(currentHealth >= 3);
    }
}
