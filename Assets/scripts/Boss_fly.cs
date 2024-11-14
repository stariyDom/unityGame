using UnityEngine;


//public class Boss_fly : StateMachineBehaviour
//{
//    public float speed = 2.5f;
//    public float attackRange = 3f;
//    public int damage = 10; // Урон, который наносит босс
//    Transform player;
//    Rigidbody2D rb;
//    Boss boss;

//    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
//    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        player = GameObject.FindGameObjectWithTag("Player").transform;
//        rb = animator.GetComponent<Rigidbody2D>();
//        boss = animator.GetComponent<Boss>();
//    }

//    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
//    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        boss.LookAtPlayer();

//        Vector2 target = new Vector2(player.position.x, rb.position.y);
//        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
//        rb.MovePosition(newPos);

//        // Проверяем, находится ли игрок в пределах дистанции атаки
//        if (Vector2.Distance(player.position, rb.position) <= attackRange)
//        {
//            animator.SetTrigger("Attack");
//            AttackPlayer(); // Вызов метода атаки
//        }
//    }

//    // Метод для атаки игрока
//    private void AttackPlayer()
//    {
//        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>(); // Получаем компонент здоровья игрока
//        if (playerHealth != null)
//        {
//            playerHealth.TakeDamage(damage); // Наносим урон игроку
//            Debug.Log("Boss attacked the player for " + damage + " damage.");
//        }
//    }

//    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
//    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//    {
//        animator.ResetTrigger("Attack");
//    }
//}

public class Boss_fly : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public int damage = 10; // Урон, который наносит босс
    public float attackCooldown = 1.5f; // Время между атаками в секундах
    private float lastAttackTime = 0f; // Время последней атаки

    Transform player;
    Rigidbody2D rb;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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

        // Проверяем, находится ли игрок в пределах дистанции атаки
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // Проверяем, достаточно ли времени прошло с последней атаки
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time; // Обновляем время последней атаки
                AttackPlayer(); // Вызов метода атаки
            }
        }
    }

    // Метод для атаки игрока
    private void AttackPlayer()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>(); // Получаем компонент здоровья игрока
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Наносим урон игроку
            Debug.Log("Boss attacked the player for " + damage + " damage.");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
