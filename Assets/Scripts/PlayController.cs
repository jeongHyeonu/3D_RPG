using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayController : MonoBehaviour
{
    public enum State { MOVE, ATTACK,HITTED }
    public State state = State.MOVE;
    public int hp = 100;

    NavMeshAgent agent;
    public Camera cam;
    public LayerMask movementMask;
    Animator animator;

    public int walkID = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy") return;

        if(state!= State.HITTED)
        {
            state = State.HITTED;
            hp -= 10;
        }


        if (state != State.ATTACK)
        {
            state = State.ATTACK;
            animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        state = State.MOVE;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Damaged");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Die");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                agent.SetDestination(hit.point);
            }
        }
 
        if (!agent.pathPending) // 에이전트가 목적지에 닿았는지
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetFloat("Walk", 0);
            }
        }

        animator.SetFloat("Walk", agent.velocity.sqrMagnitude); // 속도(벡터)값을 float값으로 변환

    }
}
