using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
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
    public bool playerInSightRange , playerInAttackRange;

    public float damage = 0.1f;
    public float range = 100f;

    public Camera fpsCam;

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
        


        if (!playerInSightRange && !playerInAttackRange)
        {
            if (!isWalking)
            {
                walkingSpeed = 1.5f; 
                animator.SetTrigger("Walk");
                isWalking = true;
            }
            Patrolling();
            

        }

        if (playerInSightRange && !playerInAttackRange)
        {
            walkingSpeed = 2.5f;
            animator.SetTrigger("Run");
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange )
        {
            agent.SetDestination(transform.position); // stop moving while attacking
           
            if (!alreadyAttacked)
            {
                animator.SetTrigger("Fire");
               
                AttackPlayer();
            }
            
        }
        
    }

    private void Patrolling()
    {
        Debug.Log("Patrolling");
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
           

            agent.speed = walkingSpeed;
            agent.SetDestination(walkPoint);
            



        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //Walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f)
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

        walkPoint = new Vector3(transform.position.x + randomX , transform.position.y , transform.position.z + randomZ);
        //Debug.Log(walkPoint.magnitude);
        //Check if point is not outside the map
        if(Physics.Raycast(walkPoint, -transform.up,2f,whatIsGround))
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
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {

            //this only occurs if we hit something with our ray
            //Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {

                target.TakeDamage(damage);
            }

        }



        GameObject flash = Instantiate(muzzleFlash, attackPoint.position, attackPoint.rotation, attackPoint);

        Destroy(flash, 0.15f);

        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
