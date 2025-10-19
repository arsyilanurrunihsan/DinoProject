using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Menentukan nilai dari koin ini, defaultnya adalah 1
    public int collectableValue; 

    // Metode ini akan dipanggil saat suatu Collider masuk ke dalam trigger milik koin
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah objek yang masuk memiliki tag "Player"
        if (other.CompareTag("Player")) // Pastikan Player memiliki tag "Player"
        {
            // Menambah jumlah koin di CoinManager sebanyak nilai koin ini
            CollectableManager.Instance.AddCoin(collectableValue);

            // Menghapus koin dari scene setelah diambil oleh player
            Destroy(transform.parent.gameObject);
        }
    }
}

