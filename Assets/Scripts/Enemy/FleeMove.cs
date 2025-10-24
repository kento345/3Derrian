using UnityEngine;

public class FleeMove : MonoBehaviour
{
    //ˆÚ“®
    private float speed = 5.0f;
    private float timer = 1.0f;
    private float Count;
    private Quaternion Rot;

    [SerializeField] private LayerMask wallLayer;

    private bool isHit = false;
    private bool wasHit = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rot = transform.rotation;
    }

    public void Move()
    {
        Count += Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Count > timer)
        {
            Rot = Quaternion.Euler(0, Random.Range(0, 360), 0);

            Count = 0;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Rot, Time.deltaTime * 10.0f);
    }

     public void CreatRay()
    {
        Ray ray;
        RaycastHit hit;

        var origine = new Vector3(transform.position.x, transform.position.y+1, transform.position.z) ;
        var direction = transform.forward;
        float distance = 2.0f;

        ray = new Ray(origine, direction);

        Debug.DrawRay(origine, direction * distance, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            isHit = true;
            if(isHit && !wasHit)
            {
                int rnd = Random.Range(0, 2);

                if(rnd == 0)
                {
                    Rot = Quaternion.Euler(0,transform.eulerAngles.y + 90, 0);
                }
                else
                {
                    Rot = Quaternion.Euler(0,transform.eulerAngles.y - 90, 0);
                }
            }
        }
        else
        {
            isHit = false;
        }

        wasHit = isHit;
    }
}
