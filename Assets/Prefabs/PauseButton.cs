using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{   
    public GameObject panel;

    public void OnApplicationPause(bool pause) {
        panel.SetActive(pause);
        Time.timeScale = pause ? 0f : 1f;
    }

    public void ExitToMenu() {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentSceneIndex", currenSceneIndex);
        SceneManager.LoadScene(0);
    }
}
