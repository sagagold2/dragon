using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearpoin = 0,}

public class Boss : MonoBehaviour
{
    [SerializeField]
    private float bossAppearPoint = 2.5f;
    private BossState bossState = BossState.MoveToAppearpoin;
    private Enemy EnemyMove;


    private void Awake()
    {
        EnemyMove = GetComponent<Enemy>();
    }
    public void ChangeState(BossState newState)
    {
        StopCoroutine(bossState.ToString());

        bossState = newState;

        StartCoroutine(bossState.ToString());

    }

    //private IEnumerator MoveToAppearPoint()  유트브 '고박사의 유니티 노트' 비행 슈팅 게임 #04 7:50 초 까지 본거임
    //{
    //    EnemyMove.
    //}

}
