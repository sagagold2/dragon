using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;



    public GameObject canvaJoystick;
    public GameObject canvaJoystick1;
    public GameObject canvaJoystick2;
    public GameObject canvaJoystick3;

    public MainCamera mainCamera;
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

        //Stage(0);

        //    mainCamera.MoveCamera(0);


        //    canvaJoystick.SetActive(true);
        //    canvaJoystick1.SetActive(false);
        //    canvaJoystick2.SetActive(false);
        //    canvaJoystick3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

   public  void Stage1(int Index)
    {
        mainCamera.MoveCamera(0);
        canvaJoystick.SetActive(true);
        canvaJoystick1.SetActive(false);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

    }
    public void Stage2(int Index)
    {
        mainCamera.MoveCamera(1);
        canvaJoystick.SetActive(false);
        canvaJoystick1.SetActive(true);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

    }
    public void Stage3(int Index)
    {
        mainCamera.MoveCamera(2);
        canvaJoystick.SetActive(false);
        canvaJoystick1.SetActive(false);
        canvaJoystick2.SetActive(true);
        canvaJoystick3.SetActive(false);

    }
    public void Stage4(int Index)
    {
        mainCamera.MoveCamera(3);
        canvaJoystick.SetActive(false);
        canvaJoystick1.SetActive(false);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(true);

    }
}
