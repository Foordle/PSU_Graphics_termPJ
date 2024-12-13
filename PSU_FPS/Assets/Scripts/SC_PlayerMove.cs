using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class SC_PlayerMove : MonoBehaviour
{

    private SC_Status status;

    [SerializeField]
    private float moveSpeed;// �̵� �ӵ�
    private Vector3 moveForce;  // �̵� �� (x, z�� y���� ������ ����� ���� �̵��� ����)

    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float coefficientGravity;

    private CharacterController characterController;  // �÷��̾� �̵� ��� ���� ������Ʈ

    public float SetMoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }
    private void Awake()
    {
        status = GetComponent<SC_Status>();
        characterController = GetComponent<CharacterController>();
        jumpPower = status.JumpPower;
        coefficientGravity = status.Gravity;
    }

    private void Update()
    {
        // moveForce �ӷ����� �̵�
        characterController.Move(moveForce * Time.deltaTime);
        if (!characterController.isGrounded) 
        {
            moveForce.y += coefficientGravity * Time.deltaTime;
        }
    }

    public void MoveTo(Vector3 direction)
    {
        // �̵� ���� = ĳ������ ȸ�� �� * ���� ��
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        // �̵� �� = �̵� ���� * �ӵ�
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if (characterController.isGrounded)
        {
            moveForce.y = jumpPower;
        }
    }

}
