using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static List<Pool> AvailablePools = new List<Pool>();

    public static GameObject SpawnFrom(GameObject obj, Transform spawner)
    {
        return SpawnAt(obj, spawner.position, spawner.rotation, spawner);
    }

    public static GameObject SpawnFrom(GameObject obj, Transform spawner, bool parent)
    {
        return SpawnAt(obj, spawner.position, spawner.rotation, null);
    }

    public static GameObject SpawnAt(GameObject obj, Vector3 pos, Quaternion rot, Transform parent)
    {
        //Search a compatible pool
        for (int i = 0; i < AvailablePools.Count; i++)
        {
            Pool pool = AvailablePools[i];
            //Found it?
            if (pool.ObjectToPool == obj)
            {
                return ActivateObjectInPool(pool, pos, rot, parent);
            }
        }

        //No success? Create another!

        //Create an empty one!
        Pool newPool = new GameObject().AddComponent<Pool>();

        newPool.ObjectToPool = obj;

        //Add to the list
        AvailablePools.Add(newPool);

        return ActivateObjectInPool(newPool, pos, rot, parent);
    }

    private static GameObject ActivateObjectInPool(Pool pool, Vector3 pos, Quaternion rot, Transform parent)
    {
        GameObject newObj = pool.GetPooledObject();
        //Set parent
        newObj.transform.parent = parent;
        //Set position and rotation
        newObj.transform.position = pos;
        newObj.transform.rotation = rot;
        
        newObj.SetActive(true);

        return newObj;
    }
}
