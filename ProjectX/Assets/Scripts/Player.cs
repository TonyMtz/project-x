using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private int jumpForce;


    // Use this for initialization
    override public void Start()
    {
        base.Start();

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
            //base.Move();

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
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);

		}

        // Go Right
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);


		}

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

		//Stop walk animation
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			

		}

    }
}
