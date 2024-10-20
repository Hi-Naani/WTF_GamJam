using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class COM : MonoBehaviour
{
    public Vector3 offeset;
    public bool Awake;//checking for awake in rigidbody
    protected Rigidbody2D r; //var for the rigidbody.

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        r.centerOfMass = offeset; // moveing the COM center of mass 
        r.WakeUp(); //prevents sleeping  
        Awake = !r.IsSleeping(); // checkign
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * offeset, 1f);
    }

}
