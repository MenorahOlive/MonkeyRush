using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    private AudioSource detectedSound;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detectedSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.position);
        agent.destination = player.position;
        float pan = Mathf.Clamp((player.position.x - transform.position.x) / maxDistance, -1f, 1f);
        detectedSound.panStereo = pan;
        if (agent.remainingDistance != 0 && agent.remainingDistance < maxDistance)
        {
            float volumeFactor = Mathf.Clamp01(1f - agent.remainingDistance / maxDistance);

            detectedSound.volume = volumeFactor;
            gameManager.setDetected(true);

            if (!detectedSound.isPlaying)
            {
                detectedSound.volume = volumeFactor;
                detectedSound.PlayDelayed(1);

            }

        }

        else
        {
            gameManager.setDetected(false);
            detectedSound.volume = 0.6f;
            animator.SetBool("isDetected", false);
            if (detectedSound.isPlaying)
            {

                detectedSound.Stop();
            }
        }

    }
}
