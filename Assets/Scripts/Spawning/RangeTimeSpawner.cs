using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTimeSpawner : Spawner
{
    public int SpawningPeriod;
    private float timeSinceLastSpawn;
    public Transform Player;
    public float MinPlayerDistance;
    private GameObject Controller; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        timeSinceLastSpawn = SpawningPeriod;
        Controller = GameObject.FindWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Player.position) > MinPlayerDistance)
        {
            timeSinceLastSpawn += Time.deltaTime;
        }

        if(CheckCanSpawn())
        {
            Spawn(GetCurrentSpawnMultiplier(Controller.GetComponent<PointCalculator>().Points));
            timeSinceLastSpawn = 0;
        }
    }

    bool CheckCanSpawn()
    {
        return ((Vector3.Distance(transform.position, Player.position) > MinPlayerDistance) && timeSinceLastSpawn >= SpawningPeriod);
    }

    float GetCurrentSpawnMultiplier(int score)
    {
        return Mathf.Max(Mathf.Log10(score), 1);
    }
}

