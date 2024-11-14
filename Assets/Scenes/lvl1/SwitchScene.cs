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
        Debug.Log("������� ��������!");

        if (other.CompareTag("Player"))
        {
            Debug.Log(playerInventory.keys);
            
            if (playerInventory.keys >= requiredKeys)
            {
                int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
                PlayerPrefs.SetInt("CurrentSceneIndex", currenSceneIndex + 1);
                // ��������� ��������� �������
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("������������ ������!");
                ShowInsufficientKeysMessage();
            }
        }

    }
    private void ShowInsufficientKeysMessage()
    {
        // �������� UI-�������
        insufficientKeysMessage.SetActive(true);

        // ��������� ��������, ����� ������ ��������� ����� ����������� �����
        StartCoroutine(HideMessageAfterDelay());
    }

    // ������� ��� ������� ��������� ����� ��������
    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(10f);

        // ��������� UI-�������
        insufficientKeysMessage.SetActive(false);
    }


}
