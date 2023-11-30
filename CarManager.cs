using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject speedometerNeedle;
    [SerializeField] private CarController carController;
    private float startPosition=220f, endPosition=-41f;
    private float desiredPosition;
    private float vehicleSpeed;
    void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        vehicleSpeed = carController.speed;

        UpdateNeedle();
    }
    private void UpdateNeedle()
    {
        desiredPosition = startPosition - endPosition;
        float temp = vehicleSpeed / 180;
        float rotationAngle = startPosition - temp * desiredPosition;
        speedometerNeedle.transform.eulerAngles = new Vector3(0, 0, rotationAngle);
    }
}
