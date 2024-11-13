using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public float offset;
    public float knifeOffset;
    public GameObject knife;
    public Transform throwPoint;
    public int maxKnives;
    
    void Start()
    {
        maxKnives = 1;
        offset = -90f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0))
        {
            var knives = GameObject.FindGameObjectsWithTag("Knife");
            if (knives.Length < maxKnives)
            {   
                Instantiate(knife, throwPoint.position, transform.rotation);
            }
        }
    }
}
