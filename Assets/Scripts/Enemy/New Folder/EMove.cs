using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance = 2f;
    [SerializeField] private float range = 10f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dire = (player.transform.position - transform.position).normalized;

        if (Physics.Raycast(transform.position,transform.forward,out RaycastHit hit,distance))
        {
            Vector3 avoidDir = Vector3.Cross(Vector3.up,hit.normal);
            dire = avoidDir.normalized;
        }

        if(Vector3.Distance(transform.position,player.transform.position) < range)
        {
            if (rb != null && !rb.isKinematic)
            {
                rb.MovePosition(rb.position + dire * speed * Time.deltaTime);
            }
            else
            {
                transform.position += dire * speed * Time.deltaTime;
            }

            transform.forward = Vector3.Lerp(transform.forward, dire, Time.deltaTime * 5f);
        }
    }
}
