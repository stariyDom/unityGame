using UnityEngine;

public class Boss_fly : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public int damage = 10; // ����, ������� ������� ����
    public float attackCooldown = 1.5f; // ����� ����� ������� � ��������
    private float lastAttackTime = 0f; // ����� ��������� �����

    PlayerMovement movPlayer;
    Transform player;
    Rigidbody2D rb;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        movPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        // ���������, ��������� �� ����� � �������� ��������� �����
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // ���������, ���������� �� ������� ������ � ��������� �����
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time; // ��������� ����� ��������� �����
                movPlayer.TakeDamage(rb.position, 1);
                //AttackPlayer(); // ����� ������ �����
            }
        }
    }

    // ����� ��� ����� ������
    private void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>(); // �������� ��������� �������� ������
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // ������� ���� ������
            Debug.Log("Boss attacked the player for " + damage + " damage.");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // �������� �� ������������ ����� � �������
        {
            collision.collider.GetComponent<PlayerMovement>().TakeDamage(rb.position, 1);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
