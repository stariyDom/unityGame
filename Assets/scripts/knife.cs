using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class knife : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public int length;
    
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        length = 1;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitRecord = Physics2D.Raycast(transform.position, transform.up, length, whatIsSolid);
        transform.Translate(Time.deltaTime * speed * Vector2.up);
    }
}
