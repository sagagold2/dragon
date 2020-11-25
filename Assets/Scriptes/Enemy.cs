using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    Rigidbody rigid;

    public GameObject enemybulletPrefab;
    float shootDelay = 4f;
    float shootTimer = 0;
    public float bulletSpeed;

    void Awake()
    {

        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.back * speed;
    }

    void Update()
    {
        EnemyFire();

    }

    void OnHit(int dmg)
    {
        health -= dmg;


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Border")
            Destroy(gameObject);

        else if (other.gameObject.tag == "PlayerBullet")
        {

            Bullet bullet = other.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);

            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void EnemyFire()
    {
        if (shootTimer > shootDelay)
        {
            GameObject enemybullet = Instantiate(enemybulletPrefab, transform.position, transform.rotation);
            shootTimer = 0;
            Debug.Log("적 총 발사");
        }
        shootTimer += Time.deltaTime;


    }

}
