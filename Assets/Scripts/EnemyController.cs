using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform player, nom;
    public LayerMask groundCheck, playerCheck, nomCheck;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange, attackRange;
    public bool playerInSight, nomInSight;
    public bool playerAttackable = false;
    
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        //playerAttackable = false;
    }

    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerCheck);
        playerAttackable = Physics.CheckSphere(transform.position, attackRange, playerCheck);
        nomInSight = Physics.CheckSphere(transform.position, sightRange, nomCheck);

        if (!playerAttackable && !playerInSight && nomInSight)
        {
            Eating();
        } 
        if(playerInSight && !playerAttackable)
        {
            RunAway();
        }
        if(playerAttackable && playerInSight)
        {
            Attack();
        }
    }


    private void Eating()
    {
        agent.SetDestination(nom.position);
    }
    private void RunAway()
    {

    }
    private void Attack()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
}
