using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : StateMachineBehaviour
{

    private SpriteRenderer body;
    private PlayerMovementController moveCtrl;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveCtrl == null) moveCtrl = animator.GetComponent<PlayerMovementController>();
        if (animator.GetBool("Sniff"))
        {
            moveCtrl.isSniffing = true;
            Debug.Log("Snif");
        }
        animator.SetBool("Jump", false);
        animator.SetBool("Sniff", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (body == null) body = animator.GetComponentInChildren<SpriteRenderer>();
        if (animator.GetInteger("Turn") == -1) body.flipX = true;
        if (animator.GetInteger("Turn") == 1) body.flipX = false;
        animator.SetInteger("Turn", 0);
        moveCtrl.isSniffing = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
