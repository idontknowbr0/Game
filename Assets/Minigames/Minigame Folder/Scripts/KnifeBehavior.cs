using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehavior : ProjectileWeaponBehavior
{
    KnifeController kc;
    protected override void Start()
    {
        base.Start();
        kc = Object.FindFirstObjectByType<KnifeController>();
    }
    void Update()
    {
        transform.position += direction * kc.speed * Time.deltaTime;
    }
}
