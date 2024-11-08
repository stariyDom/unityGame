using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int jumpCount;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    
    private bool isTouchSurface;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        runningSpeed = 3;
        jumpSpeed = 6;
        jumpCount = 2;
    }
 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * runningSpeed, body.velocity.y);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && (isTouchSurface || jumpCount>0))
        {
            Jump();
        }
        

        //sets animation parameters
        
    }
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        jumpCount--;
        isTouchSurface = false;
    }
    

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            bool isGrounded = col.Length > 1;
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
