using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableControl : MonoBehaviour
{
    DriveCar DriveCar;
    private void Awake()
    {
        DriveCar = GetComponent<DriveCar>();
        DriveCar.enabled = false;
    }
    void Start()
    {
        Invoke("EnableCarControl", 9.5f);
    }
    void EnableCarControl()
    {
        DriveCar.enabled = true;
    }
}
