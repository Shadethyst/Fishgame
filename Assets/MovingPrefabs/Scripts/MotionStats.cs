using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MotionStats", menuName = "ScriptableObjects/MotionStats", order = 1)]
public class MotionStats : ScriptableObject
{
    [Range(1f, 100f)]
    public float acceleration = 40f;
    [Range(1f, 100f)]
    public float deceleration = 20f;
    [Range(0f, 100f)]
    public float maxSpeed = 20f;
    [Range(-100f, 0f)]
    public float minSpeed = -10f;
    [Range(0f, 1000f)]
    public float turnSpeed = 200f;
    [Range(0f, 200f)]
    public float dashSpeed = 60f;
    [Range(0f, 10f)]
    public float dashTime = 1f;
    [Range(0f, 100f)]
    public float dashCooldown = 5f;
}
