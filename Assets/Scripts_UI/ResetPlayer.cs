using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 swapnPos;
    public bool upsideDown;
    void Start()
    {
       swapnPos = player.transform.position;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if(upsideDown)
            {
                player.transform.rotation = Quaternion.identity;
                player.transform.position = swapnPos;
                upsideDown = false;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            swapnPos = collision.transform.position;
        }

        if(collision.gameObject.layer == 3)
        {
            upsideDown = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            upsideDown = false;
        }
    }
}
