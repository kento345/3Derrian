using Unity.Android.Gradle;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    public bool isHole = false;
    public bool isHWall = false;
    [SerializeField] private GameObject hole;
    [SerializeField] private GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hole"))
        {
            isHole = true;
            hole = other.gameObject;
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            isHWall = true;
            wall = other.gameObject;
        }

    }

    public GameObject Chack()
    {

        if (isHole) {
            return hole;
        }
        if (isHWall) {
            return wall;
        }
        return null;
    }
}
