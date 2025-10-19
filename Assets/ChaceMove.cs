using Unity.VisualScripting;
using UnityEngine;

public class ChaceMove : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject player;
    private float distance = 10.0f;


    public void Chace()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < distance)
        {
            float step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position,player.transform.position,step);
        }
    }
}
