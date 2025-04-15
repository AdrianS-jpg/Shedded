using System.Buffers;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class EnemyMovement : MonoBehaviour
{
    [Header("Transforms")]
    public Transform targ;
    public Transform self;
    public Vector2 targdirection;

    [Header("Components")]
    public CircleCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    NavMeshAgent agent;

    [Header("Bools")]
    public bool attackCor = false;
    public bool enemyKilled = false;
    public bool seePlayer;

    [Header("Raycasts")]
    public RaycastHit2D ray;
    RaycastHit2D[] hit;

    [Header("Numbers")]
    public float distance;
    public int enemyHealth = 3;
    public PlayerHealth pH;
    public int walkRadius = 10;
    public Vector3 finalPosition;
    public Vector3 finalPosition3;

    public LayerMask layer;

    private void Start()
    {
        hurtbox.enabled = true;
        hitbox.enabled = false;

        distance = Vector2.Distance(transform.position, targ.position);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targdirection);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        finalPosition = hit.position;
        Vector3 randomDirection3 = Random.insideUnitSphere * walkRadius;
        randomDirection3 += transform.position;
        NavMeshHit hit3;
        NavMesh.SamplePosition(randomDirection3, out hit3, walkRadius, 1);
        finalPosition3 = hit3.position;
        Debug.Log(Vector2.Distance(finalPosition, finalPosition3));
        while (Vector2.Distance(finalPosition, finalPosition3) <= 3)
        {
            randomDirection3 = Random.insideUnitSphere * walkRadius;
            randomDirection3 += transform.position;
            NavMesh.SamplePosition(randomDirection3, out hit3, walkRadius, 1);
            finalPosition3 = hit3.position;
            Debug.Log(Vector2.Distance(finalPosition, finalPosition3));
        }
        Debug.Log(finalPosition);
        Debug.Log(finalPosition3);
        StartCoroutine(Run());
    }
    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, -targdirection, distance, ~layer);
        

        Debug.DrawRay(transform.position, - targdirection);
        Debug.Log(ray.collider.gameObject.name);
        if (MaskToggle.isHiding == false)
        {
            if (attackCor == false)
            {
                if (ray.collider.gameObject.layer == 8)
                {
                    seePlayer = true;
                }
                else
                {
                    seePlayer = false;
                }
            }
            else
            {
                seePlayer = true;
            }
            Debug.Log(seePlayer);
        } else
        {
            seePlayer = false ;
        }
        distance = Vector2.Distance(transform.position, targ.position);

        if (attackCor == true)
        {
            if (hitbox.IsTouching(targ.GetComponent<targetcolliderscript>().hurtbox) == true)
            {
                Debug.Log("hit");
              
            }
        }

        if (enemyHealth == 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
            enemyKilled = true; 
        }
        Debug.Log(transform.forward);

    }

    IEnumerator Run() //(a)
    {
        agent.SetDestination(finalPosition3);
        GetComponent<NavMeshAgent>().autoBraking = true;
        GetComponent<NavMeshAgent>().speed = 1f;
        GetComponent<NavMeshAgent>().angularSpeed = 30f;
        GetComponent<NavMeshAgent>(). acceleration = 3f;


        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        while (seePlayer == false) { 
            
            
            if ((transform.position.x + 0.5 >= finalPosition.x && transform.position.x - 0.5 <= finalPosition.x) && (transform.position.y + 0.5 >= finalPosition.y && transform.position.y - 0.5 <= finalPosition.y))
            {
                //ignore this if statement guys please
                //there was no other way to do it i promise you gotta trust 
                agent.SetDestination(finalPosition3);
            } else if ((transform.position.x + 0.5 >= finalPosition3.x && transform.position.x - 0.5 <= finalPosition3.x) && (transform.position.y + 0.5 >= finalPosition3.y && transform.position.y - 0.5 <= finalPosition3.y))
            {
                agent.SetDestination(finalPosition);
            }
                yield return new WaitForSeconds(0.1f);

        }
        StartCoroutine(runthesecond());
        StopCoroutine(Run());
    }

    IEnumerator wait()
    {

        yield break;
    }

    IEnumerator runthesecond() //(a)
    {
        GetComponent<NavMeshAgent>().autoBraking = false;
        GetComponent<NavMeshAgent>().speed = 7f;
        GetComponent<NavMeshAgent>().angularSpeed = 120f;
        GetComponent<NavMeshAgent>().acceleration = 8f;

        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        while (distance >= 1f && seePlayer == true)
            {
                agent.SetDestination(targ.position);
                yield return new WaitForSeconds(0.2f);
                // Debug.Log("aaaaaaa");
            if (targdirection.x >= 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            }
            if (distance <= 1f && seePlayer == true)
            {
                agent.SetDestination(gameObject.transform.position);
                StartCoroutine(attack());
                StopCoroutine(runthesecond());
            }
            else if (seePlayer == false)
            {
                StartCoroutine(meow());
            }

    }

    IEnumerator meow()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        for (int i = 0; i < 10; i++) {
            agent.SetDestination(targ.position);
            if (targdirection.x >= 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            yield return new WaitForSeconds(0.1f);

            if (seePlayer == true) {
                StartCoroutine(runthesecond());
                yield break;
            }
            if (MaskToggle.isHiding == true)
            {
                StartCoroutine(Run());
                yield break;
            }
        }

        agent.SetDestination(gameObject.transform.position);
        StartCoroutine(Run());
        yield break;
    }

    IEnumerator attack()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        if (targdirection.x >= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        yield return new WaitForSeconds(0.5f);
        
        hitbox.enabled = true;
        attackCor = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(.25f);

        if (hitbox.IsTouching(targ.GetComponent<targetcolliderscript>().hurtbox) == true)
        {
            pH.health = pH.health - 1;

        }

        yield return new WaitForSeconds(0.5f);

        attackCor = false;
        hitbox.enabled = false;
        GetComponent<SpriteRenderer>().color = Color.white;

        StartCoroutine(runthesecond());
        StopCoroutine(attack());
    }

    
    //new thing lol 
    //coroutine? (no idea how to spell that)
    //when close enough
    //stop movement
    //stop raycast for a bit
    //do attack thing (launch forawrd and spawn hitbox)
    //respawn everything else

    //man was dexton capping? (quite possibly)

    // i fixed the attack but the stupid ray.collider.gameObject.name code is generating thousands of errors 

}



