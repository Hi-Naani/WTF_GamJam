using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D frontRb;
    [SerializeField] Rigidbody2D backRb;
    [SerializeField] Rigidbody2D carRb;
    [SerializeField] float speed = 150f;
    [SerializeField] float rotSpeed = 300f;
    float moveInput;
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        frontRb.AddTorque(-moveInput * speed * Time.deltaTime);
        backRb.AddTorque(-moveInput * speed * Time.deltaTime);
        carRb.AddTorque(moveInput * rotSpeed * Time.deltaTime);
    }
}
