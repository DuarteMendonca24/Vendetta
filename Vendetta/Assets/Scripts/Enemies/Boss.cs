using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public int damage = 1;
    public float range = 100f;



    public Transform attackPoint;
    //Graphics
    public GameObject muzzleFlash;

    public float walkingSpeed = 1.5f;
    private bool isWalking = false;

    private Animator animator;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        agent.speed = walkingSpeed;


        if (!playerInSightRange && !playerInAttackRange)
        {


            walkingSpeed = 1.5f;

            //animator.SetTrigger("Walk");
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);


            //Debug.Log("Walking");


            Patrolling();


        }

        if (playerInSightRange && !playerInAttackRange)
        {
            walkingSpeed = 10.0f;
            // animator.SetTrigger("Run");
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsFiring", false);

            // Debug.Log("Run");

            ChasePlayer();
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            agent.SetDestination(transform.position); // stop moving while attacking
            Vector3 lookPos = player.transform.position;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsFiring", true);


            if (!alreadyAttacked && !animator.GetCurrentAnimatorStateInfo(0).IsName("RIfleRun"))
            {

                AttackPlayer();
                FindObjectOfType<AudioManager>().PlaySound("RifleShot");


            }

        }


    }

    private void Patrolling()
    {
        // Debug.Log("Patrolling");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {


            if (!agent.pathPending)
            {
                agent.SetDestination(walkPoint);
            }





        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            isWalking = false;


        }
    }

    private void SearchWalkPoint()



    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //Debug.Log(walkPoint.magnitude);
        //Check if point is not outside the map
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        //Debug.Log("Chase");
        agent.SetDestination(player.position);

    }

    private void AttackPlayer()
    {

        RaycastHit hitInfo;
        if (Physics.Raycast(attackPoint.transform.position, attackPoint.transform.forward, out hitInfo, range))
        {
            //animator.SetTrigger("Fire");

            //Debug.Log("Fire");
            //this only occurs if we hit something with our ray
            //Debug.Log(hitInfo.transform.name);
            Debug.DrawRay(attackPoint.transform.position, attackPoint.transform.forward, Color.yellow, 5.0f);

            PlayerDamage target = hitInfo.transform.GetComponent<PlayerDamage>();
            if (target != null)
            {

                target.TakeDamage(damage);
            }

        }




        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, attackPoint.rotation, attackPoint);

        Destroy(flash, 0.10f);

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
