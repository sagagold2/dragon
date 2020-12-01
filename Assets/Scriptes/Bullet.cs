using UnityEngine;



/// <summary>
/// 총알 스크립트
/// 플레이어 총알, 적 총알, 보스 총알 스크립트
/// 
/// </summary>
/// 
public class Bullet : MonoBehaviour
{
    public float blulletSpeed;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * blulletSpeed);

        if (transform.position.z > 200)
        {
            Destroy(gameObject);
        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
          if (other.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Boss")
        {
            other.GetComponent<BossHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
