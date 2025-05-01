using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Transforms")]
    public Transform targ;
    public Transform self;
    public Vector2 targdirection;

    [Header("Components")]
    public GameObject hitboxout;
    public PolygonCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    public NavMeshAgent agent;
    public Animator animator;

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
    float horizontalMove = 0f;
    float verticalMove = 0f;
    float _move = 0f;
    public LayerMask layer;
    public static GameObject GameObject;
    public float exe;
    public bool facingplayer;
    public Vector3 player;
    
    private void Start()
    {
        player = transform.position;
        exe = transform.position.x;
        GameObject = gameObject;
        hurtbox.enabled = true;
        hitbox.enabled = false;

        distance = Vector2.Distance(transform.position, targ.position);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targdirection);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StartCoroutine(Run());
        StartCoroutine(resetposition());
    }
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * 5;
        //verticalMove = Input.GetAxisRaw("Vertical") * 5;
        //_move = horizontalMove + verticalMove;
        //animator.SetFloat("Speed", Mathf.Abs(_move));
        //gameObject.transform.rotation = new Quaternion(0,0,0,0);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, -targdirection, distance, ~layer);
        Debug.DrawRay(transform.position, - targdirection);
        animator.SetBool("moveing", true);
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
        if (hurtbox.IsTouching(PlayerAttack.attackArea.GetComponent<PolygonCollider2D>()))
        {
            if (PlayerAttack.touching.Contains(gameObject) != true)
            {
                PlayerAttack.touching.Add(gameObject);
            }
        } else
        {
            PlayerAttack.touching.RemoveAll(ifGameObject);
        }
        //if (targdirection.x <= 0)
        //{
        //    if (GetComponent<SpriteRenderer>().flipX == false)
        //    {
        //        facingplayer = false;
        //    }
        //    else
        //    {
        //        facingplayer = true;
        //    }
        //} else
        //{
        //    if (GetComponent<SpriteRenderer>().flipX == true)
        //    {
        //        facingplayer = false;
        //    }
        //    else
        //    {
        //        facingplayer = true;
        //    }
        //}
        //if (exe > transform.position.x)
        //{
        //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 0);
        //    GetComponent<SpriteRenderer>().flipX = false;
        //}
        //else
        //{
        //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 180);
        //    GetComponent<SpriteRenderer>().flipX = true;
        //}
    }

    public static bool ifGameObject(GameObject thing)
    {
        return thing == GameObject;
    }

    public void damage() {
        Debug.Log("helpme");
        StopAllCoroutines();
        agent.ResetPath();
        hitbox.enabled = false;
        hurtbox.enabled = false;
        PlayerAttack.touching.RemoveAll(ifGameObject);
        StartCoroutine(dam());
    }

    //coroutine hell V

    IEnumerator Run() //(a)
    {
        if (gameObject.GetComponent<NavMeshAgent>().enabled == true)
        {
            agent.SetDestination(finalPosition3);
        }
        else
        {
            Debug.Log("s");
        }
        GetComponent<NavMeshAgent>().autoBraking = true;
        GetComponent<NavMeshAgent>().speed = 1f;
        GetComponent<NavMeshAgent>().angularSpeed = 30f;
        GetComponent<NavMeshAgent>().acceleration = 3f;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        while (seePlayer == false || facingplayer == false) 
        {
            if ((transform.position.x + 0.5 >= finalPosition.x && transform.position.x - 0.5 <= finalPosition.x) && (transform.position.y + 0.5 >= finalPosition.y && transform.position.y - 0.5 <= finalPosition.y))
            {
                //ignore this if statement guys please
                //there was no other way to do it i promise you gotta trust 
                agent.SetDestination(finalPosition3);
            } else if ((transform.position.x + 0.5 >= finalPosition3.x && transform.position.x - 0.5 <= finalPosition3.x) && (transform.position.y + 0.5 >= finalPosition3.y && transform.position.y - 0.5 <= finalPosition3.y))
            {
                agent.SetDestination(finalPosition);
            }
            if (targdirection.x <= 0)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    facingplayer = false;
                }
                else
                {
                    facingplayer = true;
                }
            }
            else
            {
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    facingplayer = false;
                }
                else
                {
                    facingplayer = true;
                }
            }
            if (exe > transform.position.x)
            {
                hitboxout.transform.rotation = Quaternion.Euler(1, 1, 0);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                hitboxout.transform.rotation = Quaternion.Euler(1, 1, 180);
                GetComponent<SpriteRenderer>().flipX = true;
            }


            exe = transform.position.x;
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
            Debug.Log("Dead");
            targ.GetComponent<MaskToggle>().hideDuration = 5;
            MaskToggle.canHide = true;
            if (upgrade.healthOnKillBool == true)
            {
                GetComponent<upgrade>().healthOnKillThing();
            }
            Destroy(gameObject);
            
        }
        //transform.position = new Vector3(transform.position.x + targdirection.x,transform.position.y + targdirection.y,0);
        agent.velocity = Vector3.zero;
        Vector2 hitdirection = targdirection;
        for (int i = 0; i < 4; i++)
        {
            gameObject.transform.position = new Vector3(transform.position.x + ((hitdirection.x / (4-i)) / 2), transform.position.y + ((hitdirection.y / (4-i)) / 2), 0);
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(1f);
            if (seePlayer == true)
            {
                StartCoroutine(runthesecond());
            }
            else
            {
                StartCoroutine(Run());
            }
        yield return new WaitForSeconds(0.5f);
        hurtbox.enabled = true;
        yield break;
    }

    IEnumerator runthesecond() //(a)
    {
        agent.SetDestination(finalPosition3);
        GetComponent<NavMeshAgent>().autoBraking = false;
        GetComponent<NavMeshAgent>().speed = 7f;
        GetComponent<NavMeshAgent>().angularSpeed = 120f;
        GetComponent<NavMeshAgent>().acceleration = 8f;

        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        while (distance >= 1f && seePlayer == true)
        {
            agent.SetDestination(targ.position);
            
            if (targdirection.x >= 0)
            {
                hitboxout.transform.rotation = Quaternion.Euler(1, 1, 0);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                hitboxout.transform.rotation = Quaternion.Euler(1, 1, 180);
                GetComponent<SpriteRenderer>().flipX = true;
            }
            yield return new WaitForSeconds(0.2f);
            // Debug.Log("aaaaaaa");
            

        }
            if (distance <= 1f && seePlayer == true)
            {
                StartCoroutine(attack());

                

                yield break;
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
            //if (targdirection.x >= 0)
            //{
            //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 0);
            //    GetComponent<SpriteRenderer>().flipX = false;
            //}
            //else
            //{
            //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 180);
            //    GetComponent<SpriteRenderer>().flipX = true;
            //}
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

        
        StartCoroutine(Run());
        yield break;
    }

    IEnumerator attack()
    {
        animator.SetTrigger("attack");
        //if (targdirection.x >= 0)
        //{
        //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 0);
        //    GetComponent<SpriteRenderer>().flipX = false;
        //}
        //else
        //{
        //    hitboxout.transform.rotation = Quaternion.Euler(1, 1, 180);
        //    GetComponent<SpriteRenderer>().flipX = true;
        //}
        attackCor = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        agent.SetDestination(targ.position);
        hitbox.enabled = true;
        yield return new WaitForSeconds(0.3f);
        
        
        
        for (int i = 0; i < 10; i++) 
        {
            if (PlayerHealth.isHit == false)
            {
                if (hitbox.IsTouching(targ.GetComponent<targetcolliderscript>().hurtbox) == true)
                {
                    targ.GetComponent<PlayerHealth>().Damage();
                    break;
                }
                yield return new WaitForSeconds(0.02f);
            }
        }
        attackCor = false;
        hitbox.enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;

        StartCoroutine(runthesecond());
        StopCoroutine(attack());

       
    }

    IEnumerator resetposition()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        transform.position = player;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, NavMesh.AllAreas);
        finalPosition = hit.position;
        Vector3 randomDirection3 = Random.insideUnitSphere * walkRadius;
        randomDirection3 += transform.position;
        NavMeshHit hit3;
        NavMesh.SamplePosition(randomDirection3, out hit3, walkRadius, NavMesh.AllAreas);
        finalPosition3 = hit3.position;
        while (Vector2.Distance(finalPosition, finalPosition3) <= 3)
        {
            randomDirection3 = Random.insideUnitSphere * walkRadius;
            randomDirection3 += transform.position;
            NavMesh.SamplePosition(randomDirection3, out hit3, walkRadius, NavMesh.AllAreas);
            finalPosition3 = hit3.position;
        }
        StartCoroutine(Run());
        yield break;
    }

    public void OnAttack(bool attacking)
    {
        animator.SetBool("attacking", attackCor);
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



