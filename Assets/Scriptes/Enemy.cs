using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;

    Rigidbody rigid;

    public GameObject enemtbulletPrefab;
    float shootDelay = 1f;
    float shootTimer = 0;

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
            FireCollisionForwardScript bullet = other.gameObject.GetComponent<FireCollisionForwardScript>();

            OnHit(bullet.dmg);
        }
    }

    void EnemyFire()
    {
        if (shootTimer > shootDelay)
        {
            GameObject bullet = Instantiate(enemtbulletPrefab, transform.position, transform.rotation);
            shootTimer = 0;
        }
        shootTimer += Time.deltaTime;
    }

}
