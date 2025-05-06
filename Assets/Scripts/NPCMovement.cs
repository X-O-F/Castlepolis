using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minMoveTime = 5f;
    public float maxMoveTime = 8f;

    private Vector3 targetDirection;
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetNewTargetDirection();
    }

    void Update()
    {
        MoveNPC();
    }

    private void SetNewTargetDirection()
    {
        // Choose random direction
        int dir = Random.Range(0, 4);
        switch (dir)
        {
            case 0: targetDirection = Vector3.right; break;  // Right
            case 1: targetDirection = Vector3.left; break;   // Left
            case 2: targetDirection = Vector3.up; break;     // Up
            case 3: targetDirection = Vector3.down; break;   // Down
        }

        // Randomize move time for each direction change
        float moveTime = Random.Range(minMoveTime, maxMoveTime);
        StartCoroutine(ChangeDirection(moveTime));
    }

    private void MoveNPC()
    {
        transform.position += targetDirection * moveSpeed * Time.deltaTime;

        int moveX = Mathf.RoundToInt(targetDirection.x);
        int moveY = Mathf.RoundToInt(targetDirection.y);
        Debug.Log("move Y:" + moveY);

        if (animator != null)
        {
            animator.SetFloat("MoveX", moveX);
            animator.SetFloat("MoveY", moveY);
        }
    }

    private IEnumerator ChangeDirection(float moveTime)
    {
        // Wait for the moveTime duration before changing direction
        yield return new WaitForSeconds(moveTime);

        // After the time is up, change direction
        SetNewTargetDirection();
    }
}
