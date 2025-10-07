using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    PlayerController pc;
    SpriteRenderer sr;

    void Start()
    {
        am = GetComponent<Animator>();
        pc = GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (pc.moveDir.x != 0 || pc.moveDir.y != 0)
        {
            am.SetBool("Move", true);

            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDirectionChecker()
    {
        if (pc.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
