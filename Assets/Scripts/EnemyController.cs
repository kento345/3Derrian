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
    [SerializeField] private float speed = 10.0f;

    private int rigth = 10;
    private int left  = 0;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Hole:
                Hole();
                break;
        }
        //CreatRay();
    }

    void Flee()
    {
        //-----処理-----

        //-----状態変更-----
        if(Vector3.Distance(transform.position,player.position) < 5f)
        {
            currentState = EnemyState.Chase;
        }
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
        //rb.AddForce(transform.forward * speed , ForceMode.Force);
    }

   /* void CreatRay()
    {
        Ray ray;
        RaycastHit hit;
        var origin = transform.position + new Vector3(0, 1, 0);

        var direction = transform.forward;
        
        ray = new Ray(origin , direction);

        

        if(Physics.Raycast(ray, out hit,2))
        {
        

            //Ran();
            Debug.Log("HitObj" + hit.collider.gameObject.name);
            //Debug.DrawRay(origin, direction * 1.5f, Color.red);

        }
    }*/

    //-----乱数巡回-----
 /*   void Ran()
    {
        int ran = Random.Range(left, rigth);
        Debug.Log("乱数:" + ran);

        if (ran <=5)
        {
            transform.Rotate(0, -90, 0);
        }
        else if(ran >= 5)
        {
            transform.Rotate(0, 90, 0);
        }
        
    }*/

}
