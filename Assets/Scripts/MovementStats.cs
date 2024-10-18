using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStats : ScriptableObject
{
    [Range(0f, 50f)]
    public float maxSpeed = 10f;
}
