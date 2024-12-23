using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]

public class SC_PlayerMove : MonoBehaviour
{

    private SC_Status status;

    [SerializeField]
    private float moveSpeed;// 이동 속도
    private Vector3 moveForce;  // 이동 힘 (x, z와 y축을 별도로 계산해 실제 이동에 적용)

    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float coefficientGravity;

    private CharacterController characterController;  // 플레이어 이동 제어를 위한 컴포넌트

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
        // moveForce 속력으로 이동
        characterController.Move(moveForce * Time.deltaTime);
        if (!characterController.isGrounded) 
        {
            moveForce.y += coefficientGravity * Time.deltaTime;
        }
    }

    public void MoveTo(Vector3 direction)
    {
        // 이동 방향 = 캐릭터의 회전 값 * 방향 값
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        // 이동 힘 = 이동 방향 * 속도
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
