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


    public GameObject Player;



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
        Player = GameObject.Find("Player");
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
        Player.SetActive(false);
        Player.SetActive(true);
        // StopCoroutine(PlayerController.instance.PlayerFire());



        MainCamera.instance.MoveCamera(1);

        canvaJoystick.SetActive(false);

        yield return new WaitForSeconds(5f);

        

        canvaJoystick1.SetActive(true);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

        // yield return new WaitForSeconds(1);

         StartCoroutine(PlayerController.instance.PlayerFire());
        yield break;
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
