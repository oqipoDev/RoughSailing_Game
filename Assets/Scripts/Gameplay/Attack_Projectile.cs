using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Projectile : Attack_Gen
{
    [Header("Projectiles")]
    public GameObject ProjectileObject;
    
    [Tooltip("Object will appear at position and move forwards in z")]
    public Transform ProjectileOrigin;
    public uint ProjectileAmount = 1; //Unsigned
    public float ProjectileInterval = 0.5f;

    //Data
    private uint currentProj = 0; //Unsigned
    private float timeElapsed = 0;

    void OnEnable()
    {
        currentProj = 0;
        timeElapsed = ProjectileInterval;
    }
    
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if (timeElapsed >= ProjectileInterval)
        {
            //IMPORTANT: Script Assumes it's parented to character, who in turn is parented to local space.
            //Spawn projectile
            PoolManager.SpawnAt(ProjectileObject, ProjectileOrigin.position, ProjectileOrigin.rotation, transform.parent.parent);
            
            //End if we went thru all projectiles
            if(++currentProj >= ProjectileAmount)
                gameObject.SetActive(false);

            timeElapsed = 0;
        }
    }
}
