using UnityEngine;

public class Player : Character
{
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    override public void Move()
    {
        // Player Movements
        if (gameController.HasGameStarted)
        {
            base.Move();

            animator.SetInteger("Speed", isFacingLeft ? -1 : 1);
            animator.SetBool("Jumping", !IsGrounded());
        }
    }

    private void HandleInput()
    {
        // Start Game
        if (!gameController.HasGameStarted && Input.anyKey)
        {
            gameController.HasGameStarted = true;
        }

        // Go Left
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isFacingLeft)
            {
                return;
            }
            isFacingLeft = true;
            Flip();
        }

        // Go Right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!isFacingLeft)
            {
                return;
            }
            isFacingLeft = false;
            Flip();
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
        }
    }
}
