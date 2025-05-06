using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minMoveTime = 5f;
    public float maxMoveTime = 8f;
    public float waitTimeOnFlip = 1f;

    private Vector3 targetDirection;
    private bool isMoving = false;
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
        if (isMoving)
        {
            MoveNPC();
        }
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

        float moveTime = Random.Range(minMoveTime, maxMoveTime);
        StartCoroutine(MoveAndPause(moveTime));
    }

    private void MoveNPC()
    {
        transform.position += targetDirection * moveSpeed * Time.deltaTime;

        // Set Animator parameters
        if (animator != null)
        {
            animator.SetFloat("MoveX", targetDirection.x);
            animator.SetFloat("MoveY", targetDirection.y);
        }
    }

    private IEnumerator MoveAndPause(float moveTime)
    {
        isMoving = true;

        yield return new WaitForSeconds(moveTime);

        isMoving = false;

        // Stop movement → reset Animator parameters
        if (animator != null)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }

        yield return new WaitForSeconds(waitTimeOnFlip);

        SetNewTargetDirection();
    }
}
