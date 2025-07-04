using UnityEngine;
using System.Collections;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of the chicken movement
    public float minMoveTime = 1f; // Minimum time before pausing
    public float maxMoveTime = 3f; // Maximum time before pausing
    public float minWaitTime = 1f; // Minimum wait time before changing direction after stopping
    public float maxWaitTime = 3f; // Maximum wait time before changing direction after stopping
    public float pushForce = 2f; // How strong the chicken gets pushed by the player
    public float linearDrag = 5f; // Linear drag to make the chicken stop moving after being pushed

    public AudioClip animalSound;
    public float minSoundInterval = 3f;
    public float maxSoundInterval = 8f;

    private Vector3 targetDirection;
    private bool isMoving = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set linear drag on the Rigidbody2D
        rb.linearDamping = linearDrag;

        // Start the first random movement direction
        SetNewTargetDirection();

    }

    void Update()
    {
        if (isMoving)
        {
            MoveChicken();
            FlipChicken(); // Flip the chicken based on movement direction
        }
    }

    private void SetNewTargetDirection()
    {
        // Set a random direction (X or Y axis)
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        targetDirection = new Vector3(randomX, randomY, 0).normalized;

        // Start the movement with a random amount of time
        float moveTime = Random.Range(minMoveTime, maxMoveTime);
        StartCoroutine(MoveAndPause(moveTime));
    }

    private void MoveChicken()
    {
        // Move the chicken in the target direction
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }

    private IEnumerator MoveAndPause(float moveTime)
    {
        // Start moving the chicken
        isMoving = true;

        // Move for a random amount of time
        yield return new WaitForSeconds(moveTime);

        // Stop moving and wait for a random amount of time before changing direction
        isMoving = false;

        // Wait for a random time before moving again
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        // After waiting, set a new direction and continue
        SetNewTargetDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the chicken, push the chicken
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the direction of the push (away from the player)
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;

            // Apply a force to push the chicken away from the player
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

            PlayAnimalSound();
        }
    }

    private void FlipChicken()
    {
        // If the chicken is moving to the right, flip to face right
        if (targetDirection.x < 0)
        {
            // Flip to right
            spriteRenderer.flipX = false;
        }
        // If the chicken is moving to the left, flip to face left
        else if (targetDirection.x > 0)
        {
            // Flip to left
            spriteRenderer.flipX = true;
        }
    }


    private void PlayAnimalSound()
    {
        if (animalSound != null)
        {
            audioSource.PlayOneShot(animalSound);
        }
    }
}
