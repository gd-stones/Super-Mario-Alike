using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    private float movementDistance = 5f;
    private float leftEdge;
    private float rightEdge;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = true;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Condition run animation")]
    [SerializeField] private string condition; //radish_Run
    private Animator anim;

    [Header("Collision Detection")]
    [SerializeField] private LayerMask obstacleLayer;

    private void Start()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        anim = gameObject.GetComponent<Animator>();

        initScale = transform.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= leftEdge && !CheckObstacle(1))
                MoveInDirection(1);
            else
                DirectionChange();
        }
        else
        {
            if (transform.position.x <= rightEdge && !CheckObstacle(-1))
                MoveInDirection(-1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        anim.SetBool(condition, false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool(condition, true);

        // Make transform face direction
        transform.localScale = new Vector3(initScale.x * direction, initScale.y, initScale.z);
        // Move in that direction
        transform.position = new Vector3(transform.position.x - Time.deltaTime * direction * speed,
            transform.position.y, transform.position.z);
    }

    private bool CheckObstacle(int direction)
    {
        // Cast a ray to check for obstacles
        Vector2 rayOrigin = new Vector2(transform.position.x - direction * 1.2f, transform.position.y + 0.25f);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector3.right * direction, 0.4f, obstacleLayer);

        //Debug.DrawRay(rayOrigin, (Vector3.right * direction) * 0.5f, Color.red);
        return hit.collider != null;
    }
}
