using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHoleController : MonoBehaviour
{
    //-----ŒŠ–x-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private GameObject HolePos;
    [SerializeField] private LayerMask holeLayer;
    private GameObject hole;
    private HoleController holeCon;

    public bool isDigging = false;
    private bool isHole = false;


    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hole = Instantiate(HolePrefab, HolePos.transform.position, Quaternion.identity);
            isDigging = true;
        }
        if (context.canceled)
        {
            isDigging = false;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDigging && hole.transform.localScale.x < 1.0f )
        {
            hole.transform.localScale += new Vector3(0.01f, 0f, 0.01f);
        }
        if(hole == null) { return; }
        holeCon = hole.GetComponent<HoleController>();


        var origine = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        var direction = transform.forward;
        float distance = 2.0f;

        Ray ray = new Ray(origine, direction);
        RaycastHit hit;
        Debug.DrawRay(origine,direction * distance, Color.red);
        if(Physics.Raycast(ray, out hit,distance))
        {
            isHole = ((1 << hit.collider.gameObject.layer) & holeLayer) != 0;

            if(isHole && holeCon.isMax)
            {
                Debug.Log("100");
            }
        }
    }
}
