using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float jump;
    public Transform firePoint; // Referensi ke FirePoint
    float moveVelocity;
    bool grounded = true;

    // Reference animator & sprite renderer
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    
void Start()
{
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
}

    void Update()
    {
         // --- JUMP ---
    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && grounded)
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, jump);
        anim.SetBool("isJumping", true); // Set ke true saat loncat
    }
    // --- MOVE ---
    {
    sr.flipX = false;
    firePoint.localPosition = new Vector3(1.7f, 0.6f, 0); // Posisi firePoint
    firePoint.localRotation = Quaternion.Euler(0, 0, 0); // Rotasi firePoint
    }
    if(moveVelocity < 0)
    {
    sr.flipX = true;
    firePoint.localPosition = new Vector3(-1.7f, 0.6f, 0); // Posisi firePoint
    firePoint.localRotation = Quaternion.Euler(0, 180, 0); // Rotasi firePoint
    }
    moveVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            sr.flipX = true; // Menghadap kiri
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            sr.flipX = false; // Menghadap kanan
        }

       // Apply movement
    GetComponent<Rigidbody2D>().linearVelocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().linearVelocity.y);

    // Animasi jalan
    anim.SetBool("Walk", moveVelocity != 0);
    }

    // --- CEK GROUND ---
void OnCollisionEnter2D(Collision2D other)
{
    grounded = true;
    anim.SetBool("isJumping", false); // Reset saat nyentuh tanah
}

void OnCollisionExit2D(Collision2D other)
{
    grounded = false;
 }
}

