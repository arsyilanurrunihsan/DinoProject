using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Mengambil komponen SpriteRenderer dari game object ini
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Gerakkan ke kanan atau kiri tergantung MoveRight
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            spriteRenderer.flipX = false; // Menghadap ke kanan
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            spriteRenderer.flipX = true; // Menghadap ke kiri
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            MoveRight = !MoveRight; // Membalik arah
        }
    }
}
