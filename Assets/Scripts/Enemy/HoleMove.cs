using Unity.VisualScripting.FullSerializer;
using UnityEditor.Rendering;
using UnityEngine;

public class HoleMove : MonoBehaviour
{
    [SerializeField] private LayerMask holeLayer;

    private bool isHole;

    private FleeMove fmove;
    private ChaceMove cmove;

    private void Start()
    {
        fmove = GetComponent<FleeMove>();
        cmove = GetComponent<ChaceMove>();
    }

    public void Hole()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Hole"))
        {
            fmove.speed = 0;
            cmove.speed = 0;
        }
    }
}
