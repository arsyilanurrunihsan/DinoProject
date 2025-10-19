using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    // Membuat instance statis agar bisa diakses dari skrip lain tanpa perlu referensi manual
    public static CollectableManager Instance; 
    private int coinCount; // Variabel untuk menyimpan jumlah koin yang dikumpulkan pemain
    public TextMeshProUGUI coinText; // Referensi ke UI Text yang akan menampilkan jumlah koin
    public AudioClip coinSFX; // Audio saat coin dikumpulkan
    private AudioSource audioSource; // Komponen audio source

    // FUngsi untuk mendapatkan data Coin
    public int GetCoinCount()
    {
        return coinCount;
    }


    // Fungsi Awake dipanggil pertama kali sebelum Start
    private void Awake()
    {
        // Jika Instance masih null, atur Instance ke objek ini
        if (Instance == null)
        {
            Instance = this;
        }
         // Ambil AudioSource dari GameObject ini
        audioSource = GetComponent<AudioSource>();
    }
    // Fungsi Start dipanggil saat game mulai
    private void Start()
    {
        // Memastikan UI koin diperbarui dengan nilai awal
        UpdateCoinUI();
    }
// Fungsi untuk menambahkan koin dan memperbarui UI
    public void AddCoin(int amount)
    {
        coinCount += amount; // Menambahkan jumlah koin
        UpdateCoinUI(); // Memperbarui tampilan UI
         // Mainkan SFX jika tersedia
        if (coinSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(coinSFX);
        }
    }
    // Fungsi untuk memperbarui teks pada UI koin
    private void UpdateCoinUI()
    {
        coinText.text = coinCount.ToString(); // Menampilkan jumlah koin saat ini
    }
}
