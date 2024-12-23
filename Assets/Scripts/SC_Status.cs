using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Status : MonoBehaviour
{
    [Header("Walk, Run, Speed, Jump, Gravity, MaxHp, CurrentHp")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int currentHp;

    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;
    public float JumpPower => jumpPower;

    public float Gravity => -gravity;

    public int MaxHp => maxHp;
    public int CurrentHp => currentHp;
}
