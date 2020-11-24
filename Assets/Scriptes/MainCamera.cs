using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    

    public Camera[] subCameras;

    void Start()
    {
        
        
      
    }


    public void MoveCamera(int index) //카메라를 목표지점으로 이동///index 는 서브카메라의 Element 숫자
    {
        Vector3 new_position = subCameras[index].transform.position;
        Vector3 new_rotation = subCameras[index].transform.eulerAngles;
        //transform.position = new_position;
        //transform.eulerAngles = new_rotation;

        iTween.MoveTo(this.gameObject, iTween.Hash("position", new_position, "easeType", iTween.EaseType.easeInOutExpo  , "time", 5.0f));
        iTween.RotateTo(this.gameObject, iTween.Hash("rotation", new_rotation, "easeType", iTween.EaseType.easeInOutExpo, "time", 5.0f));

        Debug.Log("Change Camera");
        
        //서브카메라 번호 순서
        //    0 : 기본 위
        //    1 : 캐릭터 좌측(폰 오른쪽으로 돌린거)
        //    2 : 캐릭터 우측(폰 왼쪽으로 돌린거)
        //    3 : 위 돌아간거(기본 위와 같은 포지션)

    }

   
}
