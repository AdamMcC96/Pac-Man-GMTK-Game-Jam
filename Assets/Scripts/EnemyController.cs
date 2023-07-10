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
    public bool playerAttackable;
    
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerCheck);
        //playerAttackable = Physics.CheckSphere(transform.position, attackRange, playerCheck);
        nomInSight = Physics.CheckSphere(transform.position, sightRange, nomCheck);

        if (playerAttackable == false && playerInSight == false && nomInSight == true) Eating();
        
        if(playerInSight == true && playerAttackable == false) RunAway();
        
        if(playerAttackable == true && playerInSight == true) Attack();
        
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(playerAttackable == true)
            {
                FindObjectOfType<GameManager>().GhostEaten();
            }if(playerAttackable == false)
            {
                FindObjectOfType<GameManager>().PacmanEaten();
            }
        }
    }

    private void Eating()
    {
        agent.SetDestination(transform.position + nom.position);
        Debug.Log("Eat");
    }
    private void RunAway()
    {
        Debug.Log("Run");
        agent.SetDestination(transform.position - player.position);
    }
    private void Attack()
    {
        Debug.Log("Attack");
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }
}
