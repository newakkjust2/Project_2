using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIBehaviors
{
    FollowPlayer,
    Attack
}

public class AIFriend : MonoBehaviour
{
    public AIBehaviors friendBehavior = AIBehaviors.FollowPlayer;
    private NavMeshAgent agent;
    private GameObject player;
    private PatrolingAI[] EnemiesInScene;
    private PatrolingAI target;
    private Animator friendAnim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        EnemiesInScene = FindObjectsOfType<PatrolingAI>();
        friendAnim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        RunBehaviors();
    }

    void RunBehaviors()
    {
        switch (friendBehavior)
        {
            case AIBehaviors.FollowPlayer:
            {
                StayWithPlayer();
                UpdateAttackNode();
                break;
            }
            case AIBehaviors.Attack:
            {
                Attack();
                if (Vector3.Distance(player.transform.position, target.transform.position) >= 5)
                {
                    friendBehavior = AIBehaviors.FollowPlayer;
                }
                break;
            }
        }
    }

    void Attack()
    {
        if(target.Equals(null)) return;

        agent.SetDestination(target.transform.position);
        agent.transform.LookAt(target.transform);
        friendAnim.SetTrigger("Attack");

    }
    void StayWithPlayer()
    {
        agent.SetDestination(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            friendAnim.SetBool("isMoving", false);
        }
        else
        {
            friendAnim.SetBool("isMoving", true);    
        }
    }

    void UpdateAttackNode()
    {
        foreach (var VARIABLE in EnemiesInScene)
        {
            if (Vector3.Distance(player.transform.position, VARIABLE.transform.position) < 5)
            {
                friendBehavior = AIBehaviors.Attack;
                target = VARIABLE;
            }
        }
    }
}
