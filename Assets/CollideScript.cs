//using Unity.Android.Gradle;
using Unity.Collections;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    public bool isHole = false;
    public bool isHWall = false;
    public GameObject hole;
    private GameObject wall;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hole"))
        {
            isHole = true;
            hole = other.gameObject;
        }
        else if (other.CompareTag("Wall"))
        {
            isHWall = true;
            wall = other.gameObject;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            isHole = false;
            hole = null;
        }
        else if (other.CompareTag("Wall"))
        {
            isHWall = false;
            wall = null;
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
