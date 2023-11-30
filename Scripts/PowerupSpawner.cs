using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] collectibles;

    private GameObject[] roads;
    private string surfaceTag = "Spawn Zone";
    private List<GameObject> spawnedRoads;
    public int collectibleCount = 0;
    [SerializeField] private int maxCollectibles = 8;

    void Start()
    {
        roads = GameObject.FindGameObjectsWithTag(surfaceTag);
        spawnedRoads = new List<GameObject>();
        if (roads.Length == 0)
        {
            Debug.LogError("No surfaces with tag road found");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (collectibleCount < maxCollectibles)
        {

            var randomIndex = Random.Range(0, roads.Length);
            var randomCollectibleIndex = Random.Range(0, collectibles.Length);

            GameObject randomSurface = roads[randomIndex];
            if (!spawnedRoads.Contains(randomSurface))
            {


                GameObject collectible = collectibles[randomCollectibleIndex];

                Vector3 collectiblePosition = GetRandomPositionOnSurface(randomSurface);



                Instantiate(collectible, collectiblePosition, Quaternion.identity);

                collectibleCount++;
                spawnedRoads.Add(randomSurface);
            }
        }





    }
    Vector3 GetRandomPositionOnSurface(GameObject surface)
    {

        Vector3 surfacePosition = surface.transform.position;

        float offsetX = Random.Range(-0.5f, 1f);
        float offsetY = Random.Range(0f, 1f);
        float offsetZ = Random.Range(2f, 3f);

        Vector3 randomOffset = new Vector3(0, 1.2f, -2f);


        return surfacePosition + randomOffset;


    }
}
