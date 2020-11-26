using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    [SerializeField]
    private GameObject bossEnemyPrefabs;

    public float spawnRangeX = 8; //스폰위치 좌우 조절
    public float spawnPosZ = 150; //스폰 위치 상하조절

    public float maxSpawnDelay;
    public float curSpawnDelay;

    [SerializeField]
    private int maxEnemyCount = 100;
    [SerializeField]
    private GameObject textBossWarring;

    private void Awake()
    {
        textBossWarring.SetActive(false); //보스등장 텍스트 비활성화
        bossEnemyPrefabs.SetActive(false);

        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        

        // SpawnEnemy();
    }

    private IEnumerator SpawnEnemy()
    {
        int curEnemyCount = 0;

        curSpawnDelay += Time.deltaTime;

        while (true)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 7.6f, spawnPosZ);
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);

            Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);
           

            curEnemyCount++;

            if(curEnemyCount == maxEnemyCount)
            {
                StartCoroutine("SpawnBoss");
                break;
            }

            yield return new WaitForSeconds(curSpawnDelay);
        }
    }

    private IEnumerator SpawnBoss()
    {
        textBossWarring.SetActive(true); //보스 등장시 텍스트 활성화

        yield return new WaitForSeconds(1.0f); //1초 대기 후 아래 텍스트 비활성화

        textBossWarring.SetActive(false); //보스 등잘 텍스트 비활성화

        bossEnemyPrefabs.SetActive(true); //보스오브젝트 활성화
    }




    //void SpawnEnemy()
    //{


    //    if (GameManager.instance.canvaJoystick.activeInHierarchy == true)
    //    {
    //        if (curSpawnDelay > maxSpawnDelay)
    //        {

    //            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 7.6f, spawnPosZ);
    //            int randomEnemy = Random.Range(0, enemyPrefabs.Length);




    //            Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);

    //            maxSpawnDelay = Random.Range(2f, 4f);
    //            curSpawnDelay = 0;

    //        }
    //    }


    //}
}
