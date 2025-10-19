using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika peluru mengenai musuh
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Hancurkan musuh
            Destroy(gameObject);       // Hancurkan peluru
        }
        // Jika peluru menyentuh Player atau Turn, abaikan
        else if (other.CompareTag("Player") || other.CompareTag("turn"))
        {
            // Tidak melakukan apa-apa
        }
        // Jika terkena objek lain (bukan Player, bukan Turn, bukan Enemy)
        else
        {
            Destroy(gameObject); // Hancurkan peluru
        }
    }
}

