using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{

    Animator animator;
    CharacterCombat combat;
    NavMeshAgent agent;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        //combat.OnIdle += OnIdle;
        //combat.OnAttack += OnAttack;
        //combat.OnHited += OnHitted;
        //combat.OnDie += OnDie;
    }
    private void OnEnable()
    {
        combat.OnIdle += OnIdle;
        combat.OnAttack += OnAttack;
        combat.OnHited += OnHitted;
        combat.OnDie += OnDie;
    }


    private void OnDisable()
    {
        combat.OnIdle -= OnIdle;
        combat.OnAttack -= OnAttack;
        combat.OnHited -= OnHitted;
        combat.OnDie -= OnDie;
    }

    private void Update()
    {
        animator.SetFloat("Walk",agent.velocity.magnitude);
    }

    void OnIdle()
    {
        animator.SetFloat("Walk", 0f);
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnHitted()
    {
        animator.SetTrigger("Damaged");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }
}
