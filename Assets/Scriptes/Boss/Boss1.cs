using System.Collections;
using UnityEngine;
using System;

public enum BossState1 { MoveToAppearPoint = 0, Phase01, Phase02, Phase03 }

public class Boss1 : MonoBehaviour
{
    

    [SerializeField]
    private float bossAppearPoint = 100f;
    private BossState1 bossState1 = BossState1.MoveToAppearPoint;
    private Movement movement;
    private BossAttack bossAttack;
    private BossHP bossHP; //보스 체력 기준으로 Phase 가 바뀌기 떄문에 보스체력 변수 선언

    [SerializeField]
    private GameObject explosionPrefab; //보스 사망시 이펙트 프리팹(파티클시스템으로 한거)


    private void Awake()
    {
        movement = GetComponent<Movement>();
        bossAttack = GetComponent<BossAttack>();
        bossHP = GetComponent<BossHP>();

    }
    public void ChangeState(BossState1 newState)
    {
        StopCoroutine(bossState1.ToString());

        bossState1 = newState;

        StartCoroutine(bossState1.ToString());

    }

    private IEnumerator MoveToAppearPoint()
    {
        //이동방향 설정
        movement.MoveTo(Vector3.back);


        while (true)
        {
            if (transform.position.z <= bossAppearPoint)
            {
                //이동 방향을 (0,0,0) 으로 설정해 멈추도록 한다
                movement.MoveTo(Vector3.zero);

                //Phase01 상태로 변경
                ChangeState(BossState1.Phase01);

            }
            yield return null;
        }
    }

    private IEnumerator Phase01() // 제자리에서 원 방사형 발사
    {
        // 원 형태의 방사 공격 시작
        bossAttack.StartFiring(AttackType.CircleFire);

        while (true)
        {
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.7f) //보스 체력이 70%이하가 되면
            {
                bossAttack.StopFiring(AttackType.CircleFire); //원 방사형 공격 중지

                ChangeState(BossState1.Phase02); //보스 페이즈 2로 변경
                Debug.Log("Boss Hp 70% 이하");
            }
            yield return null;
        }
    }

    private IEnumerator Phase02() //상하 이동하면 단일발사
    {
        //플레이어 위치를 기준으로 단일 발사체 공격 시작
        bossAttack.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.down; //처음이동발향을 오른쪽으로 설정
        movement.MoveTo(direction);

        while (true)
        {
            //좌우 이동 중 양쪽 끝에 다달하게 되면 방향을 반대로 설정
            if(transform.position.y <= -20f || 
               transform.position.y >= 30f)
            {
                direction *= -1; //방향변수에 -1을곱해서 반대방향으로 이동
                movement.MoveTo(direction);
            }

            //보스의 체력이 30%이하가 되면
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.3f) 
            {
                //플레이어 위치를 기준으로 단일 발사체 공격 을 중지
                bossAttack.StopFiring(AttackType.SingleFireToCenterPosition);

                //Phase03 으로 변경
                ChangeState(BossState1.Phase03);
                Debug.Log("Boss Hp 30% 이하");
            }
            yield return null;
        }
    }

    private IEnumerator Phase03() //Phase01 + Phase02 섞인거
    {
        //원형 방사형 공격 시작
        bossAttack.StartFiring(AttackType.CircleFire);
        //플레이어 위치를 기준으로 단일 발사체 공격 시작
        bossAttack.StartFiring(AttackType.SingleFireToCenterPosition);

        //처음이동발향을 오른쪽으로 설정
        Vector3 direction = Vector3.down; 
        movement.MoveTo(direction);

        while (true)
        {
            //좌우 이동 중 양쪽 끝에 다달하게 되면 방향을 반대로 설정
            if (transform.position.y <= -20f ||
               transform.position.y >= 30f)
            {
                direction *= -1;  //방향변수에 -1을곱해서 반대방향으로 이동
                movement.MoveTo(direction);
            }

            yield return null;
        }
    }

    public void Ondie() //보스 사망
    {
        //보스 파괴 파티클 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // StartCoroutine(GameManager.instance.BossClear()); <- 코루틴이라서 보스가 죽으면 서(오브젝트가 사라지기때문에) 코루틴이 끝김.
        GameManager.instance.CallBossClear(); //일반함수를 불어와서 처리가 별도로 이루어짐

        //보스오브젝트 삭제
        Destroy(gameObject);
    }
}
