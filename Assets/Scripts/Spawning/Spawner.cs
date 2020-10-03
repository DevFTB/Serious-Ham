using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool ParentSpawnees;

    public GameObject Spawnee;
    public int Quantity;
    public int Separation;

    public void Spawn()
    {
        Debug.Log(Spawnee.name);
        for (int i = 0; i < Quantity; i++)
        {
            float theta = (float)((2.0 * Mathf.PI) * Random.value);

            Vector3 separationVector = new Vector3(Mathf.Cos(theta), 0, Mathf.Sin(theta)) * Separation;

            if (ParentSpawnees)
            {
                Instantiate(Spawnee, transform.position + separationVector, transform.rotation, gameObject.transform);

            }
            else
            {
                Instantiate(Spawnee, transform.position + separationVector, transform.rotation);

            }
        }

    }
}