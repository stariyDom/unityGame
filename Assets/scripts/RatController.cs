using UnityEngine;

public class RatController : MonoBehaviour
{
    public float speed = 2f; // Скорость
    public float moveDistance = 25f; // Дистанция, на которую крыса будет двигаться вправо и влево 

    private Vector3 startPosition; // Начальная позиция
    private Vector3 targetPosition; // Целевая позиция

    //если от 2х касаний
    //private int hitCount = 0; // Счетчик столкновений
    //public int maxHits = 2; // Макс кол-во столкновений до смерти
    //если от хр
    private float health = 20f; // Здоровье крысы

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        startPosition = transform.position; // Запоминаем начальную позицию
        targetPosition = startPosition + Vector3.right * moveDistance; // Устанавливаем целевую позицию
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        // Двигаем крысa
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Проверка на достжение целевой позиции
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Меняем целевую позицию
            targetPosition = targetPosition == startPosition ? startPosition + Vector3.right * moveDistance : startPosition;
        }

        // Изменяем спрайт в зависимости от направления (зеркалим его если надо)
        if (targetPosition.x > transform.position.x)
        {
            // Вправо
            transform.localScale = new Vector3(1, 1, 1); // Масштаб 1 по оси X
        }
        else
        {
            // Влево
            transform.localScale = new Vector3(-1, 1, 1); // Масштаб -1 по оси X
        }
    }
    /*/
    //Увеличение кол столкновений с игроком и следуюший от этого урон
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Проверка на столкновение крыса с игроком
        {
            hitCount++; // Увеличиваем счетчик
            Debug.Log("Rat hit! Count: " + hitCount);

            // Проверка на достижение макс кол-ва столкновений
            if (hitCount >= maxHits)
            {
                Die(); 
            }
            else
            {
                GetDamage(10f); // Получаем 10 урона, если еще не достигли максимума
            }
        }
    }
    private void GetDamage(float damage)
    {
        // Логика получения урона...?
        Debug.Log("Rat took damage: " + damage);
    }
    /*/

    //урон от оружия
    public void TakeDamage(float damage)
    {
        health -= damage; // Уменьшаем хр крысы
        Debug.Log("Rat took damage: " + damage + ". Health remaining: " + health);

        // Проверяем, хр <=0
        if (health <= 0)
        {
            Die(); // хр упало до нуля
        }
    }


    private void Die()
    {
        Debug.Log("Rat died!");
        // Логика для уничтожения крысы...?
        Destroy(gameObject); 
    }
}
