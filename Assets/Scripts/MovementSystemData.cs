using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementSystemData", menuName = "Systems/MovementSystemData")]
public class MovementSystemData : ScriptableObject
{
    public float Speed;
    public Vector2 Amplitude;
}
