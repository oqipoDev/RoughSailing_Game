using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    public List<EnemyWave> EnemyWaves;
    public Spawner SpawnTo;
    
    private bool IsSpawning = false;
    private List<EnemyWave> CurrentEnemyWaves = new List<EnemyWave>();
    private int NextWaveNum = 0;
    private float CurrentDelay, CurrentWaveTime = 0;

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player") && !IsSpawning)
            StartWaves();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!IsSpawning)
            return;
        
        CurrentWaveTime += Time.deltaTime;
        
        //Check for finished waves, and spawn
        for (int i = 0; i < CurrentEnemyWaves.Count; i++)
        {
            EnemyWave wave = CurrentEnemyWaves[i];
            //Remove if finished
            if (wave.Duration < CurrentWaveTime)
            {
                CurrentEnemyWaves.Remove(wave);
                wave.Ongoing = false;
            }
            //Spawn if ongoing
            else if(wave.SpawnInterval <= wave.GetSinceSpawned())
            {
                //Choose a random enemy
                int RandomEnemy = Random.Range(0, wave.EnemyTypes.Count);

                SpawnTo.Spawn(wave.EnemyTypes[RandomEnemy]);

                wave.ResetSinceSpawned();
            }
        }

        //Move on if waves have finished
        if (CurrentEnemyWaves.Count == 0)
        {
            SetWaves();
        }
    }

    private void StartWaves()
    {
        IsSpawning = true;
        //The first one always gets added
        //CurrentEnemyWaves.Add(EnemyWaves[0]);
        SetWaves();
        //InvokeRepeating(nameof(SpawnEnemies), 0, 1);
    }

    private void SetWaves()
    {
        //Starter wave
        //CurrentEnemyWaves.Add(EnemyWaves[NextWaveNum]);
        //Follower waves

        if (NextWaveNum == EnemyWaves.Count)
        {
            StopWaves();
            return;
        }

        for (int i = NextWaveNum; i <= EnemyWaves.Count; i++)
        {
            //If we reach the end
            if (i == EnemyWaves.Count)
            {
                NextWaveNum = i;
                return;
            }

            EnemyWave wave = EnemyWaves[i];
            //Don't add if next wave is starter
            if (!wave.UseWithPrevious && i > 0)
            {
                NextWaveNum = i;
                CurrentWaveTime = 0;
                return;
            }

            CurrentEnemyWaves.Add(EnemyWaves[i]);
            wave.Ongoing = true;
            //Spawn start quantity
            for (int j = 0; j < wave.SpawnAtStart; j++)
            {
                int RandomEnemy = Random.Range(0, wave.EnemyTypes.Count);

                SpawnTo.Spawn(wave.EnemyTypes[RandomEnemy]);
            }
        }
    }

    private void StopWaves()
    {
        IsSpawning = false;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        
    }
}
