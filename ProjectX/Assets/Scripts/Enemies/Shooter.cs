using UnityEngine;

public class Shooter : BaseEnemy
{
    [SerializeField]
    private float timeOut = 2f;

    private float time = 0f;

    private bool canMove = false;

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time > timeOut)
        {
            canMove = !canMove;
            time = 0f;
        }

        if (!canMove)
        {
            animator.SetBool("isRunning", false);
            return;
        }

        if (!IsNextWalkable())
        {
            isFacingLeft = !isFacingLeft;
            Flip();
        }

        animator.SetBool("isRunning", true);

        Move();
    }

    // Check if entity collisions with a wall/ground
    private bool IsNextWalkable()
    {
        bool isNextWalkable = false;

        Transform collisionChecker = collisionCheck[0];

        isNextWalkable = Physics2D.OverlapCircle(collisionChecker.position, collisionCheckRadius, whatIsCollision);

        return isNextWalkable;
    }
}
