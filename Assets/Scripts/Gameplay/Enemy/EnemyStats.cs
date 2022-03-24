using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private int Health = 10;

    public void Damage (AttackHitbox_Gen attack)
    {
        Health -= attack.DamageAmount;

        if (Health <= 0)
        {
            LifeDepleted();
            return;
        }
        //Stunlock
        GetComponent<EnemyMovement>().Knockback(attack);
    }

    private void LifeDepleted()
    {
        Time.timeScale = 0.2f;
        Invoke(nameof(DeactivateEnemy), 0.1f);
    }

    private void DeactivateEnemy()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        if(IsInvoking())
        {
            CancelInvoke();
        }
    }

    void OnEnable()
    {
        Health = 10;
    }
}
