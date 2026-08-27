using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public Vector2 attackOffset = new Vector2(0.6f, 0.0f);
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float attackCooldown = 0.35f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public int attackDamage = 1;

    private float lastAttackTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // 플레이어의 방향에 따라 공격 포인트의 위치 업데이트.
        UpdateAttackPointPosition();

        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            // 공격 시도.
            TryAttack();
        }
    }

    void UpdateAttackPointPosition()
    {
        if(attackPoint == null || spriteRenderer == null)
        {
            return;
        }

        // 3항 연산자.
        float direction = spriteRenderer.flipX == true ? -1.0f : 1.0f;

        attackPoint.localPosition = new Vector2(attackOffset.x * direction, attackOffset.y);
    }

    void TryAttack()
    {
        // 게임이 시작된 후 흐른 시스템 시간.
        if(Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            // 공격.
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void ApplyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        for (int i = 0; i < hitEnemies.Length; i++)
        {
            Debug.Log("공격 범위 안의 적: " + hitEnemies[i].name);

            EnemyHealth enemyHealth = hitEnemies[i].GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }

            EnemyPatrol enemyPatrol = hitEnemies[i].GetComponent<EnemyPatrol>();
            if(enemyPatrol != null)
            {
                enemyPatrol.StartHit();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
