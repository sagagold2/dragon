using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public  float spawnRangeX = 8; //스폰위치 좌우 조절
    public float spawnPosZ = 150; //스폰 위치 상하조절

    public float maxSpawnDelay;
    public float curSpawnDelay;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        SpawnEnemy();
    }


    void SpawnEnemy()
    {
        if (GameManager.instance.canvaJoystick.activeInHierarchy == true)
        {
            if (curSpawnDelay > maxSpawnDelay)
            {
                
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 7.6f, spawnPosZ);
                int randomEnemy = Random.Range(0, enemyPrefabs.Length);


               

                Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);

                maxSpawnDelay = Random.Range(2f, 4f);
                curSpawnDelay = 0;

            }
        }

        
    }
}
