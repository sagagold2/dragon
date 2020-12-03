using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 100; //최대 체력
    public float currentHP; //현재 체력
    private Boss boss; //Boss 스크립트

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    private void Awake()
    {
        currentHP = maxHP; //시작시 현채체력과 최대체력을 동일하게 맞춤

        boss = GetComponent<Boss>();

    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage; //현재 체력을 damage 만큼 감소

        

        if(currentHP <= 0) //체력이 0과 같거나 0보다 낮으면 
        {
            boss.Ondie();
        }

    }

    


}
