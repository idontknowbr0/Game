using UnityEngine;

public class ProjectileWeaponBehavior_TEAM26 : MonoBehaviour
{
    protected Vector3 direction;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }
}
