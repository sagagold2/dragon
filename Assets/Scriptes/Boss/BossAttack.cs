using System.Collections;
using UnityEngine;


public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }

public class BossAttack : MonoBehaviour
{

    [SerializeField]
    private GameObject bossBulletPrefab; //보스의 공격미사일 프리팹

    public void StartFiring(AttackType attackType)
    {
        StartCoroutine(attackType.ToString()); //atttackType 열거형의 이름과 같은 코루틴을 실행
    }

    public void StopFiring(AttackType attackType)
    {
        StopCoroutine(attackType.ToString());  //atttackType 열거형의 이름과 같은 코루틴을 중지
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 1f;  //공격주기
        int count = 30;  //발사체 생성 개수
        float intervalAngle = 360 / count; //발사체 시야의 각도
        float weightAngle = 0; //가중되는 각도(항상 같은 위치로 발사하지 않도록 설정)

        //원 형태로 방사하는 발사체 생성( count 개수만큼)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(bossBulletPrefab, transform.position, Quaternion.identity);
                //발사체 이동 발향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향(백터)
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f); //Cos, 라디안 단위의 각도 표현을 위해 PI/180 을 곱함
                float z = Mathf.Sin(angle * Mathf.PI / 180.0f); //Sin, 라디안 단위의 각도 표현을 위해 PI/180 을 곱함
                //발사체 이동 방향 설정
                clone.GetComponent<Movement>().MoveTo(new Vector3(x, 0, z));
                Debug.Log("보스패턴1");
            }

            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 3;

            //attackRate 시간만큼 대시
            yield return new WaitForSeconds(attackRate);
        }

    }

    private IEnumerator SingleFireToCenterPosition()
    {
        Vector3 targetposotion = Vector3.zero; //목표위치 정중앙

        float attackRate = 1f; //공격 딜레이

        while (true)
        {
            GameObject clone = Instantiate(bossBulletPrefab, transform.position, Quaternion.identity); //총알생성

            Vector3 direction = (targetposotion - clone.transform.position).normalized; //발사체 이동방향

            clone.GetComponent<Movement>().MoveTo(direction); //발사체 이동방향 설정

            yield return new WaitForSeconds(attackRate); //attackRate 시간 만큼 대기

        }
    }
}
