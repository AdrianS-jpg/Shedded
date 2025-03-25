using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public RaycastHit2D ray;
    public Transform targ;
    public Transform self;
    public Vector2 targdirection;
    [SerializeField] Transform target;
    NavMeshAgent agent;
    private void Start()
    {
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targdirection);
        StartCoroutine(Check());
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        agent.SetDestination(target.position);
        targdirection = self.position - targ.position;
        ray = Physics2D.Raycast(transform.position, targdirection);
        if (ray)
        {
            float distance = Mathf.Abs(ray.point.y - transform.position.y);
            Debug.Log("aslhasdfkhasdfahslkdfhalskdjfhalskjdfhalskdjf");
        }
    }

    IEnumerator Check()
    {
       
        yield return new WaitForSeconds(0.1f);
    }
}

