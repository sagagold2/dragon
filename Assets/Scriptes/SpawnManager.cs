using System.Collections;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    public GameObject[] enemyPrefabs;

    [SerializeField]
    private GameObject bossEnemyPrefabs;
    public GameObject bossEnemyPrefabs1;

    //1단게 적 생성 위치
    private float spawnRangeX = 8; //스폰위치 좌우 조절
    private float spawnPosZ = 150; //스폰 위치 상하조절
    //2단계 적 생성 위치
    private float spawnPosZ1 = 100; //스폰 위치 상하조절

    public float maxSpawnDelay;
    public float curSpawnDelay;

    [SerializeField]
    private int maxEnemyCount = 100;
    [SerializeField]
    private GameObject textBossWarring;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
            
       // textBossWarring.SetActive(false); //보스등장 텍스트 비활성화
        bossEnemyPrefabs.SetActive(false);
        bossEnemyPrefabs1.SetActive(false);

        StartCoroutine("SpawnEnemy");
    }

 

    public IEnumerator SpawnEnemy()
    {
        int curEnemyCount = 0;

        curSpawnDelay += Time.deltaTime;

        while (true)
        {
            if (GameManager.instance.canvaJoystick.activeInHierarchy == true)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 7.6f, spawnPosZ);
                int randomEnemy = Random.Range(0, enemyPrefabs.Length);

                Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);

                curEnemyCount++;

                if (curEnemyCount == maxEnemyCount)
                {
                   // StartCoroutine("SpawnBoss");  //1스테이지 스킵을 위해 막아둔거임
                    break;
                }
            }

            if (GameManager.instance.canvaJoystick1.activeInHierarchy == true)
            {
                Vector3 spawnPos = new Vector3(0, Random.Range(-17, 60), spawnPosZ1);
                int randomEnemy = Random.Range(0, enemyPrefabs.Length);

                Instantiate(enemyPrefabs[randomEnemy], spawnPos, enemyPrefabs[randomEnemy].transform.rotation);

                curEnemyCount++;

                if (curEnemyCount == maxEnemyCount)
                {
                    StartCoroutine("SpawnBoss1");
                    break;
                }
            }


            yield return new WaitForSeconds(curSpawnDelay);
        }
    }

    private IEnumerator SpawnBoss()
    {
        textBossWarring.SetActive(true); //보스 등장시 텍스트 활성화

        yield return new WaitForSeconds(1.0f); //1초 대기 후 

        textBossWarring.SetActive(false); //보스 등잘 텍스트 비활성화

        bossEnemyPrefabs.SetActive(true); //보스오브젝트 활성화

        bossEnemyPrefabs.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
    }

    private IEnumerator SpawnBoss1()
    {
        textBossWarring.SetActive(true); //보스 등장시 텍스트 활성화

        yield return new WaitForSeconds(1.0f); //1초 대기 후 

        textBossWarring.SetActive(false); //보스 등잘 텍스트 비활성화

        bossEnemyPrefabs1.SetActive(true); //보스오브젝트 활성화

        bossEnemyPrefabs1.GetComponent<Boss1>().ChangeState(BossState1.MoveToAppearPoint);
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
