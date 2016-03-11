using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField]
    private int jumpForce;

	public string hpText;


    // Use this for initialization
    override public void Start()
    {
        base.Start();
		HandleHPText();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
		HandleHPText();
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

			animator.SetInteger("Speed", -1);


		}

        // Go Right
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);

			animator.SetInteger("Speed", 1);

		}

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

		//Stop walk animation
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			animator.Play ("PlayerIdle");
			animator.SetInteger("Speed", 0);


		}

    }

	//Handle Enemy contact
	void OnCollisionEnter2D(Collision2D coll)
	{
		//Contact with enemy
		if(coll.gameObject.tag == "Enemy")
		{
			DecreaseHP (1);
		}
		HandleHPText();
	}

	public void HandleHPText()
	{
		hpText = "HP: " + getCurrentHealthPoints () + "/" + getMaxHealthPoints ();
	}

	void OnGUI (){

		GUIStyle style = new GUIStyle ();
		style.normal.textColor = Color.red;
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;

		GUI.Label (new Rect(20,20,100,100), hpText,style);
	}
}
