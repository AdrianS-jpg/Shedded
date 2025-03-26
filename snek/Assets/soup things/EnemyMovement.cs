using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Timeline;
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
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private void Start()
    {
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

        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targ.position);
        Debug.Log(ray.collider);
        if (ray == null)
        {
            seePlayer = true;
        } else
        {
            seePlayer = false;
        }
            distance = Vector2.Distance(transform.position, targ.position);
    }

    IEnumerator Run()
    {
        while (distance >= 2.5f) { 
            
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(runthesecond());
        StopCoroutine(Run());
    }

    IEnumerator runthesecond()
    {
        while (enabled == true)
        {
            agent.SetDestination(target.position);
            yield return null;
        }
    }
}



