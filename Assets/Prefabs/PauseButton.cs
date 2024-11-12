using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{   
    public GameObject panel;

    public void OnApplicationPause(bool pause) {
        panel.SetActive(pause);
        Time.timeScale = pause ? 1.0f : 0.0f;
    }

    public void ExitToMenu() {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("CurrentSceneIndex", currenSceneIndex);
        SceneManager.LoadScene(0);
    }
}
