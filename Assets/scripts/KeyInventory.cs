using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    // Количество ключей у игрока
    public int keys = 0;

    // Метод для добавления ключа
    public void AddKey()
    {
        keys++;
        Debug.Log("Ключ добавлен. Всего ключей: " + keys);
    }


}
