using UnityEngine;

public class BossBullet : MonoBehaviour
{

    //[SerializeField]
    //private int damage = 1;


    private BossHP bossHP;
    private BossHP bossHP1;
    private BossHP bossHP2;
    private BossHP bossHP3;
    void Start()
    {
        bossHP = GameObject.Find("Boss").GetComponent<BossHP>();
        bossHP1 = GameObject.Find("Boss1").GetComponent<BossHP>();
        bossHP2 = GameObject.Find("Boss2").GetComponent<BossHP>();
        bossHP3 = GameObject.Find("Boss3").GetComponent<BossHP>();
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
            bossHP.CurrentHP <= 0 ||
            bossHP1.CurrentHP <= 0 ||
            bossHP2.CurrentHP <= 0 ||
            bossHP3.CurrentHP <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }

    }
}
