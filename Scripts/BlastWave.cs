using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    // Start is called before the first frame update

    private LineRenderer lineRenderer;


    [SerializeField] private int pointsCount;
    [SerializeField] private float maxRadius;
    [SerializeField] private float speed;
    private float startWidth;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;
    }

    private IEnumerator Blast()
    {
        float currentRadius = 0f;
        while (currentRadius < maxRadius)
        {
            currentRadius += Time.deltaTime * speed;
            Draw(currentRadius);
            yield return null;
        }
    }

    private void Draw(float currentRadius)
    {
        float angleBetweenPoints = 360f / pointsCount;
        for (int i = 0; i <= pointsCount; i++)
        {
            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }
        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Blast());
        }
    }
}
