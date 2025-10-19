using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Memuat scene berdasarkan nama
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Keluar dari aplikasi
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!");
    }
}

