using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D frb;
    [SerializeField] Rigidbody2D brb;
    [SerializeField] Rigidbody2D carrb;
    [SerializeField] float speed = 150f;
    [SerializeField] float rotSpeed = 300f;
    float moveInput;
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        frb.AddTorque(-moveInput * speed * Time.deltaTime);
        brb.AddTorque(-moveInput * speed * Time.deltaTime);
        carrb.AddTorque(moveInput * rotSpeed * Time.deltaTime);
    }
}
