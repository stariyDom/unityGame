using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.U2D;
public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //�������� ��������
    [SerializeField] private int lives = 3; //���������� ������
    [SerializeField] private float jumpForce = 15f; //���� ������
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal"))
            Run();
        if (Input.GetButtonDown("Jump"))
            Jump();
    }
    private void Run() 
    { 
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed* Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }

}

public enum States
{
    idle,
    run
}