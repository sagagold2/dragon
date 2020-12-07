using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelGameover : MonoBehaviour
{
   

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    //public void OnClickGoMainButton()
    //{
    //    SceneManager.LoadScene("MainScene");
    //}
}
