using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarPowerup : MonoBehaviour
{

    [SerializeField] private NavMeshAgent enemy;
    private Animator animator;
    [SerializeField] private GameObject forceField;

    [SerializeField] private GameManager gameManager;
    //PowerUp attributes

    public float boostForce = 40000; 
    public float boostDuration = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpeedBoost()
    {
        animator.SetBool("isSpeedBoost", true);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.AddForce(transform.forward * boostForce, ForceMode.Impulse);
        }

    }


    public void ForceField()
    {
        animator.SetBool("hasForceField", true);
       
        forceField.SetActive(true);
        gameManager.TogglePauseTime();
        Invoke("StopForceField", 8);


        Debug.LogWarning("Force Field Engaged");
    }

    private void StopForceField()
    {
        forceField.SetActive(false);
        gameManager.TogglePauseTime();
    }

    public void Invisisbity()
    {
        animator.SetBool("isInvisible", true);
        Debug.LogWarning("Invisibility Engaged");
    }
}
