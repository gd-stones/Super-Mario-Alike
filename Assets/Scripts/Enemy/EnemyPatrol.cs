using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = false;
    private bool isMoving = true;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Name condition run")]
    [SerializeField] private string condition; // radish_Run
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        initScale = transform.localScale;
    }

    private void Update()
    {
        // 1 <=> movement to the left; -1 <=> movement to the right
        if (movingLeft && isMoving)
            MoveInDirection(1);
        else if (!movingLeft && isMoving)
            MoveInDirection(-1);
        else
            DirectionChange();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Ground")
            isMoving = false;
    }

    private void DirectionChange()
    {
        anim.SetBool(condition, false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
            isMoving = true;
        }
    }

    public void MoveInDirection(int direction)
    {
        idleTimer = 0;
        anim.SetBool(condition, true);

        // Make transform face direction
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        transform.position = new Vector3(transform.position.x - Time.deltaTime * direction * speed,
            transform.position.y, transform.position.z);
    }
}
