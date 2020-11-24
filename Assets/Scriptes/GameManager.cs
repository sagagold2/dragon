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

        mainCamera.MoveCamera(0);


        canvaJoystick.SetActive(true);
        canvaJoystick1.SetActive(false);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Stage(int Index)
    {
        mainCamera.MoveCamera(0);
        canvaJoystick.SetActive(true);
        canvaJoystick1.SetActive(false);
        canvaJoystick2.SetActive(false);
        canvaJoystick3.SetActive(false);

    }
}
