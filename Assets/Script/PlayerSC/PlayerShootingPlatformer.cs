using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingPlatformer : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab peluru yang akan ditembakkan
    public Transform firePoint; // Titik keluarnya peluru
    public float bulletSpeed; // Kecepatan peluru
    public float fireRate; // Waktu jeda antar tembakan
     public AudioClip shootSFX; // Audio SFX untuk tembakan
    private AudioSource audioSource; // Komponen audio source
    public float bulletLifetime; // Waktu sebelum peluru dihancurkan
    private float nextFireTime; // Menyimpan waktu saat bisa menembak lagi
    void Start()
    {
        // Ambil komponen AudioSource
        audioSource = GetComponent<AudioSource>();
    }
   void Update()
    {
        // Mengecek jika tombol "Enter" ditekan dan waktu saat ini sudah melewati nextFireTime
        if (Input.GetKeyDown(KeyCode.Return) && Time.time >= nextFireTime)
        {
            Shoot(); // Memanggil fungsi menembak
            nextFireTime = Time.time + fireRate; // Mengatur waktu untuk tembakan berikutnya
        }
    }
void Shoot()
    {
        // Membuat peluru baru pada posisi firePoint dengan rotasi firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Mengakses komponen Rigidbody2D dari peluru yang baru dibuat
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        // Menentukan arah peluru berdasarkan rotasi firePoint
        float direction = firePoint.right.x > 0 ? 1f : -1f;
        
        // Memberikan kecepatan ke peluru berdasarkan arah firePoint
        rb.linearVelocity = new Vector2(direction * bulletSpeed, 0);
        
        // Menghancurkan peluru setelah waktu tertentu
        Destroy(bullet, bulletLifetime);
        // Mainkan SFX Shot Fire
        if (shootSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSFX);
        }
    }
}
