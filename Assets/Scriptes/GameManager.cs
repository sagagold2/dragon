using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject canvaJoystick;
    public GameObject canvaJoystick1;
    public GameObject canvaJoystick2;
    public GameObject canvaJoystick3;

    public GameObject panelGameClear;
    public GameObject panelGameover;

    public bool isGameover = true;
    public bool isPause = false;
    

    private GameObject Player;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Player = GameObject.Find("Player");
       // StartCoroutine("BossClear1");  //임시로 1스테이지 스킵
    }

    void Update()
    {

    }


   // 게임오버 상태
    public void GameOver()
    {
        if (isGameover)
        {
            //게임오버 패널 활성화
           // panelGameover.SetActive(true);

            //게임 일시정지
            isPause = !isPause;
            if (isPause)
            {
                Time.timeScale = 0f;  //시간흐름을 0초로(즉 일시정지)
            }
            else
            {
                Time.timeScale = 1f;  //시간흐름을 1초로(원래 시간대로// 0.5면 0.5배속으로 속도 조절이 가능)
            }
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }


    

    public void CallBossClear()
    {
        StartCoroutine("BossClear0");   
    }

    //1단계 보스 클리어시..
    public IEnumerator BossClear0()
    {
        Player.SetActive(false); //플레이어 오브젝트 비활성화 => 플레리어의 총발사 coroutine을 끄기위한..
        Player.SetActive(true);  //플레이어 오브젝트 활성화 => 플레이어의 총알발사가 StartCoroutine 이 실행되고 있기때문에 아래의 StopCoroutine 이 작용 안됨..

        // StopCoroutine(PlayerController.instance.PlayerFire());

        MainCamera.instance.MoveCamera(1); //카메라 이동
        

        canvaJoystick.SetActive(false); //카메라(0) 번 화면의 캔버스(조이스틱) 비활성화
        
        yield return new WaitForSeconds(5f); //5초대기
        PlayerController.instance.transform.position = Vector3.zero;
        canvaJoystick1.SetActive(true); //카메라(1) 번 화면의 캔버스(조이스틱) 활성화
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

        // yield return new WaitForSeconds(2f); //2초 대기
        

        StartCoroutine(PlayerController.instance.PlayerFire()); //플레이어의 총발사 coroutine 진행

        StartCoroutine(SpawnManager.instance.SpawnEnemy());
        yield break; //위 싸이클을 한번 돌리고 멈추기
    }

    public void CallBossClear1()
    {
        StartCoroutine("BossClear1");   
    }

    //2단계 보스 클리어시..
    public IEnumerator BossClear1()
    {
        Player.SetActive(false); //플레이어 오브젝트 비활성화 => 플레리어의 총발사 coroutine을 끄기위한..
        Player.SetActive(true);  //플레이어 오브젝트 활성화 => 플레이어의 총알발사가 StartCoroutine 이 실행되고 있기때문에 아래의 StopCoroutine 이 작용 안됨..

        // StopCoroutine(PlayerController.instance.PlayerFire());

        MainCamera.instance.MoveCamera(2); //카메라 이동
        

        canvaJoystick.SetActive(false); //카메라(0) 번 화면의 캔버스(조이스틱) 비활성화
        canvaJoystick1.SetActive(false); //카메라(1) 번 화면의 캔버스(조이스틱) 비활성화
       
        yield return new WaitForSeconds(5f); //5초대기
        PlayerController.instance.transform.position = Vector3.zero;
        canvaJoystick2.SetActive(true);  //카메라(2) 번 화면의 캔버스(조이스틱) 활성화
        canvaJoystick3.SetActive(false);

        // yield return new WaitForSeconds(2f); //2초 대기


        StartCoroutine(PlayerController.instance.PlayerFire()); //플레이어의 총발사 coroutine 진행

        StartCoroutine(SpawnManager.instance.SpawnEnemy());
        yield break; //위 싸이클을 한번 돌리고 멈추기
    }

    public void CallBossClear2()
    {
        StartCoroutine("BossClear2");   
    }

    //3단계 보스 클리어시..
    public IEnumerator BossClear2()
    {
        Player.SetActive(false); //플레이어 오브젝트 비활성화 => 플레리어의 총발사 coroutine을 끄기위한..
        Player.SetActive(true);  //플레이어 오브젝트 활성화 => 플레이어의 총알발사가 StartCoroutine 이 실행되고 있기때문에 아래의 StopCoroutine 이 작용 안됨..

        // StopCoroutine(PlayerController.instance.PlayerFire());

        MainCamera.instance.MoveCamera(3); //카메라 이동
       

        canvaJoystick.SetActive(false); //카메라(0) 번 화면의 캔버스(조이스틱) 비활성화
        canvaJoystick1.SetActive(false); //카메라(1) 번 화면의 캔버스(조이스틱) 비활성화
        canvaJoystick2.SetActive(false);  //카메라(2) 번 화면의 캔버스(조이스틱) 활성화

        
        yield return new WaitForSeconds(5f); //5초대기
        PlayerController.instance.transform.position = Vector3.zero;
        canvaJoystick3.SetActive(true);

        // yield return new WaitForSeconds(2f); //2초 대기


        StartCoroutine(PlayerController.instance.PlayerFire()); //플레이어의 총발사 coroutine 진행

        StartCoroutine(SpawnManager.instance.SpawnEnemy());
        yield break; //위 싸이클을 한번 돌리고 멈추기
    }

    public void CallBossClear3() //최종 보스 클리어(4단계)
    {
        StartCoroutine("BossClear3");   //임시로 막아논거임
    }

    //4단계 보스 클리어시..
    public IEnumerator BossClear3()
    {
        Player.SetActive(false); //플레이어 오브젝트 비활성화 => 플레리어의 총발사 coroutine을 끄기위한..
        Player.SetActive(true);  //플레이어 오브젝트 활성화 => 플레이어의 총알발사가 StartCoroutine 이 실행되고 있기때문에 아래의 StopCoroutine 이 작용 안됨..

        // StopCoroutine(PlayerController.instance.PlayerFire());

       // MainCamera.instance.MoveCamera(0); //카메라 이동
       

        canvaJoystick.SetActive(false); //카메라(0) 번 화면의 캔버스(조이스틱) 비활성화
        canvaJoystick1.SetActive(false); //카메라(1) 번 화면의 캔버스(조이스틱) 비활성화
        canvaJoystick2.SetActive(false);  //카메라(2) 번 화면의 캔버스(조이스틱) 활성화
        
        yield return new WaitForSeconds(5f); //5초대기
        PlayerController.instance.transform.position = Vector3.zero;
        canvaJoystick3.SetActive(false);

        panelGameClear.SetActive(true);
        // yield return new WaitForSeconds(2f); //2초 대기


       // StartCoroutine(PlayerController.instance.PlayerFire()); //플레이어의 총발사 coroutine 진행

       // StartCoroutine(SpawnManager.instance.SpawnEnemy());
        yield break; //위 싸이클을 한번 돌리고 멈추기
    }
}
