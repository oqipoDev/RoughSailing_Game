using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Gen : MonoBehaviour
{
    //todo Probably will use patterns on other systems. Watch out!
    public enum AtkMovePatterns {Linear, EaseOut, EaseIn}

    [Header("Damage")]
    //TODO include only in classes that use it
    public int Strenght = 2;
    public float StunTime = 0.25f,
                Knockback = 1;

    [Header("Movement")]
    public float MoveForward = 1;
    public AtkMovePatterns MovePattern = AtkMovePatterns.Linear;

    [Header("Timing")]
    public float Time_Telegraph = 1f,
                Time_Attack = 0.5f,
                Time_Recovery = 0.5f;
}
