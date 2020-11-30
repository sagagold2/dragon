using System.Collections;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, }

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float bossAppearPoint = 100f;
    private BossState bossState = BossState.MoveToAppearPoint;

    private Movement movement;
    private BossAttack bossAttack;


    private void Awake()
    {
        movement = GetComponent<Movement>();
        bossAttack = GetComponent<BossAttack>();

    }
    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());

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
                ChangeState(BossState.Phase01);

            }
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        // 원 형태의 방사 공격 시작
        bossAttack.StartFiring(AttackType.CircleFire);

        while (true)
        {
            yield return null;
        }
    }

}
