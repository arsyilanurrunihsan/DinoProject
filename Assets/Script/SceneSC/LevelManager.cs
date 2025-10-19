using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject victoryPanel; // Panel kemenangan
    public int targetCoins; // Jumlah koin yang harus dikumpulkan untuk menang

    void Start()
    {
        // Pastikan panel victory tidak terlihat saat game dimulai
        victoryPanel.SetActive(false);
    }

    void Update()
    {
        // Cek apakah jumlah koin yang dikumpulkan sudah mencapai target
        if (CollectableManager.Instance != null && CollectableManager.Instance.GetCoinCount() >= targetCoins)
        {
            ShowVictoryPanel();
        }
    }

    void ShowVictoryPanel()
    {
        victoryPanel.SetActive(true); // Tampilkan panel kemenangan
        Time.timeScale = 0; // Hentikan waktu
    }
}
