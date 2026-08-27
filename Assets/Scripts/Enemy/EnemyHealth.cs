using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public Animator animator;

    private int currentHealth;
    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(isDead == true)
        {
            return;
        }

        currentHealth -= damage;
        Debug.Log(name + "남은 체력: " + currentHealth);

        if(currentHealth <= 0)
        {
            // 사망 처리.
            Die();
        }
    }

    void Die()
    {
        if (isDead == true)
        {
            return;
        }

        isDead = true;        

        animator.SetTrigger("Death");
        Destroy(gameObject, 1.5f);
        //Invoke("DestroyObject", 1.5f);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
