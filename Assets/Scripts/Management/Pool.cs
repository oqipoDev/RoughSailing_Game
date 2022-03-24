using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject ObjectToPool;
    private List<GameObject> PoolOfObjects = new List<GameObject>();

    public List<GameObject> GetObjectsInPool()
    {
        return PoolOfObjects;
    }

    public GameObject GetPooledObject()
    {
        //Find an inactive instance
        foreach (GameObject pooldObj in PoolOfObjects)
        {
            if (!pooldObj.activeInHierarchy)
                return pooldObj;
        }
        //No success? Create another!
        GameObject newPooldObj = Instantiate(ObjectToPool);
        //Add it for later use
        PoolOfObjects.Add(newPooldObj);

        newPooldObj.SetActive(false);
        
        return newPooldObj;
    }

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            //Create instance
            GameObject newPooldObj = Instantiate(ObjectToPool);
            //Add it for later use
            PoolOfObjects.Add(newPooldObj);

            newPooldObj.SetActive(false);
        }
    }
}
