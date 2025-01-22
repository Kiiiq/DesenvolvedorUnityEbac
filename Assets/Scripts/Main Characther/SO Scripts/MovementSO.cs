using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MovementSO : ScriptableObject
{
    [Header("\n\nSpeed")]
    [SerializeField]

    public float actualSpeedx;
    public float actualSpeedy;
    public float Speed = 5;

    [Header("\n\nJump")]

    public float JumpDistance = 10;
    public float jumpTime = 5;
    public float Gravity = 10;
    public float SpareJumpTime;

    [Header("\n\nDash")]

    public float DashingMultipliyer;
    public float DashDuration;
    public float ShadowDashCD;

}
