using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public GameObject prefab;
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    protected PlayerController pm;

    protected virtual void Start()
    {
        pm = Object.FindFirstObjectByType<PlayerController>();
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
