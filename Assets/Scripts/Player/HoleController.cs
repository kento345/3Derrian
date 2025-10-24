using UnityEngine;

public class HoleController : MonoBehaviour
{
    public bool isMax = false;
    
    void Start()
    {
        Destroy(gameObject,3f);
    }

    void Update()
    {
        if (transform.localScale.x > 1.0f)
        {
            isMax = true;
        }
        else
        {
            isMax = false;
        }
    }
}
