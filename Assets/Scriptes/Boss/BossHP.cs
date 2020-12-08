using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 100; //최대 체력
    public float currentHP; //현재 체력
    private Boss boss; //Boss 스크립트
    private Boss1 boss1;
    private Boss2 boss2;
    private Boss3 boss3;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;


    private void Awake()
    {
        currentHP = maxHP; //시작시 현채체력과 최대체력을 동일하게 맞춤

        boss = GetComponent<Boss>();
        boss1 = GetComponent<Boss1>();
        boss2 = GetComponent<Boss2>();
        boss3 = GetComponent<Boss3>();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage; //현재 체력을 damage 만큼 감소

        

        if(currentHP <= 0) //체력이 0과 같거나 0보다 낮으면 
        {
            boss.Ondie();
           
        }

    }

    public void TakeDamage1(float damage)
    {
        currentHP -= damage; //현재 체력을 damage 만큼 감소



        if (currentHP <= 0) //체력이 0과 같거나 0보다 낮으면 
        {
            boss1.Ondie();

        }
    }
    public void TakeDamage2(float damage)
    {
        currentHP -= damage; //현재 체력을 damage 만큼 감소



        if (currentHP <= 0) //체력이 0과 같거나 0보다 낮으면 
        {
            boss2.Ondie();

        }
    }

    public void TakeDamage3(float damage)
    {
        currentHP -= damage; //현재 체력을 damage 만큼 감소



        if (currentHP <= 0) //체력이 0과 같거나 0보다 낮으면 
        {
            boss3.Ondie();

        }
    }
}
