using UnityEngine;

public class BossBullet : MonoBehaviour
{

    //[SerializeField]
    //private int damage = 1;


    private BossHP  bossHP;

    void Start()
    {
        bossHP = GameObject.Find("Boss").GetComponent<BossHP>();
        bossHP = GameObject.Find("Boss1").GetComponent<BossHP>();
    }

    void Update()
    {
        //보스 총알이 해당 지역에 위치까지 도달했을때 파괴 하기
        if (transform.position.x <= -60f ||
            transform.position.x >= 60f ||
            transform.position.z <= -70f ||
            transform.position.z >= 160f ||
            transform.position.y <= -80f ||
            transform.position.y >= 80f ||
            bossHP.CurrentHP <= 0 )
        {
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }
}
