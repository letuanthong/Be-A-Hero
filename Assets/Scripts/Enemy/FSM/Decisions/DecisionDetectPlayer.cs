using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSMDecision
{
    [Header("Config")]
    [SerializeField] private float range;
    [SerializeField] private LayerMask playerMask;

    private EnemyAI enemyAI;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    public override bool Decide()
    {
        return DetectPlayer();
    }

    private bool DetectPlayer()
    {
        Collider2D playerCollider =
            Physics2D.OverlapCircle(enemyAI.transform.position,
                range, playerMask);
        if (playerCollider != null)
        {
            enemyAI.Player = playerCollider.transform;
            return true;
        }

        enemyAI.Player = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
