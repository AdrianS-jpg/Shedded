using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public bool PlayerDetected;
    public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

    [Header("OverlapBox parameters")]
    [SerializeField]
    private Transform detectorOrigin;
    public Vector2 detectorSize = Vector2.one;
    public Vector2 detectorOriginOffset = Vector2.zero;

    public float detectionDelay = 0.3f;

    public LayerMask detectorLayermask;

    [Header("Gizmos")]
    public Color gizmoIdleColor = Color.green;
    public Color gizmodetectedColor = Color.red;
    public bool showGizmos = true;

    private GameObject target;

    public GameObject Target
    {
        get => target;
        private set
        {
            target = value;
            PlayerDetected = target != null;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DetectionCoroutine());
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionDelay);
        PerformDetection();
    }

    public void PerformDetection() {
        Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0 , detectorLayermask);
        if (collider != null) 
        { 
            Target = collider.gameObject;
        }
        else
        {
            Target = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (showGizmos && detectorOrigin != null) { 
            Gizmos.color = gizmoIdleColor;
            if (PlayerDetected)
                Gizmos.color = gizmodetectedColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
