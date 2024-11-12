using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void ExitGame() {
        Debug.Log("EXITED");
        Application.Quit();
    }

    public void ContinueGame() {
        if (PlayerPrefs.HasKey("CurrentSceneIndex")) {
            int lvlIndex = PlayerPrefs.GetInt("CurrentSceneIndex");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + lvlIndex);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
