using UnityEngine;
using System.Collections;

public class EnemyAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("FloatX");
    private readonly int moveY = Animator.StringToHash("FloatY");
    private readonly int isMove = Animator.StringToHash("IsMove");
    private readonly int dead = Animator.StringToHash("Dead");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMoveBool(bool value)
    {
        animator.SetBool(isMove, value);
    }

    public void SetMoveAnimation(Vector2 dir)
    {
        animator.SetFloat(moveX, dir.x);
        animator.SetFloat(moveY, dir.y);
    }

    public void SetDeadAnimation()
    {
        animator.SetTrigger(dead);
    }
}

