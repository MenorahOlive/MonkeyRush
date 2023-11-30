using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCar : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; // The object prefab to spawn
    public string spawnSurfaceTag = "Road"; // Tag of the objects where the new objects can spawn
    GameObject[] spawnSurfaces;
    const int spawnCount = 20;

    void Start()
    {
        spawnSurfaces = GameObject.FindGameObjectsWithTag(spawnSurfaceTag);
        // Spawn the object after a random interval
        StartCoroutine("SpawnObject");
    }

    private IEnumerator SpawnObject()
    {
        // Find all objects with the specified tag
        if (spawnSurfaces.Length == 0)
        {
            Debug.LogError("No objects with tag '" + spawnSurfaceTag + "' found.");
            yield return null;
        }

        foreach(var surface in spawnSurfaces)
        {
            for(int i =0; i < spawnCount; i++)
            {
                GameObject spawnedObject = Instantiate(objectToSpawn, surface.transform);
                Transform spawnedTransform = spawnedObject.transform;

                spawnedTransform.localPosition = new Vector3(Random.Range(0f, 06f), Random.Range(0f, 5f), 0.3f);
                spawnedTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        yield return null;

       
    }

    // Update is called once per frame
    void Update()
    {
        // You can add additional logic here if needed
    }
}
