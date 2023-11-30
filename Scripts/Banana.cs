using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject mass;
    

    private Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //body.centerOfMass = mass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
