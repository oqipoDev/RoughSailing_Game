using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Transform> SpawnPositions;
    private static List<Pool> AvailablePools = new List<Pool>();

    public void Spawn(GameObject obj)
    {
        //Search a compatible pool
        for (int i = 0; i < AvailablePools.Count; i++)
        {
            Pool pool = AvailablePools[i];
            //Found it?
            if (pool.ObjectToPool == obj)
            {
                ActivateObjectInPool(pool);
                return;
            }
        }

        //No success? Create another!

        //Create an empty one!
        Pool newPool = new GameObject().AddComponent<Pool>();

        newPool.ObjectToPool = obj;

        //Add to the list
        AvailablePools.Add(newPool);

        ActivateObjectInPool(newPool);
    }

    private void ActivateObjectInPool(Pool pool)
    {
        int SpawnSpot = Random.Range(0, SpawnPositions.Count);

        GameObject newObj = pool.GetPooledObject();
        //Set parent
        newObj.transform.parent = transform.parent;
        //Set position and rotation
        newObj.transform.position = SpawnPositions[SpawnSpot].position;
        newObj.transform.localRotation = Quaternion.identity;
        
        newObj.SetActive(true);
    }
}
