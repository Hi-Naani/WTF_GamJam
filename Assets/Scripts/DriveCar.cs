using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    public PlayerSpawner playerSpawner;
    [SerializeField] Rigidbody2D frontRb;
    [SerializeField] Rigidbody2D backRb;
    [SerializeField] Rigidbody2D carRb;
    [SerializeField] float speed = 150f;
    [SerializeField] float rotSpeed = 300f;
    [SerializeField] float rotationSpeed = 300f;
    float jumpSpeed = 70f;
    [SerializeField]bool isGrounded = false;
    float moveInput;
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if(isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        Rotate();
    }
    private void FixedUpdate()
    {
        frontRb.AddTorque(-moveInput * speed * Time.deltaTime);
        backRb.AddTorque(-moveInput * speed * Time.deltaTime);
        carRb.AddTorque(moveInput * rotSpeed * Time.deltaTime);
    }
    void Jump()
    {
        Vector2 force = new Vector2(0f, jumpSpeed);
        //carRb.velocity = Vector2.up * jumpSpeed;
        carRb.AddForce(force);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) // Ground Layer
        {
            isGrounded = true;
        }
        if(collision.gameObject.layer == 6) // CheckPoint Layer
        {
            UpdateRespawnPoint();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // Ground Layer
        {
            isGrounded = false;
        }
    }
    void Rotate()
    {
        if(!isGrounded)
        {
            if(Input.GetKey(KeyCode.Q)) 
            {
                //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                carRb.AddTorque(10 * rotationSpeed * Time.deltaTime);
                
            }
            else if (Input.GetKey(KeyCode.E))
            {
                carRb.AddTorque(-10 * rotationSpeed * Time.deltaTime);
            }
        }
    }
    private void UpdateRespawnPoint()
    {
        // Assuming you want to update where to the current position of the player
        if (playerSpawner != null)
        {
            playerSpawner.UpdateRespawnPoint(transform.position);
        }
    }
}