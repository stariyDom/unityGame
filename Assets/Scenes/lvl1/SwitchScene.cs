using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("CurrentSceneIndex", currenSceneIndex+1);
            LoadLevel();
        }
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }

}
