using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyState
    {
        Flee,Chase,Attack,Hole
    }
    public EnemyState currentState = EnemyState.Flee;
    private Transform player;


    //移動
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] targets;
    [SerializeField] private GameObject InitEnemy = null;



    void Start()
    {
        FindEnemy();
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
        if (InitEnemy == null)
        {
            FindEnemy();
            return;
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, InitEnemy.transform.position, step);

        if (Vector3.Distance(transform.position, InitEnemy.transform.position) < 0.1f)
        {
            FindEnemy();
        }

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

    private void FixedUpdate()
    {
        
    }

    void FindEnemy()
    {
        targets = GameObject.FindGameObjectsWithTag("Point");



        float dist = Mathf.Infinity;
        GameObject nextEnemy = null;

        foreach (GameObject t in targets)
        {
            float tDist = Vector3.Distance(transform.position, t.transform.position);

            if (tDist < dist && tDist > 0.1f)
            {
                dist = tDist;

                nextEnemy = t;
            }

            if (tDist == 0)
            {
                InitEnemy = null;
                return;
            }
        }
        InitEnemy = nextEnemy;
    }
}
