using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    [Header("Sound")]
    [SerializeField] private AudioClip jumpSound;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        horizontalInput = Input.GetAxis("Horizontal");
#endif
        Movement();
    }

    public void Movement()
    {
        if (horizontalInput > 0.01f)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontalInput < -0.01f)
            transform.eulerAngles = new Vector3(0, 180, 0);

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("isGrounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        // Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        body.gravityScale = 3;
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
    }

    public void Jump()
    {
        anim.SetTrigger("jump");

        if (isGrounded())
            body.velocity = new Vector2(body.velocity.x, jumpPower);
    }
    public void JumpOnEnemyHead()
    {
        anim.SetTrigger("jump");
        body.velocity = new Vector2(body.velocity.x, jumpPower / 2);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return raycastHit.collider != null;
    }

    public void ChangeDirection(float value)
    {
        horizontalInput = value;
    }

    public void ResetDirection()
    {
        horizontalInput = 0f;
    }

    //public void JumpOnMobile(float _jumpPower, float jumpTime, float maxJumpTime)
    //{
    //    anim.SetTrigger("jump");

    //    if (isGrounded())
    //        body.velocity = new Vector2(body.velocity.x, _jumpPower);
    //    else if (jumpTime > maxJumpTime)
    //        body.velocity = new Vector2(body.velocity.x, _jumpPower / 2);
    //}
}
