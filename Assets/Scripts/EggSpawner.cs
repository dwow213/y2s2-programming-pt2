using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float eggSpawnTime = 3;
    public float eggLimit = 10;
    public Vector3 eggLowBoundSpawn;
    public Vector3 eggHighBoundSpawn;

    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= eggSpawnTime)
        {
            SpawnEgg();
            timer = 0;
        }
    }

    void SpawnEgg()
    {
        GameObject egg = Instantiate(eggPrefab);
        Vector3 newPos = new Vector3(
            Random.Range(eggLowBoundSpawn.x, eggHighBoundSpawn.x),
            Random.Range(eggLowBoundSpawn.y, eggHighBoundSpawn.y),
            Random.Range(eggLowBoundSpawn.z, eggHighBoundSpawn.z)
            );

        egg.transform.position = newPos;
        egg.transform.parent = GameObject.Find("EggsHolder").transform;

    }
}
