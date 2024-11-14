using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int jumpCount;
    [SerializeField] private bool isGrounded;
    [SerializeField] private int lives;
    private Rigidbody2D body;
    private SpriteRenderer hero;
    private Animator hpAnim;
    private Animator heroAnim;
    private SpriteRenderer backKnife;
    private SpriteRenderer hpSprite;
    private bool isAlive;
    private float timeImmune;

    private bool isImmune;
    private bool isTouchSurface;

    private void Awake()
    {   
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        heroAnim = GetComponentsInChildren<Animator>()[0]; 
        hpAnim = GetComponentsInChildren<Animator>()[1];

        backKnife = GetComponentsInChildren<SpriteRenderer>()[0];
        hero = GetComponentsInChildren<SpriteRenderer>()[1];
        hpSprite = GetComponentsInChildren<SpriteRenderer>()[2];
        
        runningSpeed = 3;
        jumpSpeed = 6;
        jumpCount = 2;
        lives = 4;
        timeImmune = 0;

        isImmune = false;
        isAlive = true;
    }

    public void PushAway(Vector3 pushFrom, float pushPower)
    {
        
        if (pushPower == 0) { return; }

        Vector3 pushDirection = (pushFrom - transform.position).normalized;
        pushDirection += Vector3.up;

        body.AddForce(pushDirection * pushPower);
        
    }

    private void FixedUpdate()
    {
        UpdateAnimator();
        UpdateVisibility();
        UpdateImmune();
    }

    public void UpdateImmune()
    {
        timeImmune -= Time.deltaTime;
        isImmune = timeImmune > 0f;

    }
    public void TakeDamage(Vector3 from, int damage)
    {
        if (isImmune) return;
        lives -= damage;
        timeImmune = 2;
        PushAway(from, 220f);
    }

    private void UpdateVisibility()
    {
        var knives = GameObject.FindGameObjectsWithTag("Knife");
        backKnife.enabled = knives.Length == 0;
        
        hpSprite.enabled = !isImmune;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.K)) --lives;
        //if (Input.GetMouseButtonDown(0))
        //    PushAway(Input.mousePosition, 100f);


        if (lives <= 0 )
        {
            if (isAlive)
            {
                heroAnim.SetTrigger("death");
                isAlive = !true;
                SceneManager.LoadScene(6);
            }
            return;
        }
        
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * runningSpeed, body.linearVelocity.y);
        
        
        if (Input.GetKeyDown(KeyCode.Space) && (isTouchSurface || jumpCount>0))
        {
            Jump();
        }

        isGrounded = isOnGround();
    }
 
    private void Jump()
    {
        heroAnim.SetTrigger("jump");
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpSpeed);
        jumpCount--;
        isTouchSurface = false;
    }

    private void UpdateAnimator()
    {
        hpAnim.SetInteger("hp_absent", 4 - lives);
        heroAnim.SetBool("run" , Input.GetAxis("Horizontal") != 0);
        heroAnim.SetBool("grounded", isOnGround());
        if (body.linearVelocity.y < 0)
            heroAnim.SetTrigger("drop");
        if (body.linearVelocity.magnitude > 0.01)
            transform.localScale = body.linearVelocity.x > 0 ? Vector3.one : new Vector3(-1,1,1);
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
