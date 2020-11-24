using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody Rigid;



    public Joystick VirtualJoystick;
    public Joystick1 VirtualJoystick1;
    public Joystick2 VirtualJoystick2;
    public Joystick3 VirtualJoystick3;

    public float MoveSpeed = 5.0f;
    public float Drag = 0.5f;

    public GameObject prefabFireBall;

    float shootDelay = 0.4f;
    float shootTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        Rigid.drag = Drag;
    }
    void FixedUpdate()
    {
        CameraChangeforMove();
        Fire();
    }

    // 플레이어 화면 전환에 따른 조이스틱 위치 변경/ 캐릭터 무브
    public void CameraChangeforMove() //화면이 돌아갈때마다 캔버스를 활성화 하는데 그떄 자식으로들어간 조이스틱들의 활성화에 따른 작동
    {

        if (GameManager.instance.canvaJoystick.activeInHierarchy == true) //처음화면 카메라 0 번 (기본)
        {


            Vector3 dir = Vector3.zero;

            if (VirtualJoystick.InputVector != Vector3.zero)
            {
                dir = VirtualJoystick.InputVector;
            }
            Vector3 vec3 = Vector3.zero;
            vec3.x = dir.x;
            vec3.z = dir.z;
            //print(vec2);
            Rigid.velocity = (vec3 * MoveSpeed);
            // print(Controller.velocity);
            //화면 안에서 이동
            if (transform.position.x < -7f) //좌
            {
                transform.position = new Vector3(-7f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 7f) //우
            {
                transform.position = new Vector3(7f, transform.position.y, transform.position.z);
            }
            if (transform.position.z < -12f) //하
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -12f);
            }
            if (transform.position.z > 18f) //상
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 18f);
            }
            Debug.Log("joystick  Active");
        }
        else if (GameManager.instance.canvaJoystick1.activeInHierarchy == true) //캐릭터 좌측 카메라 1번
        {
            Vector3 dir = Vector3.zero;

            if (VirtualJoystick1.InputVector != Vector3.zero)
            {
                dir = VirtualJoystick1.InputVector;
            }
            Vector3 vec3 = Vector3.zero;
            vec3.y = dir.x * -1;
            vec3.z = dir.z;
            //print(vec2);
            Rigid.velocity = (vec3 * MoveSpeed);
            // print(Controller.velocity);
            //화면 안에서 이동
            if (transform.position.y < 1f) //하
            {
                transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            }
            if (transform.position.y > 17f) //상
            {
                transform.position = new Vector3(transform.position.x, 17f, transform.position.z);
            }
            if (transform.position.z < -23f) //좌
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -23f);
            }
            if (transform.position.z > 27f) //우
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 27f);
            }
            Debug.Log("joystick 1 Active");
        }
        else if (GameManager.instance.canvaJoystick2.activeInHierarchy == true)  //캐릭터 우측 카메라 2번
        {
            Vector3 dir = Vector3.zero;

            if (VirtualJoystick2.InputVector != Vector3.zero)
            {
                dir = VirtualJoystick2.InputVector;
            }
            Vector3 vec3 = Vector3.zero;
            vec3.y = dir.x * -1;
            vec3.z = dir.z * -1;
            //print(vec2);
            Rigid.velocity = (vec3 * MoveSpeed);
            // print(Controller.velocity);
            if (transform.position.y < 1f) //하
            {
                transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            }
            if (transform.position.y > 17f) //상
            {
                transform.position = new Vector3(transform.position.x, 17f, transform.position.z);
            }
            if (transform.position.z > 33f) //좌
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 33f);
            }
            if (transform.position.z < -17f) //우
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -17f);
            }
            Debug.Log("joystick 2 Active");
        }
        else if (GameManager.instance.canvaJoystick3.activeInHierarchy == true)
        {
            Vector3 dir = Vector3.zero;

            if (VirtualJoystick3.InputVector != Vector3.zero)
            {
                dir = VirtualJoystick3.InputVector;
            }
            Vector3 vec3 = Vector3.zero;
            vec3.x = dir.x;
            vec3.z = dir.z;
            //print(vec2);
            Rigid.velocity = (vec3 * MoveSpeed);
            // print(Controller.velocity);
            if (transform.position.x < -7f) //좌
            {
                transform.position = new Vector3(-7f, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 7f) //우
            {
                transform.position = new Vector3(7f, transform.position.y, transform.position.z);
            }
            if (transform.position.z < 3f) //하
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 3f);
            }
            if (transform.position.z > 30f) //상
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 30f);
            }
            Debug.Log("joystick 3 Active");
        }
    }


    void Fire()
    {
        if (shootTimer > shootDelay)
        {
            GameObject bullet = Instantiate(prefabFireBall, transform.position, transform.rotation);
            shootTimer = 0;
        }
        shootTimer += Time.deltaTime;

    }


   
}
