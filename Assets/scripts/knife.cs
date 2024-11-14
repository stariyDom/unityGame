using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class knife : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public float length;
    
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = 3f;
        speed = 10;
        length = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitRecord = Physics2D.Raycast(transform.position, transform.up, length, whatIsSolid);
        lifetime -= Time.deltaTime;
        if(lifetime < 0f) Destroy(gameObject);
        
        if (hitRecord.collider != null)
        {
            if (hitRecord.collider.CompareTag("Enemy"))
            {
                hitRecord.collider.GetComponent<RatController>().TakeDamage( 10f);
                Destroy(gameObject);
            }

            if (hitRecord.collider.CompareTag("EnemyBat1"))
            {
                hitRecord.collider.GetComponent<batAI>().TakeDamage(10f);
                Destroy(gameObject);
            }
            
            if (hitRecord.collider.CompareTag("EnemyBat2"))
            {
                hitRecord.collider.GetComponent<batAI2>().TakeDamage(10f);
                Destroy(gameObject);
            }
            
            if (hitRecord.collider.CompareTag("Boss"))
            {
                hitRecord.collider.GetComponent<Boss>().TakeDamage(10f);
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Translate(Time.deltaTime * speed * Vector2.up);
        }

    }
}
