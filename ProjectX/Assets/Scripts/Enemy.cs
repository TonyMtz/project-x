using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    private Transform[] wallCheck;

    [SerializeField]
    private float wallCheckRadius;

    [SerializeField]
    private LayerMask whatIsWall;

    // Use this for initialization
    override public void Start()
    {
        base.Start();
        isFacingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

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

        foreach (Transform wall in wallCheck)
        {
            isWalled = Physics2D.OverlapCircle(wall.position, wallCheckRadius, whatIsWall);
            if (isWalled)
            {
                break;
            }
        }

        return isWalled;
    }
}
