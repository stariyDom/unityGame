using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    [SerializeField] private float health;
    private float maxHealth;
    public GameObject rewardPrefab;
    public Image hpBar;

    void Start()
    {
        maxHealth = 100f;
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hpBar = GameObject.FindGameObjectWithTag("hpBar").GetComponent<Image>();
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
        
    public void TakeDamage(float damage)
     {
         health -= damage;
         if (health <= 0f) {
             Vector3 coord = transform.position;
             rewardPrefab.SetActive(true);
             Destroy(gameObject);
         }
     }
    
    public void Update()
    {
        UpdateHpBar();
    }
    private void UpdateHpBar()
    {
        float hpRatio = health / maxHealth;
        hpBar.fillAmount = hpRatio;
    }
}


