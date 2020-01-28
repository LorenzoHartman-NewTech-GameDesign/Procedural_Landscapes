using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner : MonoBehaviour
{
    //public GameObject itemToSpread;
    public int numItemsToSpawn = 10;

    public GameObject[] objects;
    public bool rotated;
    public LayerMask spawnedObjectLayer; 

    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItem();
        }
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        //GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
        SpawnObject(objects, rotated, spawnedObjectLayer, randPosition);
    }

    void SpawnObject(GameObject[] objects, bool rotated, LayerMask spawnedObjectLayer, Vector3 position)
    {
        RaycastHit hit;



        if (Physics.Raycast(position, Vector3.down, out hit, raycastDistance))
        {

            Quaternion spawnRotation;


            if (rotated == true)
            {
                spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            }
            else
            {
                spawnRotation = Quaternion.identity;
            }




            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

            Debug.Log("number of colliders found " + numberOfCollidersFound);

            if (numberOfCollidersFound == 0)
            {
                Debug.Log("spawned object");
                int randomIndex = Random.Range(0, objects.Length);
                GameObject clone = Instantiate(objects[randomIndex], hit.point, spawnRotation);


            }
            else
            {
                Debug.Log("name of collider 0 found " + collidersInsideOverlapBox[0].name);
            }
        }
    }


}