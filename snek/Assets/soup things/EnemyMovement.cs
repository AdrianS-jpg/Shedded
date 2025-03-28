using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float distance;
    public RaycastHit2D ray;
    public Transform targ;
    public Transform self;
    public Vector2 targdirection;
    public bool seePlayer; 
    RaycastHit2D[] hit;
    NavMeshAgent agent;
    public CircleCollider2D hitbox;
    public BoxCollider2D hurtbox;
    public boxeslol boxeslol;
    public int health = 50;
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
        ray = Physics2D.Raycast(transform.position, - targdirection);
        Debug.DrawRay(transform.position, - targdirection);
        Debug.Log(ray.collider.gameObject.name);
        if (ray.collider.gameObject.name == "target")
        {
            seePlayer = true;
        } else
        {
            seePlayer = false;
        }
            Debug.Log(seePlayer);
        distance = Vector2.Distance(transform.position, targ.position);
        if (hitbox.IsTouching(GameObject.Find("target").GetComponent<targetcolliderscript>().hurtbox) == true)
        {
            Debug.Log("asasdfasasdfasdfsadfsaddf");
            health = health - 3;
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
        while (distance >= 1f)
        {
            agent.SetDestination(targ.position);
            yield return new WaitForSeconds(0.2f);
            Debug.Log("aaaaaaa");
        }
        agent.SetDestination(gameObject.transform.position);
        StartCoroutine(attack());
        StopCoroutine(runthesecond());
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        
        hitbox.enabled = true;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(0.5f);

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
}



