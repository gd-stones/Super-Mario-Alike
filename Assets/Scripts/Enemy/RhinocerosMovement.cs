using UnityEngine;
using System.Collections;

public class RhinocerosMovement : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft = true;
    private bool isMoving = true;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Name condition run")]
    [SerializeField] private string condition;
    private Animator anim;

    private Rigidbody2D rb;
    private float initCoordinatesY;

    private void Start()
    {
        anim = GetComponent<Animator>();
        initScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        initCoordinatesY = transform.localPosition.y;
    }

    private void FixedUpdate()
    {
        // 1 <=> movement to the left; -1 <=> movement to the right
        if (movingLeft && isMoving)
            MoveInDirection(1);
        else if (!movingLeft && isMoving)
            MoveInDirection(-1);
        else
            DirectionChange();

        if ((initCoordinatesY + 0.2f) < transform.localPosition.y)
            StartCoroutine(MoveUpAndDown());
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
        rb.velocity = new Vector3(Time.fixedDeltaTime * -direction * speed, rb.velocity.y, 0);
    }

    private IEnumerator MoveUpAndDown()
    {
        float duration = 0.35f;
        float elapsedTime = 0f;

        transform.eulerAngles = new Vector3(0, 0, 180);
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;

        while (elapsedTime < duration)
        {
            rb.velocity = new Vector3(0, Time.fixedDeltaTime * 100, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        while (transform.position.y > -6)
        {
            rb.gravityScale = 20;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            yield return null;
        }

        gameObject.GetComponent<EnemyHealth>()?.EnemyTakeDamage();
    }
}
