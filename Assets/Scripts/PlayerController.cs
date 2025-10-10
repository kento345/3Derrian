using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    //-----�ړ�-----
    [SerializeField] private float speed = 10;
    private Vector2 inputVer;
    //-----���x-----
    [SerializeField] private GameObject HolePrefab;
    [SerializeField] private GameObject HolePos;


     
    [SerializeField] private Animator animator;

    private bool isDigging = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }
    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(HolePrefab, HolePos.transform.position,Quaternion.identity);
            isDigging = true;
        }
        if (context.canceled)
        {
            isDigging= false;
        }
    }

    void Update()
    {
        Move();


        animator.SetBool("IsDigging",isDigging);
    }

    void Move()
    {
        float magnitude;

        magnitude = inputVer.magnitude;
        

        Vector3 move = new Vector3(inputVer.x,0,inputVer.y) * speed * Time.deltaTime;
        transform.position += move;

        if (move != Vector3.zero)
        {
            Quaternion Rot = Quaternion.LookRotation(move,Vector3.up);
            transform.rotation = Rot;   
        }

        animator.SetFloat("Speed", magnitude);
    }
}
