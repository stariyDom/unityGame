using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float running_speed;
    [SerializeField] private float jump_speed;
    [SerializeField] private int jumpCount;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        running_speed = 3;
        jump_speed = 3;
        jumpCount = 2;
    }
 
    private void Update()
    {
        CheckGround();
        float horizontalInput = Input.GetAxis("Horizontal");
        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            //horizontalInput = 0;
        body.velocity = new Vector2(horizontalInput * running_speed, body.velocity.y);
 
        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && (grounded || jumpCount>0))
        {
            Jump();
        }

        if (body.velocity.y < 0)
            Drop();

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
        
    }
 
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jump_speed);
        anim.SetTrigger("jump");
        jumpCount--;
        grounded = false;
    }
    
    private void Drop()
    {
        anim.SetTrigger("drop");
        grounded = false;
    }
 
    private void CheckGround() {
        Colider2D collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        if (collider.Length > 1)
        {
            grounded = true;
            jumpCount = 2;
        }
    }
}
