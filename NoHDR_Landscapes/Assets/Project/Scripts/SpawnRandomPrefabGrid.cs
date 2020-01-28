using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPrefabGrid : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridZ;
    public int gridY;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;
    public Vector3 positionRandomization; 




    // Start is called before the first frame update
    void Start()
    {
        SpawnGrid(); 
    }

    void SpawnGrid()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {

                for (int y = 0; y < gridY; y++)
                {
                    Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, y * gridSpacingOffset, z * gridSpacingOffset) + gridOrigin;
                    PickAndSpawn(RandomizedPosition(spawnPosition), Quaternion.identity);
                }

            }
        }
    }

    Vector3 RandomizedPosition(Vector3 position)
    {
        Vector3 randomizedPosition = new Vector3(Random.Range(-positionRandomization.x, positionRandomization.x), Random.Range(-positionRandomization.y, positionRandomization.y), Random.Range(-positionRandomization.z, positionRandomization.z)) + position;
        return randomizedPosition; 
    }


    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
