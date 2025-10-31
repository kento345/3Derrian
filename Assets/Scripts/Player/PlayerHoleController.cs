using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHoleController : MonoBehaviour
{
    //-----ŒŠ–x-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private GameObject HolePos;
    [SerializeField] private GameObject hole;
    private HoleController holeCon;

    [HideInInspector] public bool isDigging = false;

    [SerializeField] CollideScript collideScript;

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed )
        {
            var g = collideScript.Chack();
            if ( g == null)
            {
                Instantiate(HolePrefab, HolePos.transform.position, Quaternion.identity);
                isDigging = true;
                hole = null;
            }
            else if(g.tag == "Hole")
            {
                hole = collideScript.hole; 
                if (isDigging /*&& hole.transform.localScale.x < 1.0f*/)
                {
                    /* for (float i = 1; i <= 2; i += 0.1f)
                     {
                         hole.transform.localScale = new Vector3(i, 1, i);
                     }*/
                }
            }
            else if(g.tag == "Wall")
            {

            }
            
        }
        if (context.canceled)
        {
            isDigging = false;
            hole = null;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

