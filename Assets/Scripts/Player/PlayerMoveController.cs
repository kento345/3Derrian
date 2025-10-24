using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMoveController : MonoBehaviour
{
    //-----ˆÚ“®-----
    [SerializeField] private float speed = 10;
    private Vector2 inputVer;
    

    [SerializeField] private Animator animator;

    private PlayerHoleController holeCon;

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVer = context.ReadValue<Vector2>();
    }

    private void Start()
    {
        holeCon = GetComponent<PlayerHoleController>();
    }

    void Update()
    {
        Move();


        animator.SetBool("IsDigging", holeCon.isDigging);
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
