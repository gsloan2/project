using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour    
{
    public Transform attackPoint;
    public float range;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        
    }

    void Attack()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);

        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("Hitting " + enemy.name);

            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyRb != null && enemyAI != null)
            {
                Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                float knockbackForce = 7f;
                enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

                // Apply knockback cooldown to the enemy
                enemyAI.ApplyKnockback();
            }
        }
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }
}
