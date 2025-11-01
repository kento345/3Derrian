using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHoleController : MonoBehaviour
{
    //-----ŒŠ–x-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private GameObject HolePos;

    private GameObject h;
    private HoleController holeCon;
    private float scale = 0.1f;

    [HideInInspector] public bool isDigging = false;

    [SerializeField] CollideScript collideScript;

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed )
        {
            var g = collideScript.Chack();
            if ( g == null)
            {
                h = Instantiate(HolePrefab, HolePos.transform.position, Quaternion.identity);
                isDigging = true;

              
            }
            else if(g.tag == "Hole")
            {
                h = g;
                isDigging = true;
            }
            else if(g.tag == "Wall")
            {

            }
            
        }
        if (context.canceled)
        {
            isDigging = false;
            h = null;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDigging && h != null)
        {
            Vector3 cur = h.transform.localScale;

            if (cur.x < 2.0f)
            {
                cur.x = Mathf.Min(cur.x + scale * Time.deltaTime * 10f, 2.0f);
                cur.z = Mathf.Min(cur.z + scale * Time.deltaTime * 10f, 2.0f);
                h.transform.localScale = cur;
            }
        }
    }
}

