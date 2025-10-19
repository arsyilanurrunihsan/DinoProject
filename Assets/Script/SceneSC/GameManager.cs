using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause; // Variabel untuk ambil Gameobject Panel Pause

    // Start is called before the first frame update
    void Start()
    {
        panelPause.SetActive(false); // Menon-aktifkan Panel Pause
        Time.timeScale = 1f; // Pastikan game berjalan normal di awal
    }

    public void PauseButton()
    {
        panelPause.SetActive(true); // Meng-aktifkan Panel Pause
        Time.timeScale = 0f; // Menghentikan waktu dalam game
    }

    public void ResumeButton()
    {
        panelPause.SetActive(false); // Menon-aktifkan Panel Pause
        Time.timeScale = 1f; // Melanjutkan game
    }
}
