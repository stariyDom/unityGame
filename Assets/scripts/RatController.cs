using UnityEngine;

public class RatController : MonoBehaviour
{
    public float speed = 2f; // ��������
    public float moveDistance = 25f; // ���������, �� ������� ����� ����� ��������� ������ � ����� 

    private Vector3 startPosition; // ��������� �������
    private Vector3 targetPosition; // ������� �������
    private Vector3 scale;

    //���� �� 2� �������
    //private int hitCount = 0; // ������� ������������
    //public int maxHits = 2; // ���� ���-�� ������������ �� ������
    //���� �� ��
    private float health = 20f; // �������� �����

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;

    void Start()
    {
        scale = transform.localScale;
        startPosition = transform.position; // ���������� ��������� �������
        targetPosition = startPosition + Vector3.right * moveDistance; // ������������� ������� �������
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ������� ����a
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // �������� �� ��������� ������� �������
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == startPosition
                ? startPosition + Vector3.right * moveDistance
                : startPosition;
        }



        // �������� ������ � ����������� �� ����������� (�������� ��� ���� ����)
        if (targetPosition.x > transform.position.x)
        {
            // ������
            transform.localScale = scale; // ������� 1 �� ��� X
        }
        else
        {
            // �����
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z); // ������� -1 �� ��� X
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // �������� �� ������������ ����� � �������
        {
            collision.collider.GetComponent<PlayerMovement>().TakeDamage(transform.position, 1);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0f) Destroy(gameObject);
    }
}
/*

//���� �� ������
public void TakeDamage(float damage)
{
    health -= damage; // ��������� �� �����
    Debug.Log("Rat took damage: " + damage + ". Health remaining: " + health);

    // ���������, �� <=0
    if (health <= 0)
    {
        Die(); // �� ����� �� ����
    }
}


private void Die()
{
    Debug.Log("Rat died!");
    // ������ ��� ����������� �����...?
    Destroy(gameObject);
}
}
*/
