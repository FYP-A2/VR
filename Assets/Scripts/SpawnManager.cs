using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    Vector3 randomPos,min,max;
    [SerializeField] Transform player;
    [SerializeField] GameObject monsterPrefab;
    [SerializeField] GameObject bossPrefab;
    int monsterCount, bossCount;
    public int count;
    float spawnDelay;
    bool spawned, bossSpawned, minibossSpawned;
    [SerializeField] Terrain terrain;
    public float gameTime;
    public bool start;
    RaycastHit hit;

    private void Start()
    {
        min = terrain.terrainData.bounds.min + terrain.GetPosition();
        max = terrain.terrainData.bounds.max + terrain.GetPosition();
        start= true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            start = true;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            start = false;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            SpawnEnemy(10, 2);

        if (start)
        {
            gameTime += Time.deltaTime;
            if (gameTime < 300)
            {
                if (!spawned)
                {
                    Spawn(monsterPrefab);
                    count++;
                    spawned = true;
                    Invoke("ResetSpawn", Random.Range(5, 10));
                }
            }
            else
            {
                if (!spawned)
                {
                    if (Random.Range(0, 100) < 50)
                    {
                        Spawn(bossPrefab);
                        count++;
                        Debug.Log(count);
                    }
                    else
                    {
                        Spawn(monsterPrefab);
                        count++;
                        Debug.Log(count);
                    }
                    spawned = true;
                    Invoke("ResetSpawn", Random.Range(5, 10));
                }
            }
            if (gameTime > 300 && gameTime < 300.1f) {
                if (!bossSpawned)
                {
                    Spawn(bossPrefab);
                    bossSpawned = true;
                }
            }
        }
    }
    public void SpawnEnemy(int monsterNo, int bossNo)
    {
        for (int i = 0; i < monsterNo; i++)
        {
            Spawn(monsterPrefab);
        }

        for (int i = 0; i < bossNo; i++)
        {
            Spawn(bossPrefab);
        }
    }

    void Spawn(GameObject prefab)
    {
        //randomPos = new Vector3(Random.Range(500f, 600f), 45f, Random.Range(300f, 400f));
        //randomPos = new Vector3(Random.Range(min.x, max.x), max.y, Random.Range(min.z, max.z));
        randomPos = new Vector3(Random.Range(player.position.x-100,player.position.x+100),max.y,Random.Range(player.position.z-100,player.position.z+100));
        if (Physics.Linecast(randomPos, new Vector3(randomPos.x, -1f, randomPos.z), out hit))
        {
              Debug.Log("work" + gameTime);
              Instantiate(prefab, hit.point, Quaternion.identity);
              bossCount++;
        }
        else
            Spawn(prefab);  
    }

    void ResetSpawn()
    {
        spawned = false;
    }
}
