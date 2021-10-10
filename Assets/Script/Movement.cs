using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Gerakan kanan kiri
    private Rigidbody2D rb;
    public float kecepatan;
    public Vector2 gerakan;

    // Klik
    private float speed = 10;
    private Vector3 targetPosition;
    private bool isMoving = false;


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

        // Gerakan Mouse dan Klik
        if (Input.GetMouseButton(0))
        {
            SetTargerPosiotion();
        }
        if (isMoving)
        {
            Move();
        }
    }

    // Gerakan Mouse dan Klik
    void SetTargerPosiotion()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    // Gerakan Mouse dan Klik
    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
        }
    }

    // Setelan gerakan kanan dan Kiri
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + gerakan * kecepatan * Time.fixedDeltaTime);
    }

    // Centang isTrigger box yang Tag kotak
    // Jika di sentuh akan hilang
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kotak"))
        {
            Destroy(other.gameObject);
        }
    }
}

