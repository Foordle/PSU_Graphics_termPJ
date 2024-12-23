using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Status : MonoBehaviour
{
    [Header("Walk, Run, Speed, Jump, Gravity")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float gravity;

    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;
    public float JumpPower => jumpPower;

    public float Gravity => -gravity;
}
