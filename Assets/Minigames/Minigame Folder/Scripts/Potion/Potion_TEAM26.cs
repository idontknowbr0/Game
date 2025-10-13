using UnityEngine;

public class Potion_TEAM26 : MonoBehaviour
{
    private bool isCollected = false;
    public AudioSource pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isCollected) return;

        if (other.CompareTag("Player"))
        {
            isCollected = true;

            if (pickupSound != null)
            {
                pickupSound.Play();
            }

            // Tell the PlayerInventory that a potion was collected
            PlayerInventory_TEAM26 playerInventory = other.GetComponent<PlayerInventory_TEAM26>();
            if (playerInventory != null)
            {
                playerInventory.CollectPotion();
            }

            // Destroy the potion object
            Destroy(gameObject, 0.1f);
        }
    }
}
