using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool ParentSpawnees;

    public GameObject Spawnee;
    public int BaseQuantity;
    public int Separation;
    public List<GameObject> Spawns;

    private void Start()
    {
        Spawns = new List<GameObject>();
    }

    public void Spawn(float multiplier=1)
    {
        Spawns = Spawns.Where(spawn => spawn != null).ToList();
        int length = Spawns.Count();
        for (int i = 0; i < Mathf.Floor(multiplier * BaseQuantity) - length; i++)
        {
            float theta = (float)((2.0 * Mathf.PI) * Random.value);

            Vector3 separationVector = new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta)) * Separation;

            GameObject Spawn;

            if (ParentSpawnees)
            {
                Spawn = Instantiate(Spawnee, transform.position + separationVector, transform.rotation, gameObject.transform);

            }
            else
            {
                Spawn = Instantiate(Spawnee, transform.position + separationVector, transform.rotation);
            }

            Spawns.Add(Spawn);
        }

    }
}