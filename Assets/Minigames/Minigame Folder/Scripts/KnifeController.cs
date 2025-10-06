using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        // Spawn the knife prefab
        GameObject spawnedKnife = Instantiate(prefab);

        // Place it at the same position as this weapon
        spawnedKnife.transform.position = transform.position;

        spawnedKnife.GetComponent<KnifeBehavior>().DirectionChecker(pm.lastMovedVector);
    }
}
