using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform targetPlayer;
    private float range;
    private float speed;
    private float knockbackCooldown = 0f;
    private float knockbackCooldownDuration = .3f;  // Adjust this value to control the duration of the cooldown

    void Start()
    {
        range = 50;
        speed = 2f;
        targetPlayer = Player.Instance.getPlayerPosition();
    }

    void Update()
    {
        // Decrease the knockbackCooldown over time
        knockbackCooldown = Mathf.Max(0f, knockbackCooldown - Time.deltaTime);

        targetPlayer = Player.Instance.getPlayerPosition();

        // Only move towards the player if knockbackCooldown is 0
        if (knockbackCooldown == 0f && Vector2.Distance(transform.position, targetPlayer.position) < range)
        {
            Vector2 dir = (targetPlayer.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }

    public void ApplyKnockback()
    {
        // Set knockbackCooldown to knockbackCooldownDuration whenever knockback is applied
        knockbackCooldown = knockbackCooldownDuration;
    }
}
