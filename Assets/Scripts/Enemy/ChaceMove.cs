using Unity.VisualScripting;
using UnityEngine;

public class ChaceMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject player;
    private float distance = 10.0f;

    [SerializeField] private float Rotspeed = 5.0f;


    public void Chace()
    {

        float dist = Vector3.Distance(transform.position,player.transform.position);
        if (dist < distance)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            dir.y = 0;

            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, speed * Time.deltaTime);

            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position, step);
        }
    }
}
