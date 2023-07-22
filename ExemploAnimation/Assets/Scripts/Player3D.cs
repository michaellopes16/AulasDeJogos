using UnityEngine;

public class Player3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public float jumpForce = 5f;
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isJumping;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;
        print(isGrounded);
        // Rotação
        float rotationY = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0f, rotationY, 0f));

        // Movimento
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize();

        // Pulo
        if (Input.GetButtonDown("Jump"))
        {
            
            isJumping = true;
            moveDirection.y = jumpForce;
        }

        // Aplica o movimento ao Character Controller
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Aplica a gravidade
        if (!controller.isGrounded)
        {
            print("Não está no chão");
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
            print(moveDirection.y);
        }
    }
    private bool IsGrounded()
    {
        Vector3 rayOrigin = transform.position + (Vector3.down * (controller.height * 0.5f));
        float rayDistance = controller.height * 0.5f + groundCheckDistance;
        return Physics.Raycast(rayOrigin, Vector3.down, rayDistance, groundLayer);
    }
}
