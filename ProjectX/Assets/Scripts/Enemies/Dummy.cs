using UnityEngine;

public class Dummy : BaseEnemy
{
    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        if (IsWalled())
        {
            isFacingLeft = !isFacingLeft;
            Flip();
        }

        Move();
    }

    // Check if entity collisions with a wall/ground
    private bool IsWalled()
    {
        bool isWalled = false;

        foreach (Transform wall in collisionCheck)
        {
            isWalled = Physics2D.OverlapCircle(wall.position, collisionCheckRadius, whatIsCollision);
            if (isWalled)
            {
                break;
            }
        }

        return isWalled;
    }
}
