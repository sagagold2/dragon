using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerBulletPrefab;
    public GameObject enemyBulletPrefab;

    GameObject[] enemy;
    GameObject[] playerbullet;
    GameObject[] enemyBullet;

    GameObject[] targetPool;
    void Awake()
    {
        enemy = new GameObject[20];
        playerbullet = new GameObject[50];
        enemyBullet = new GameObject[100];


        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < enemy.Length; index++)
        {
            enemy[index] = Instantiate(enemyPrefab);
            enemy[index].SetActive(false);
        }
        for (int index = 0; index < playerbullet.Length; index++)
        {
            playerbullet[index] = Instantiate(playerBulletPrefab);
            playerbullet[index].SetActive(false);
        }
        for (int index = 0; index < enemyBullet.Length; index++)
        {
            enemyBullet[index] = Instantiate(enemyBulletPrefab);
            enemyBullet[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {


        switch (type)
        {
            case "enemy":
                targetPool = enemy;
                break;
            case "playerbullet":
                targetPool = playerbullet;
                break;
            case "enemyBullet":
                targetPool = enemyBullet;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        return null;
    }
}
