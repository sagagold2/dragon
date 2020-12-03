using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject canvaJoystick;
    public GameObject canvaJoystick1;
    public GameObject canvaJoystick2;
    public GameObject canvaJoystick3;



    public bool isGameover = true;


    public PlayerController PlayerController;

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        canvaJoystick.SetActive(true);

        PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();

       
    }


    void Update()
    {



    }

    //public void Stage1(int Index)
    //{

    //    MainCamera.instance.MoveCamera(0);
    //    canvaJoystick.SetActive(true);
    //    canvaJoystick1.SetActive(false);
    //    canvaJoystick2.SetActive(false);
    //    canvaJoystick3.SetActive(false);

    //}
    public void CallBossClear()
    {
        StartCoroutine("BossClear");
    }

    public IEnumerator BossClear()
    {



        Debug.Log("보스클리어");
        StopCoroutine(PlayerController.PlayerFire());
        Debug.Log("보스클리어1");



        MainCamera.instance.MoveCamera(1);
        canvaJoystick.SetActive(false);

        yield return new WaitForSeconds(5f);

        Debug.Log("보스클리어111");
        
        canvaJoystick1.SetActive(true);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

        // yield return new WaitForSeconds(1);

        // StartCoroutine(PlayerController.PlayerFire());
        yield break;

        //yield return new WaitForSeconds(3);





        // yield return null;
    }

    //public void Stage2()
    //{
    //    Debug.Log("보스클리어");
    //    if (boss.gameObject.)
    //    {
    //        Debug.Log("장면 넘어가ㅣ");
    //       // Destroy(bossBullet.gameObject);
    //        PlayerController.StopCoroutine("PlayerFire");

    //        mainCamera.MoveCamera(1);
    //        canvaJoystick.SetActive(false);
    //        canvaJoystick1.SetActive(true);
    //        canvaJoystick2.SetActive(false);
    //        canvaJoystick3.SetActive(false);


    //    }




    //}
    //public void Stage3(int Index)
    //{
    //    MainCamera.instance.MoveCamera(2);
    //    canvaJoystick.SetActive(false);
    //    canvaJoystick1.SetActive(false);
    //    canvaJoystick2.SetActive(true);
    //    canvaJoystick3.SetActive(false);

    //}
    //public void Stage4(int Index)
    //{
    //    MainCamera.instance.MoveCamera(3);
    //    canvaJoystick.SetActive(false);
    //    canvaJoystick1.SetActive(false);
    //    canvaJoystick2.SetActive(false);
    //    canvaJoystick3.SetActive(true);

    //}
}
