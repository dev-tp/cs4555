using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOne : MonoBehaviour {

    public float speed = 3f;
    public float playerRange = 10f;
    public float obstacleRange = 5f;
    public float attackPlayer = 5f;

    [SerializeField] private GameObject misslePrefab;
    private GameObject player;
    private Animator anim;
    private NavMeshAgent nav;
    private bool inRange = false;
    private bool aiming = false;
    private bool fire = false;
    private bool isWalking = true;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (InChasePlayerRange())
        {
            ChasePlayer();
        }
        else
        {
            WanderAround();
        }
        if (isWalking)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    private void WanderAround()
    {
        anim.SetBool("Patrolling", true);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
       
    }

    private void ChasePlayer()
    {
        anim.SetBool("Patrolling", true);
        nav.SetDestination(player.transform.position);
        if (InHitPlayerRange())
        {
            isWalking = false;
            nav.enabled = false;
            StartCoroutine("FireWeapon");
        }
        
    }

    private bool InHitPlayerRange()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if(hit.distance < attackPlayer)
            {
                return true;
            }
        }

        return false;
    }

    private bool InChasePlayerRange()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < playerRange)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator FireWeapon()
    {
        anim.SetBool("Patrolling", isWalking);
        Vector3 enemyToPlayer = transform.position - player.transform.position;
        Quaternion.LookRotation(enemyToPlayer);
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(.75f);
        if (!InHitPlayerRange())
        {
            isWalking = true;
            nav.enabled = true;
            anim.SetBool("Patrolling", isWalking);
        }

    }
}
