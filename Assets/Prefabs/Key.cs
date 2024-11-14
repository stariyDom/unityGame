using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyInventory playerInventory;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerInventory.AddKey();

            Debug.Log("Ключ поднят!");
            Destroy(gameObject);
        }
    }


}
