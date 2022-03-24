using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox_Gen : MonoBehaviour
{
    public bool IsPlayer = false;

    [InspectorName("Name (optional)")]public string atkName;
    //References
    //public HitboxActuator Hitbox;
    //Parameters
    public float TelegraphTime = 1;
    public float RecoveryTime = 0.5f;
    public int DamageAmount = 2;
    public float MoveForward = 1;
    public float StunTime = 0.2f;

    //ToDo: generalize so players use same script
    private void OnTriggerEnter(Collider col)
    {
        if (!IsPlayer && col.gameObject.tag == "Player")
        {
            //Damage player
            col.gameObject.GetComponent<PlayerStats>().Damage(this);
        }
        
        if (IsPlayer && col.gameObject.tag == "Enemy")
        {
            //Damage enemy
            col.gameObject.GetComponent<EnemyStats>().Damage(this);
        }
    }
}
