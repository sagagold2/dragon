using UnityEngine;


public interface ICollisionHandler
{
    void HandleCollision(GameObject obj, Collision c);
}

/// <summary>
/// This script simply allows forwarding collision events for the objects that collide with something. This
/// allows you to have a generic collision handler and attach a collision forwarder to your child objects.
/// In addition, you also get access to the game object that is colliding, along with the object being
/// collided into, which is helpful.
/// </summary>
public class FireCollisionForwardScript : MonoBehaviour
{
    public ICollisionHandler CollisionHandler;

    public int dmg;

    public void OnCollisionEnter(Collision col)
    {
        CollisionHandler.HandleCollision(gameObject, col);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            // print("총알이 적과 충돌");

        }

        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}


