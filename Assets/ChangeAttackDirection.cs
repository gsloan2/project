using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAttackDirection : MonoBehaviour
{
    private Transform attackPoint;
    public float attackPointDistance = 0.5f;  // Distance from character to attack point

    private Vector2 lastFacingDirection;

    private void Awake()
    {
        attackPoint = transform;
    }

    void Update()
    {
        Vector2 direction = PlayerMovement.Instance.getDirection();

        // Only update lastFacingDirection if the direction is non-zero
        if (direction != Vector2.zero)
        {
            lastFacingDirection = direction.normalized;
        }

        // Calculate the new local position of the attack point
        Vector3 newLocalPosition = new Vector3(
            lastFacingDirection.x * attackPointDistance,
            lastFacingDirection.y * attackPointDistance,
            0
        );

        attackPoint.localPosition = newLocalPosition;
    }
}
