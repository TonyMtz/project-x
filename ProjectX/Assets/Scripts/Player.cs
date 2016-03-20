using UnityEngine;
using UnityEngine.UI;

public class Player : BaseCharacter
{
    [SerializeField]
    private int jumpForce;

	private string hpText;
	private string expText;
	public GameObject projectile;
	public float bulletSpeed;
	private int exp;


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
			isFacingLeft = true;

		}

        // Go Right
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);

			animator.SetInteger("Speed", 1);
			isFacingLeft = false;

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

		//Shoot projectile
		if (Input.GetKeyDown(KeyCode.Z))
		{
			
			if (isFacingLeft) {
				Vector3 firePosition = new Vector3 (transform.position.x-1.5f, transform.position.y-1, 0);
				GameObject bPrefab = Instantiate(projectile, firePosition, Quaternion.identity) as GameObject;
				bPrefab.GetComponent<Rigidbody2D>().AddForce (Vector3.left * bulletSpeed);
			} else {
				Vector3 firePosition = new Vector3 (transform.position.x+1.5f, transform.position.y-1, 0);
				GameObject bPrefab = Instantiate(projectile, firePosition, Quaternion.identity) as GameObject;
				bPrefab.GetComponent<Rigidbody2D>().AddForce (Vector3.right * bulletSpeed);
			}
				
		}

    }

	//Handle Enemy contact
	void OnCollisionEnter2D(Collision2D coll)
	{
		//Contact with enemy
		if(coll.gameObject.tag == "Enemy")
		{
			//TODO: instead of hardcoded value (1), get the collision object attack and pass it as parameter.
			DecreaseHP (1);
		}

		//Checks if the hero has no hp
		if (getCurrentHealthPoints () <= 0) {
			//TODO: Show Game over screen
			gameObject.SetActive(false);

		}

		HandleHPText();
	}

	public void HandleHPText()
	{
		hpText = "HP: " + getCurrentHealthPoints () + "/" + getMaxHealthPoints ();
		expText = "EXP: " + getExperiencePoints ();
	}

	void OnGUI (){

		GUIStyle style = new GUIStyle ();
		style.normal.textColor = Color.red;
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;

		GUI.Label (new Rect(20,20,100,100), hpText,style);

		style.normal.textColor = Color.green;
		GUI.Label (new Rect(20,50,100,100), expText,style);

	}
}
