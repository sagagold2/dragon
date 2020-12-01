using UnityEngine;

public class BossBullet : MonoBehaviour
{

    //[SerializeField]
    //private int damage = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Boss")
        {

        }
    }
}
