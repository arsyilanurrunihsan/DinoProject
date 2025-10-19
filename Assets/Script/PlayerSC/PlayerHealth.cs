using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth; // Variabel Health maksimal player
    private int currentHealth; // Variabel Health saat ini
    public Image healthBarFill; // Referensi ke Image yang digunakan sebagai Health Bar Fill
    public GameObject panelLose; // Referensi ke Gameobject Panel Lose
    public AudioClip hitSFX; // Audio SFX untuk hit ketika terkena Enemy
    public AudioClip loseSFX; // Audio SFX untuk hit ketika Lose
    private AudioSource audioSource; // Komponen audio source


    private void Start()
    {
        // Set health saat mulai game ke health maksimal
        currentHealth = maxHealth;
        UpdateHealthUI(); // Perbarui UI Health Bar
        // Ambil AudioSource dari GameObject ini
        audioSource = GetComponent<AudioSource>();

    }

    // Method untuk menerima damage dari enemy
    public void TakeDamage(int damage)
    {
        // Kurangi health dengan damage yang diterima
        currentHealth -= damage;
        // Mainkan SFX Hit
        if (hitSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSFX);
        }
        // Pastikan health tidak kurang dari 0 atau lebih dari max
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI(); // Perbarui tampilan UI Health Bar

        // Jika health habis, panggil fungsi Die()
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    // Method untuk memperbarui tampilan Health Bar
    void UpdateHealthUI()
    {
        if (healthBarFill != null) // Pastikan healthBarFill telah diassign
        {
            // Hitung persentase HP yang tersisa
            float fillAmount = (float)currentHealth / maxHealth;

            // Ubah skala Health Bar berdasarkan HP
            healthBarFill.transform.localScale = new Vector3(fillAmount, 1, 1);
        }
    }

    // Fungsi Die sebagai Coroutine
    private IEnumerator Die()
    {
        // Mainkan SFX Lose
        if (loseSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(loseSFX);
        }
        Debug.Log("Player Mati!"); // Debug log untuk melihat jika player mati

        panelLose.SetActive(true); // Tampilkan Panel Lose

        Time.timeScale = 0; // Hentikan Game (Pause)

        yield return new WaitForSecondsRealtime(5f); // Tunggu 5 detik waktu nyata (karena timescale = 0)

        gameObject.SetActive(false); // Nonaktifkan player
    }

    // Method ketika Player masuk ke Area Lose
    public void TriggerDeath()
    {
        StartCoroutine(Die());
    }
}
