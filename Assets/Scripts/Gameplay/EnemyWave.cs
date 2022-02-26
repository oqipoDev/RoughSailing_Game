using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public List<GameObject> EnemyTypes = new List<GameObject>();
    public float Duration = 30f;
    [Tooltip("If true, the delay will be counted WITH the last one, otherwise, it'll be counted AFTER.")]
    public bool UseWithPrevious = false;
    public int SpawnAtStart = 5;
    public int SpawnInterval = 3;
    private float TimeSinceSpawned;
    public bool Ongoing = false;

    void Awake()
    {
        Ongoing = false;
    }

    void Update()
    {
        if (Ongoing)
            TimeSinceSpawned += Time.deltaTime;
    }

    public void ResetSinceSpawned()
    {
        TimeSinceSpawned = 0;
    }

    // Update is called once per frame
    public float GetSinceSpawned()
    {
        return TimeSinceSpawned;
    }
}
