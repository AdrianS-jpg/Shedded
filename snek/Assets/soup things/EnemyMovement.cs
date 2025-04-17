using System.Buffers;
using System.Collections;
using System.Collections.Generic;
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
    public PolygonCollider2D hitbox;
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
    public static GameObject GameObject;
    private void Start()
    {
        GameObject = gameObject;
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
        Debug.Log(transform.forward);
        if (hitbox.IsTouching(PlayerAttack.attackArea.GetComponent<PolygonCollider2D>()))
        {
            if (PlayerAttack.touching.Contains(gameObject))
            {
                
            }
            else
            {
                PlayerAttack.touching.Add(gameObject);
                
            }
        } else
        {
            PlayerAttack.touching.RemoveAll(ifGameObject);
        }
    }

    public static bool ifGameObject(GameObject thing)
    {
        return thing == GameObject;
    }

    public void damage() {
        Debug.Log("helpme");
        StopAllCoroutines();
        hitbox.enabled = false;
        hurtbox.enabled = false;
        StartCoroutine(dam());
    }


    IEnumerator Run() //(a)
    {
        agent.SetDestination(finalPosition3);
        GetComponent<NavMeshAgent>().autoBraking = true;
        GetComponent<NavMeshAgent>().speed = 1f;
        GetComponent<NavMeshAgent>().angularSpeed = 30f;
        GetComponent<NavMeshAgent>().acceleration = 3f;


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
        yield break;
    }

    IEnumerator dam()
    {
        //put stun code here ig
        //dont look at me man i have zero creativity
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("fire");
        enemyHealth -= 1;
        if (enemyHealth == 0)
        {
            MaskToggle.canHide = true;
            Destroy(gameObject);
            Debug.Log("Dead");
        }
        yield return new WaitForSeconds(1f);
        if (seePlayer == true)
        {
            StartCoroutine(runthesecond());
        } else
        {
            StartCoroutine(Run());
        }
        hurtbox.enabled = true;
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
                    for (int i = 0; i < hitbox.points.Length; i++)
                    {
                        if (hitbox.points[i].x > 0)
                        {
                            hitbox.points[i] = new Vector2(hitbox.points[i].x * -1, hitbox.points[i].y);
                        }                
                    }
                    GetComponent<SpriteRenderer>().flipX = false;
                Debug.Log("left");
                } else
                {
                    for (int i = 0; i < hitbox.points.Length; i++)
                    {
                    Debug.Log("whyyhadjhasuh");
                    Debug.Log(hitbox.points[i].x);
                        if (hitbox.points[i].x < 0)
                        {
                        hitbox.points[i] = new Vector2(Mathf.Abs(hitbox.points[i].x), hitbox.points[i].y);
                        Debug.Log(hitbox.points[i].x);
                    } 
                }
                GetComponent<SpriteRenderer>().flipX = true;
                Debug.Log("right");
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
    //he be a little silly like that (ignore it its stupid)

}



