using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    [SerializeField] private float health;
    public GameObject rewardPrefab;

    void Start()
    {
        health = 100f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

        public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    public void TakeDamage(Vector3 from, float damage)
     {
         health -= damage;
         if (health <= 0f) {
             Vector3 coord = transform.position;
             rewardPrefab.SetActive(true);
             Destroy(gameObject);
         }
     }
}


