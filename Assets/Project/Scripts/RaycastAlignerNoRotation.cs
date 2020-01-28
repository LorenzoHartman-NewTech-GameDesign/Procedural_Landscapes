//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RaycastAlignerNoRotation : MonoBehaviour
//{

//    public float raycastDistance = 100f;
//    public float overlapTestBoxSize = 1f;


//    // Start is called before the first frame update
//    void Start()
//    {
//        //SpawnObject();
//    }

//    void SpawnObject(GameObject[]objects, bool rotated, LayerMask spawnedObjectLayer)
//    {
//        RaycastHit hit;



//        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
//        {

//            Quaternion spawnRotation; 


//            if (rotated == true)
//            {
//                 spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
//            }
//            else
//            {
//                 spawnRotation = Quaternion.identity; 
//            }


            

//            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
//            Collider[] collidersInsideOverlapBox = new Collider[1];
//            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

//            Debug.Log("number of colliders found " + numberOfCollidersFound);

//            if (numberOfCollidersFound == 0)
//            {
//                Debug.Log("spawned object");
//                int randomIndex = Random.Range(0, objects.Length);
//                GameObject clone = Instantiate(objects[randomIndex], hit.point, spawnRotation);


//            }
//            else
//            {
//                Debug.Log("name of collider 0 found " + collidersInsideOverlapBox[0].name);
//            }
//        }
//    }
                                                                          
//    //void SpawnObject(Vector3 positionToSpawn, Quaternion rotationToSpawn, /*Uses the objects that have been provided in the Spawnobject list (rocks / trees) */ GameObject[]objects)
//    //{
//    //    int randomIndex = Random.Range(0, objects.Length);
//    //    GameObject clone = Instantiate(objects[randomIndex], positionToSpawn, rotationToSpawn);
       


//    //}

    
 
    


//}
