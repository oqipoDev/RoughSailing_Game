using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
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
        //Activate stunlock
        GetComponent<PlayerControl>().StunlockPlayer(attack);
    }

    private void LifeDepleted()
    {
        Debug.Log("De hevy is ded");
    }
}
