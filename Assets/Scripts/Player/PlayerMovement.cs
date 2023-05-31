using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //how much time the player can hang in the air before jumping
    private float coyoteCounter; //how much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
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
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("isGrounded", isGrounded());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 3);
        }

        body.gravityScale = 3;
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (isGrounded())
        {
            coyoteCounter = coyoteTime; //reset coyote counter when on the ground
            jumpCounter = extraJumps; //reset jump counter to extra jump value
        }
        else
        {
            coyoteCounter -= Time.deltaTime; //start decreasing coyote counter when not on the ground
        }
    }

    public bool CanJump()
    {
        if (coyoteCounter <= 0 && jumpCounter <= 0) return false;
        return true;
    }

    public void Jump()
    {
        anim.SetTrigger("jump");

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        //else
        //{
        //    if (coyoteCounter > 0) //if not on the ground and coyote counter bigger than 0 do a normal jump
        //    {
        //        //anim.SetTrigger("doubleJump");
        //        body.velocity = new Vector2(body.velocity.x, jumpPower);
        //    }
        //    else
        //    {
        //        if (jumpCounter > 0) //if we have extra jumps then jump and decrease the jump counter
        //        {
        //            //anim.SetTrigger("doubleJump");
        //            body.velocity = new Vector2(body.velocity.x, jumpPower);
        //            jumpCounter--;
        //        }
        //    }
        //}

        //reset coyote counter to 0 to avoid double jumps
        coyoteCounter = 0;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }

    public void ChangeDirection(float value)
    {
        horizontalInput = value;
    }

    public void ResetDirection()
    {
        horizontalInput = 0f;
    }
}
