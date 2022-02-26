using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    static private GameObject floor;
    [SerializeField]
    static private GameObject player;
    [SerializeField]
    static private GameObject spawner;
    void Awake()
    {
        if(floor = GameObject.Find("Floor"))
        {
            player = floor.transform.GetChild(0).gameObject;
            spawner = floor.transform.GetChild(1).gameObject;
        }
        
    }

    public static GameObject GetPlayerObject()
    {
        return player;
    }
    public static GameObject GetSpawnerObject()
    {
        return spawner;
    }
}
