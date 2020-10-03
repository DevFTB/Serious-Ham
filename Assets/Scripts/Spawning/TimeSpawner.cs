using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawner : Spawner
{
    public int SpawningPeriod;
    private float timeSinceLastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastSpawn = SpawningPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= SpawningPeriod)
        {
            Spawn();
            timeSinceLastSpawn = 0;
        }
    }
}
