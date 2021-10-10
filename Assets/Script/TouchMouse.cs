using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMouse : MonoBehaviour
{
    private float speed = 4;
    private Vector3 targetPosition;
    private bool isMoving = false;

    // Pembaruan akan dipanggil satu-persatu
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SetTargerPosiotion();
        }
        if(isMoving)
        {
            Move();
        }
    }

    // Menyetel Satu Target Posisi
    void SetTargerPosiotion()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;

        isMoving = true;
    }

    // Menggerakan Bola Dengan Mouse
    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(transform.position == targetPosition)
        {
            isMoving = false;
        }
    }
}
