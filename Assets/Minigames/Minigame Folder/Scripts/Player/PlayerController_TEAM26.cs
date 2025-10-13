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

    // Direction and movement tracking
    public float moveSpeed = 5f;
    public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    [HideInInspector] public Vector2 moveDir;
    public Vector2 lastMovedVector;

    void Start()
    {
        // Subscribes this class to the minigame manager. This gives access to the
        // 'OnMinigameStart()' and 'OnTimerEnd()' functions. Otherwise, they won't be called.
        MinigameManager.Subscribe(this);
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    void OnMove(InputValue val)
    {
        if (!MinigameManager.IsReady()) // IMPORTANT: Don't allow any input while the countdown is still occuring
            return;

        // Get the movement vector from the input system
        moveDir = val.Get<Vector2>();

        // Apply movement to the character
        rb.linearVelocity = moveDir * moveSpeed;

        // --- Sprite Flipping Logic ---
        if (moveDir.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        // --- Store the Last Movement Direction ---
        if (moveDir.sqrMagnitude > 0.01f)
        {
            lastMovedVector = moveDir.normalized;
        }
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if (moveX != 0 && moveY != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void OnInteract(InputValue val)
    {
        if (!MinigameManager.IsReady()) // IMPORTANT: Don't allow any input while the countdown is still occuring
            return;

        MinigameManager.SetStateToSuccess(); // Change the minigame state to "Success"
        MinigameManager.EndGame(); // End the minigame. Without this, the minigame would end when the timer finishes instead (still with success).
    }

    public void OnMinigameStart()
    {
        Debug.Log("Minigame started!");
        // There isn't anything interesting that needs to happen in here for this example
    }

    public void OnTimerEnd()
    {
        // Timer has expired
        MinigameManager.SetStateToFailure();
        MinigameManager.EndGame();
    }
}
