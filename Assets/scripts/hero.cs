using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int jumpCount;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int lives;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator animator;



    private bool isTouchSurface;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        runningSpeed = 3;
        jumpSpeed = 6;
        jumpCount = 2;
        lives = 4;
    }
 
    private void Update()
    {
        if (lives <= 0)
        {
            animator.SetTrigger("death");
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * runningSpeed, body.velocity.y);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && (isTouchSurface || jumpCount>0))
        {
            Jump();
        }

        UpdateAnimator();
        isGrounded = isOnGround();
    }
 
    private void Jump()
    {
        animator.SetTrigger("jump");
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        jumpCount--;
        isTouchSurface = false;
    }

    private void UpdateAnimator()
    {
        animator.SetInteger("hp_absent", 4 - lives);
        animator.SetBool("run" , Input.GetAxis("Horizontal") != 0);
        animator.SetBool("grounded", isOnGround());
        if (body.velocity.y < 0)
            animator.SetTrigger("drop");
        if (body.velocity.magnitude > 0.01)
            transform.localScale = body.velocity.x > 0 ? Vector3.one : new Vector3(-1,1,1);
    }


    private bool isOnGround()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        return col.Length > 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            bool isGrounded = isOnGround();
            jumpCount = isGrounded ? 2 : 1;
            isTouchSurface = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isTouchSurface = false;
        }
    }
}
