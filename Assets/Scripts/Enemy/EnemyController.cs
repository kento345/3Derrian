using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Flee,Chase,Attack,Hole
    }
    public EnemyState currentState = EnemyState.Flee;
    private Transform player;

    //-----class-----
    FleeMove fm;


    [Header("当たり判定")]
    [SerializeField] private Vector3 wallCheckOffset;
    [SerializeField] private float wallChackRadius;
    

    void Start()
    {
        //初期化
      fm = GetComponent<FleeMove>();
    }

    void Update()
    {
        switch(currentState)
        {
            case EnemyState.Flee:
                Flee();
                break;
         /*   case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Hole:
                Hole();
                break;*/
        }
        //CreatRay();
    }

    void Flee()
    {
        //-----処理-----
        fm.Move();
        fm.CreatRay();

     /*   //-----状態変更-----
        if (Vector3.Distance(transform.position,player.position) < 5f)
        {
            currentState = EnemyState.Chase;
        }*/
    }

    void Chase()
    {
        //-----処理-----
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 2f);
        //-----状態変更-----
        if(Vector3.Distance(transform.position,player.position) < 1.5f)
        {
            currentState = EnemyState.Attack;
        }
    }

    void Attack()
    {
        //-----処理-----

        //-----状態変更-----

    }
    void Hole()
    {
        //-----処理-----

        //-----状態変更-----

    }

 
}
