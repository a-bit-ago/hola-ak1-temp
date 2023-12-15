using UnityEngine;
using UnityEngine.Assertions.Must;
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalMovement;

    private Vector2 moveDirection;
    private bool isFacingRight;

    [Header("Movement Variable")]
    [SerializeField] private float moveSpeed;
    [Header("Jumping Variables")]
    [SerializeField] private float jumpForce;
    private int maxJumps = 2;
    private int jumpsRemaining;


    [Header("Ground Check")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private LayerMask groundLayer;

    [Header("Gravity")]
    [SerializeField] private float baseGravity = 2f;
    [SerializeField] private float maxFallSpeed = 18f;
    [SerializeField] private float fallMultiplier = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        Gravity();
        Flip();
        if (IsGrounded())
        {
            jumpsRemaining = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJumpUp();
        }
        animator.SetFloat("IsFalling",rb.velocity.y);

    }

    private void OnJumpUp()
    {
        if (jumpsRemaining > 0)
        {
            Jump();
        }

    }
    private void Flip()
    {
        if (isFacingRight && moveDirection.x > 0 || !isFacingRight && moveDirection.x < 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void Gravity()
    {
        //Faller neråt
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallMultiplier;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));

        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        moveDirection = new Vector2(horizontalMovement, 0);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
        animator.SetBool("IsRunning", moveDirection != Vector2.zero);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsRemaining--;
        animator.SetTrigger("IsJumping");


    }

    private bool IsGrounded()
    {

        return (Physics2D.OverlapBox(groundCheckPoint.position, groundCheckSize, 0, groundLayer));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPoint.position, groundCheckSize);
    }
}