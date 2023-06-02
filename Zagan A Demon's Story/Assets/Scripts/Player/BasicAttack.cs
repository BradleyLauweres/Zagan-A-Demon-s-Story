using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField] private float AttackDamage;
    [SerializeField] private float cooldown;

    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
            LeftClickAttack();
        else
        {
            anim.SetBool("IsAttacking", false);
        }

        if (Input.GetKey(KeyCode.Mouse1))
            RightClickAttack();
        else
        {
            anim.SetBool("IsDashAttacking", false);
        }
    }

    private void LeftClickAttack()
    {
        anim.SetBool("IsAttacking", true);
    }

    private void RightClickAttack()
    {
        anim.SetBool("IsDashAttacking",true);

        var test = rb.velocity.x + 15;
        rb.velocity = new Vector2(test, rb.velocity.y);
    }
}
