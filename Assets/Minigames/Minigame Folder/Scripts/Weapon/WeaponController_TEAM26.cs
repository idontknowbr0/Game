using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController_TEAM26 : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;

    protected PlayerController_TEAM26 pm;

    protected virtual void Start()
    {
        pm = Object.FindFirstObjectByType<PlayerController_TEAM26>();
        currentCooldown = cooldownDuration; //At the start set the current cooldown to be the cooldown duration

    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime; //Decrease the current cooldown by the time since the last frame
        if(currentCooldown <= 0f){
            Attack();
        }
    }   

    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration; //Reset the current cooldown to be the cooldown duration
    }
}
