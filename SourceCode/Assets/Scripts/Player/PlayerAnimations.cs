using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("moveX");
    private readonly int moveY = Animator.StringToHash("moveY");
    private readonly int moving = Animator.StringToHash("Moving");
    private readonly int dead = Animator.StringToHash("Dead");
    private readonly int revive = Animator.StringToHash("Revive");
    private readonly int attacking = Animator.StringToHash("Attacking");
    private readonly int attackBow = Animator.StringToHash("AttackBow");
    private readonly int attackSword = Animator.StringToHash("AttackSword");


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(dead);
    }

    public void SetMoveBool(bool value)
    {
        animator.SetBool(moving, value);
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }

    public void SetAttackBowAnimation(bool value)
    {
        animator.SetBool(attacking, value);
        animator.SetTrigger(attackBow);
    }

    public void SetAttackSwordAnimation(bool value)
    {
        animator.SetBool(attacking, value);
        animator.SetTrigger(attackSword);
    }

    public void ResetPlayer()
    {
        SetMoveAnimation(Vector2.down);
        animator.SetTrigger(revive);
    }

}
