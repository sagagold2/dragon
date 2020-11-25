using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float blulletSpeed;

    public int dmg;
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

    
}
