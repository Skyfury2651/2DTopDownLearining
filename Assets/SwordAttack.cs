using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public enum AttackDirection
    {
        left, right
    }

    public AttackDirection attackDirection;
    public Collider2D swordCollider;

    Vector2 rightAttackOffset;

    private void Start()
    {
        swordCollider = GetComponent<Collider2D>();
        rightAttackOffset = transform.position;
    }

    //public void Attack()
    //{
    //    switch(attackDirection)
    //    {
    //        case AttackDirection.left:
    //            AttackLeft();
    //            break;
    //        case AttackDirection.right:
    //            AttackRight();
    //            break;
    //    }
    //}

    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if(enemy)
            {
                enemy.Health -= 1;
            }
        }
    }
}
