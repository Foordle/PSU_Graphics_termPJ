using UnityEngine;

public class SC_UserMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;

    [SerializeField]
    private LayerMask groundLayer; // �ٴ� ���̾� ����

    public Camera playerCamera;
    private Rigidbody rb;
    private bool isGrounded;

    private float lookSensitivity = 2f;
    private float pitch = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody�� �߰����� �ʾҽ��ϴ�. Rigidbody�� �߰��ϼ���.");
        }
    }

    void Update()
    {
        MovePlayer();
        LookAround();
        Jump();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 newPosition = rb.position + move;
        rb.MovePosition(newPosition);
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // �÷��̾��� ��ġ �Ʒ��� Ray�� �߻��Ͽ� �ٴ� ����
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
