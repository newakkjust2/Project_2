using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AI;

public enum Behaviors {Idle, Guard, Combat};

public class PatrolingAI : MonoBehaviour
{
    public float fireCDTimer = 2f;
    public float remainingCD;
    public Behaviors aiBehaviors = Behaviors.Idle;
    [SerializeField] private int indexOfWaypoint;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private PoolProjectiles poolProjectiles;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform guardPostLocation;
    private NavMeshAgent _agent;
    private bool _hasArrived;
    private Vector3 _destination;
    private float _distance;
    private bool _fightsRanged;
    private GameObject _player;
    

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        if (aiBehaviors == Behaviors.Idle)
        {
            _fightsRanged = true;
        }
        _agent.SetDestination(waypoints[indexOfWaypoint].position);
    }

    private void Update()
    {
        remainingCD -= Time.deltaTime;
        RunBehaviors();
    }

    void GoToNextWaypoint()
    {
        ++indexOfWaypoint;
        if (indexOfWaypoint >= waypoints.Length )
        {
            indexOfWaypoint = 0;
        }
        _agent.SetDestination(waypoints[indexOfWaypoint].position);
    }
    
    void RunBehaviors()
    {
        switch(aiBehaviors)
        {
            case Behaviors.Idle:
                RunIdleNode();
                break;
            case Behaviors.Guard:
                RunGuardNode();
                break;
            case Behaviors.Combat:
                RunCombatNode();
                break;
        }
    }

    void RunIdleNode()
    {
        animator.SetBool("isMoving", false);
        Idle();
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) < 10)
        {
            animator.SetBool("isMoving", true);
            aiBehaviors = Behaviors.Combat;
        }
    }

    void RunGuardNode()
    {
        Guard();
    }

    private void Guard()
    {
        animator.SetBool("isMoving", true);
        if (Vector3.Distance(transform.position, waypoints[indexOfWaypoint].position) < 2)
        {
            _hasArrived = true;
        }
        else if (Vector3.Distance(transform.position, waypoints[indexOfWaypoint].position) >= 2)
        {
            _hasArrived = false;
        }
        
        if (_hasArrived)
        {
            GoToNextWaypoint();
            Debug.Log("check");
        }
        if (Vector3.Distance(transform.position, _player.transform.position) < 10)
        {
            aiBehaviors = Behaviors.Combat;
        }
    }

    void RunCombatNode()
    {

        if(_fightsRanged)
            RangedAttack();
        else
            MeleeAttack();
    }

    private void RangedAttack()
    {
        _agent.SetDestination(_player.transform.position);
        if (Vector3.Distance(_agent.transform.position, _player.transform.position) < 5f)
        {
            animator.SetTrigger("Attack");
            Shoot();
        }
        else if(Vector3.Distance(_agent.transform.position, _player.transform.position) >= 10f)
        {
            _agent.SetDestination(guardPostLocation.position);
            if (_agent.remainingDistance < _agent.stoppingDistance)
            {
                aiBehaviors = Behaviors.Idle;
            }
        }
    }

    private void MeleeAttack()
    {
        _agent.SetDestination(_player.transform.position);
        if (Vector3.Distance(_agent.transform.position, _player.transform.position) < 2)
        {
            animator.SetTrigger("Attack");
            Attack();
        }
        else if (Vector3.Distance(_agent.transform.position, _player.transform.position) >= 10)
        {
            aiBehaviors = Behaviors.Guard;
            GoToNextWaypoint();
        }
    }

    void Shoot()
    {
        if (remainingCD < 0)
        {
            poolProjectiles.Shoot();
           
           remainingCD = fireCDTimer;
        }
        Debug.Log("Shooting");
    }
    
    void Attack()
    {
        Debug.Log("Hello from attack");
    }
}
