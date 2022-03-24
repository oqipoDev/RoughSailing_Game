using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool IsPlayer = false;
    [Tooltip("Controls how many characters it passes through before finishing")]
    public uint PassThru = 0;
    public int DamageAmount = 2;
    public float Speed = 2,
            StunTime = 0.25f,
            Knockback = 1;

    public GameObject startEffect,
                    endEffect;

    private uint PassedThru = 0;

    // Start is called before the first frame update
    void Start()
    {
        PassedThru = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
