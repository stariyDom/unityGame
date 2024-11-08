using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float running_speed;
    [SerializeField] private float jump_speed;
    [SerializeField] private int jumpCount;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    
    private bool grounded;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        running_speed = 3;
        jump_speed = 3;
        jumpCount = 2;
    }
 
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * running_speed, body.velocity.y);

        if (grounded)
        {
            jumpCount = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && (grounded || jumpCount>0))
        {
            Jump();
        }
        

        //sets animation parameters
        
    }
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_speed);
        jumpCount--;
        grounded = false;
    }
    

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
