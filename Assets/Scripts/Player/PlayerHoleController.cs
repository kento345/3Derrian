using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHoleController : MonoBehaviour
{
    //-----穴堀-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private GameObject HolePos;
    [SerializeField] private LayerMask holeLayer;
    private GameObject hole;
    private HoleController holeCon;

    [HideInInspector] public bool isDigging = false;
    private bool isHole = false;
    private bool isSmoal = false;

    [SerializeField] CollideScript collideScript;

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed )
        {
            var g = collideScript.Chack();
            if ( g == null)
            {
                hole = Instantiate(HolePrefab, HolePos.transform.position, Quaternion.identity);
                isDigging = true;
            }
            else if(g.tag == "Hole")
            {
                if (isDigging && hole.transform.localScale.x < 1.0f)
                {
                    hole.transform.localScale += new Vector3(0.01f, 0f, 0.01f);
                }
            }
            else if(g.tag == "Wall")
            {

            }
            
        }
        if (context.canceled)
        {
            isDigging = false;
        }
    }


    void Start()
    {
        //GameObject bc = box.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //穴のサイズ変更
        
        //CheckHole();
    }
    //完成された穴が正面にあるかの判定
    void CheckHole(GameObject hole)
    {
/*        if (hole == null) { return; }
        holeCon = hole.GetComponent<HoleController>();


        var origine = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        var direction = transform.forward;
        float distance = 2.0f;

        Ray ray = new Ray(origine, direction);
        RaycastHit hit;
        Debug.DrawRay(origine, direction * distance, Color.red);
        if (Physics.Raycast(ray, out hit, distance))
        {
            

           
            if (isHole && holeCon.isMax)
            {
               //小さくする
            }
        }*/



    }

    
}

