using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class batAI2 : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float health;
    [SerializeField] private AIPath aiPath;

    private void Awake()
    {
        health = 25f;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x <= 0.01f;

    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < 0f) Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // �������� �� ������������ ����� � �������
        {
            collision.collider.GetComponent<PlayerMovement>().TakeDamage(transform.position, 1);
        }
    }


}
