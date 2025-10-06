using UnityEngine;
using UnityEngine.InputSystem;

/*
    This is an example script part of the debug minigame

    The purpose of it is to show you how to properly deal with input
    and use the provided MinigameManager.cs class
*/

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))] // This component must be attached to the GameObject for input to register
public class PlayerController_TEAM26 : MonoBehaviour, MinigameSubscriber
{
    private Rigidbody2D rb;

    // 👇 Add this public variable so KnifeController can read the direction
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    public Vector2 lastMovedVector;
    [HideInInspector]
    
    void Start()
    {
        MinigameManager.Subscribe(this);
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    void OnInteract(InputValue val)
    {
        if (!MinigameManager.IsReady())
            return;

        MinigameManager.SetStateToSuccess();
        MinigameManager.EndGame();
    }

    // In PlayerController_TEAM26.cs

void OnMove(InputValue val)
{
    if (!MinigameManager.IsReady())
        return;

    // Get the movement vector from the input system
    moveDir = val.Get<Vector2>();

    // Apply movement to the character
    rb.linearVelocity = moveDir * 5f;

    // --- Sprite Flipping Logic ---
    // This part correctly flips the sprite left or right
    if (moveDir.x > 0)
    {
        transform.localScale = new Vector3(2, 2, 2);
    }
    else if (moveDir.x < 0)
    {
        transform.localScale = new Vector3(-2, 2, 2);
    }

    // --- Store the Last Movement Direction (Corrected Logic) ---
    // We check if the player is providing any input at all.
    // This single 'if' statement replaces all the complex ones.
    if (moveDir.sqrMagnitude > 0.01f)
    {
        // If they are moving, we store that direction.
        // This works for horizontal, vertical, and diagonal movement.
        lastMovedVector = moveDir.normalized;
    }
}
    void InputManagement(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;

        if(moveDir.x != 0){
            lastHorizontalVector = moveDir.x;
            lastMovedVector= new Vector2(lastHorizontalVector, 0f);
        }
        if(moveDir.y != 0){
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if(moveDir.x!=0 && moveDir.y !=0){
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if(moveX!=0 && moveY !=0){
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    public void OnMinigameStart()
    {
        Debug.Log("Minigame started!");
    }

    public void OnTimerEnd()
    {
        MinigameManager.SetStateToFailure();
        MinigameManager.EndGame();
    }
}
