using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //ˆÚ“®
    [SerializeField] private float speed = 10.0f;

    private int rigth = 1;
    private int left  = -1;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CreatRay();
        //Ran();
    }

    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward * speed * Time.deltaTime, ForceMode.Force);
    }

    void CreatRay()
    {
        Ray ray;
        RaycastHit hit;
        var origin = transform.position + new Vector3(0, 1, 0);

        var direction = transform.forward;
        
        ray = new Ray(origin , direction);

        

        if(Physics.Raycast(ray, out hit,1.5f))
        {

            Debug.Log("HitObj" + hit.collider.gameObject.name);
            //Debug.DrawRay(origin, direction * 1.5f, Color.red);

        }
    }

   /* void Ran()
    {
        print(Random.Range(left,rigth));
    }*/

}
