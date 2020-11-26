using UnityEngine;
using System;

public class BackGroundScrolling : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
      

    }

    // Update is called once per frame
    void Update()
    {
     transform.Translate(Vector3.back * speed * Time.deltaTime);
        Debug.Log("맵 움직인다");
        if (transform.localPosition.z < -200f)
        {
            transform.localPosition = new Vector3(0, 0, 300);
            Debug.Log("맵 위치 바뀐다");
        }
    }


}
