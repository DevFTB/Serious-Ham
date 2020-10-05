using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTimeSpawner : Spawner
{
    public int SpawningPeriod;
    private float timeSinceLastSpawn;
    public Transform Player;
    public float MinPlayerDistance;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeSinceLastSpawn = SpawningPeriod;
    }

    // Update is called once per frame
    void Update()
    {

        if(CheckCanSpawn())
        {
            timeSinceLastSpawn += Time.deltaTime;

            Spawn();
            timeSinceLastSpawn = 0;
        }
    }

    bool CheckCanSpawn()
    {
        return ((Vector3.Distance(transform.position, Player.position) > MinPlayerDistance) && timeSinceLastSpawn >= SpawningPeriod);
    }
}
