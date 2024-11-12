using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_paralax : MonoBehaviour
{
    public float paralaxSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            
            transform.Translate(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * paralaxSpeed, 0.0f));
        }
    }
}
