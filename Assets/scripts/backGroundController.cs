using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<CameraController>().transform;
        }
    }
    private void Update()
    {
        pos.x = player.position.x-3;
        pos.y = player.position.y-3;
        pos.z = -5;

        transform.position = pos;
    }
}
