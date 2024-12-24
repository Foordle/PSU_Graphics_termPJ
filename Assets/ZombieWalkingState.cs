using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZombieWalkingState : StateMachineBehaviour
{
    float timer;
    public float walkingTIme = 10f;

    Transform player;
    NavMeshAgent agent;
    public float detectionArea = 18f;
    public float patrolSpeed = 2f;
    List<Transform> waypointList = new List<Transform>();
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        timer = 0;

        GameObject waypointCluster = GameObject.FindGameObjectWithTag("Waypoints");
       
        foreach (Transform t in waypointCluster.transform)
        {
            waypointList.Add(t);
            //Debug.Log("add waypoint");
        }
        Vector3 nextPosition = waypointList[Random.Range(0, waypointList.Count)].position;
        agent.SetDestination(nextPosition);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.remainingDistance <=agent.stoppingDistance)
        {
            agent.SetDestination(waypointList[Random.Range(0, waypointList.Count)].position);
        }

        timer += Time.deltaTime;
        if (timer > walkingTIme)
        {
            animator.SetBool("isWalking", false);
        }
        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceFromPlayer < detectionArea)
        {
            animator.SetBool("isChasing", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
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
