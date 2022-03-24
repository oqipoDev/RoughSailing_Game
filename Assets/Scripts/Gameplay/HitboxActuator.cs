using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO replace this script entirely
public class HitboxActuator : MonoBehaviour
{
    public bool IsPlayer = false;
    public int DamageAmount = 2;
    public float KnockbackTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!IsPlayer && col.gameObject.tag == "Player")
        {
            //Damage player
            col.gameObject.GetComponent<PlayerStats>().Damage(GetComponent<AttackHitbox_Gen>());
            //Position
            Vector2 hitDirection = CalculateDirection(col.transform.localPosition, transform.parent.localPosition);
            //TODO Knockback
        }
        
        if (IsPlayer && col.gameObject.tag == "Enemy")
        {
            //Damage enemy
            //col.gameObject.GetComponent<EnemyStats>().Damage(DamageAmount);
            //Position
            Vector2 hitDirection = CalculateDirection(col.transform.localPosition, transform.parent.localPosition);
            //Knockback
            //col.gameObject.GetComponent<EnemyMovement>().Knockback(KnockbackTime,hitDirection);
        }
    }

    private Vector2 CalculateDirection(Vector3 to, Vector3 from)
    {
        return new Vector2(to.x, to.z) - new Vector2(from.x, from.z);
    }
}
