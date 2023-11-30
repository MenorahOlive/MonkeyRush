using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    [SerializeField]private float torque = 200;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            for(int i=0; i<wheelColliders.Length; i++)
            {
                wheelColliders[i].motorTorque = torque;
            }
        }
        else
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                wheelColliders[i].motorTorque = 0;
            }
        }
    }
}
