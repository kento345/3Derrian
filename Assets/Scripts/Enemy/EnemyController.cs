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
    [SerializeField] private GameObject player;

    //ProjectのPlayerのオブジェクトを入れると原点のポジションを取得してしまうHierarchyのPlayerの移動中のPlayerに追尾せず原点の方向に行く

    //-----class-----
    FleeMove fm;
    ChaceMove cm;

    void Start()
    {
        //初期化
      fm = GetComponent<FleeMove>();
      cm = GetComponent<ChaceMove>();
    }

    void Update()
    {
        switch(currentState)
        {
            case EnemyState.Flee:
                Flee();
                break;
            case EnemyState.Chase:
                Chase();
                break;
          /*  case EnemyState.Attack:
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

        //-----状態変更-----
        if (Vector3.Distance(transform.position, player.transform.position) < 10.0f)
        {
            Debug.Log("追跡へ");
            currentState = EnemyState.Chase;
        }
    }

    void Chase()
    {
        //-----処理-----
        cm.Chace();

        //-----状態変更-----
        if (Vector3.Distance(transform.position,player.transform.position) < 1.5f)
        {
            Debug.Log("攻撃へ");
            currentState = EnemyState.Attack;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) > 10.0f)
        {
            currentState = EnemyState.Flee;
        }
        //-----状態変更-----Holeへの変更
        /*else if()
        {

        }*/
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
