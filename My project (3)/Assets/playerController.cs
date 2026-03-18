using UnityEngine;
using UnityEngine.InputSystem;
public class playerController : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 7f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private Animator myanimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        myanimator.SetBool("move", false);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    void Update()
    {

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(moveInput.magnitude > 0)
        {
            myanimator.SetBool("move", true);
        }
        else
        {
            myanimator.SetBool("move", false);
        }
            transform.Translate(Vector3.right * moveSpeed * moveInput.x * Time.deltaTime);

    }
}
