using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.AI; PlayerMotor에서 관리

public class PlayerController : MonoBehaviour
{
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;

    Camera cam;
    //NavMeshAgent agent;
    Animator animator;
    public LayerMask movementMask;
    public LayerMask interactionMask;

    public Interactable focus;

    PlayerMotor motor;
    CharacterCombat combat;

    private void Awake()
    {
        cam = Camera.main;
        //agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        motor = GetComponent<PlayerMotor>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    void Update()
    {
        //float agentVelocity = agent.velocity.sqrMagnitude;

        if (EventSystem.current.IsPointerOverGameObject()) // UI 클릭시
            return;


        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToTarget(hit.point);
                DeFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, interactionMask))
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
                //combat.Attack();
            }
        }



        //if (!agent.pathPending) // 에이전트가 목적지에 닿았는지
        //{
        //    if (agent.remainingDistance <= agent.stoppingDistance)
        //    {
        //        animator.SetFloat("Walk", 0);
        //    }
        //}

        //animator.SetFloat("Walk", agentVelocity);
    }

    void SetFocus(Interactable newFocus)
    {
        onFocusChanged?.Invoke(newFocus);

        if(focus!=newFocus && focus!=null)
        {
            // 기존 선택된 인터랙터블 객체에 알림
            focus.OnDeFocused();
            //motor.MoveToTarget(focus.guideTransform.position);
        }
        focus = newFocus;
        if (focus != null)
        {
            // 새로 선택된 인터렉터블 객체에 알림
            focus.OnFocused();
        }
    }

    void DeFocus()
    {
        focus = null;
    }
}
