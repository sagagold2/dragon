using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    public float speed = 10f;

    
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if( transform.localPosition.z < -600f)
        {
            transform.localPosition = new Vector3(0, 0, 1000);
        }
    }


}
