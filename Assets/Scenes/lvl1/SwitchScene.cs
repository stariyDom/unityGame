using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int requiredKeys = 0;
    public string sceneName;
    public KeyInventory playerInventory;
    public GameObject insufficientKeysMessage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Триггер сработал!");

        if (other.CompareTag("Player"))
        {
            Debug.Log(playerInventory.keys);
            
            if (playerInventory.keys >= requiredKeys)
            {
                int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("CurrentSceneIndex", currenSceneIndex + 1);
                // Загружаем следующий уровень
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("Недостаточно ключей!");
                ShowInsufficientKeysMessage();
            }
        }

    }
    private void ShowInsufficientKeysMessage()
    {
        // Включаем UI-элемент
        insufficientKeysMessage.SetActive(true);

        // Запускаем корутину, чтобы скрыть сообщение через определённое время
        StartCoroutine(HideMessageAfterDelay());
    }

    // Корутин для скрытия сообщения через задержку
    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        // Отключаем UI-элемент
        insufficientKeysMessage.SetActive(false);
    }


}
