using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBehavior : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    private int rand;

    private float startMoveTimer;

    private Transform playerPos;
    public float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 2);
        startMoveTimer = 0.15f;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            if (rand == 0)
            {
                animator.SetTrigger("Idle");
            }
            else
            {
                animator.SetTrigger("Wave");
            }
        }
        else { timer -= Time.deltaTime; }

        Vector3 target = new Vector3(playerPos.position.x, animator.transform.position.y);
        if (startMoveTimer <= 0)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            startMoveTimer -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
