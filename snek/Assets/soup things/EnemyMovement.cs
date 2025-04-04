using System.Buffers;
using System.Collections;
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
    
    public LayerMask layer;

    private void Start()
    {
        hurtbox.enabled = false;
        hitbox.enabled = false;

        distance = Vector2.Distance(transform.position, targ.position);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targdirection);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        StartCoroutine(Run());
    }
    void Update()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, -targdirection, distance, ~layer);
        

        Debug.DrawRay(transform.position, - targdirection);
        // Debug.Log(ray.collider.gameObject.name);

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
    }

    IEnumerator Run()
    {
        while (distance >= 2.5f && seePlayer == false) { 
            
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(runthesecond());
        StopCoroutine(Run());
    }

    IEnumerator runthesecond()
    {
        while (distance >= 1f && seePlayer == true)
        {
            agent.SetDestination(targ.position);
            yield return new WaitForSeconds(0.2f);
           // Debug.Log("aaaaaaa");
        } 
        if (distance <= 1f)
        {
            agent.SetDestination(gameObject.transform.position);
            StartCoroutine(attack());
            StopCoroutine(runthesecond());
        }
        else if (seePlayer == false) {
            StartCoroutine(meow());
        }
        else {
            
        }
        
    }

    IEnumerator meow()
    {
        for (int i = 0; i < 10; i++) {
            agent.SetDestination(targ.position);
            yield return new WaitForSeconds(0.1f);

            if (seePlayer == true) {
                StartCoroutine(runthesecond());
                yield break;
            }
        }

        agent.SetDestination(gameObject.transform.position);
        StartCoroutine(Run());
        yield break;
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        
        hitbox.enabled = true;
        attackCor = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(.25f); 
        pH.health = pH.health - 1;

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



