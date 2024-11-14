using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class batAI : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private AIPath aiPath;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x >= 0.01f;

    }

}
