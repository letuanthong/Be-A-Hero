using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionChase : FSMAction
{
    [Header("Config")]
    [SerializeField] private float chaseSpeed;

    private EnemyAI enemyAI;
    private EnemyAnimations enemyAnimations;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyAnimations = GetComponent<EnemyAnimations>();
    }

    public override void Act()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if (enemyAI.Player == null) return;
        Vector3 dirToPlayer = enemyAI.Player.position - transform.position;
        if (dirToPlayer.magnitude >= 1f)
        {
            transform.Translate(dirToPlayer.normalized
                                * (chaseSpeed * Time.deltaTime));
            UpdateAnimation(dirToPlayer);
        }
    }

    private void UpdateAnimation(Vector3 direction)
    {
        direction.Normalize();
        enemyAnimations.SetMoveAnimation(new Vector2(direction.x, direction.y));
    }
}
