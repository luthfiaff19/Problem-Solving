using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
     // Gerakan kanan kiri
    private Rigidbody2D rb;
    public float kecepatan;
    public Vector2 gerakan;

    // Akan dipanggil sebelum pembaruan bingkai pertama dimulai
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Pembaruan akan dipanggil satu-persatu
    void Update()
    {
        // gerakan kanan kiri
        gerakan.x = Input.GetAxisRaw("Horizontal");
        gerakan.y = Input.GetAxisRaw("Vertical");

    }

    // Setelan gerakan kanan dan Kiri
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + gerakan * kecepatan * Time.fixedDeltaTime);
    }
}

