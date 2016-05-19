using UnityEngine;
using UnityEngine.UI;

public class Player : BaseCharacter
{
    [SerializeField]
    private float jumpForce;

    private string hpText;
    private string expText;
    private string lvlText;
    public GameObject projectile;
    public float bulletSpeed;

    private AudioSource audioSource;

    public float volume;

    public AudioClip jumpSound;
    public AudioClip takeHitSound;
    public AudioClip LevelUpSound;
    public AudioClip shootProjectileSound;
    public AudioClip landingHit;

    private int oldExp;

	float barDisplay = 0;
	Vector2 pos= new Vector2(20,40);
	Vector2 size = new Vector2(100,20);
	 public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.right * getVelocity() * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);

            animator.SetInteger("Speed", -1);
            isFacingLeft = true;
			GameObject getBackground = GameObject.Find ("Background");
			ScrollBackground bg = getBackground.GetComponent<ScrollBackground>();
			//bg.MoveBackgroundToLeft (-transform.position.x);
        }

        // Go Right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * getVelocity() * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);

            animator.SetInteger("Speed", 1);
            isFacingLeft = false;

			GameObject getBackground = GameObject.Find ("Background");
			ScrollBackground bg = getBackground.GetComponent<ScrollBackground>();
			//bg.MoveBackgroundToRight (transform.position.x);
        }

	

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
			animator.Play("PlayerJump");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			secondJump = true;
            PlayJumpSound();

		
        }
		//double jump
		if (Input.GetKeyDown(KeyCode.Space) && secondJump && !IsGrounded())
		{
			animator.Play("PlayerJump");
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			secondJump = false;
			GameObject myChildObject = GameObject.Find ("Weapon");
			myChildObject.transform.parent = transform;
			myChildObject.transform.localPosition = new Vector2 (myChildObject.transform.localPosition.x, -0.45f);

		}
			

        //Stop walk animation
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.Play("PlayerIdle");
            animator.SetInteger("Speed", 0);

        }

        //Shoot projectile
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayShootProjectileSound();

            int modifier = isFacingLeft ? -1 : 1;
            Vector2 forceVector = isFacingLeft ? Vector2.left : Vector2.right;

            Vector3 firePosition = new Vector3(transform.position.x + (1.5f * modifier), transform.position.y - 0.75f, 0);
            GameObject bPrefab = Instantiate(projectile, firePosition, Quaternion.identity) as GameObject;
            bPrefab.GetComponent<Rigidbody2D>().AddForce(forceVector * bulletSpeed);
        }

		if (IsGrounded ()) {
			WeaponDown ();
		} else {
			WeaponUp ();
		}

    }

	void WeaponUp()
	{
		GameObject myChildObject = GameObject.Find ("Weapon");
		myChildObject.transform.parent = transform;
		myChildObject.transform.localPosition = new Vector2 (myChildObject.transform.localPosition.x, -0.45f);

	}

	void WeaponDown()
	{
		GameObject myChildObject = GameObject.Find("Weapon");
		myChildObject.transform.parent = transform;
		myChildObject.transform.localPosition = new Vector2(myChildObject.transform.localPosition.x,-0.69f);
	}

    //Handle Enemy contact
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Contact with enemy
        if (coll.gameObject.tag == "Enemy")
        {
            //get the collision object attack and pass it as parameter.
            GameObject getEnemy = coll.gameObject;
            BaseEnemy enemy = getEnemy.GetComponent<BaseEnemy>();
            PlayTakeHitSound();
			DecreaseHP(enemy.getAttackPoints());
			animator.Play("PlayerHit");
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));

			GameObject hit_fx =
				Instantiate(Resources.Load("FX/Hit_FX"),
					transform.position,
					Quaternion.identity) as GameObject;

        }

        //Checks if the hero has no hp
        if (getCurrentHealthPoints() <= 0)
        {
            //TODO: Show Game Over screen
			GameObject menu = (GameObject)Resources.Load("Menu",typeof(GameObject));
			GameObject menuPrefab = Instantiate(menu, new Vector2(0,0), Quaternion.identity) as GameObject;
            gameObject.SetActive(false);

		

        }

        HandleHPText();
    }

    public void HandleHPText()
    {
        //hpText = "HP: " + getCurrentHealthPoints() + "/" + getMaxHealthPoints();
        lvlText = "Lvl: " + getLevel();
        ManageExperience();

    }

    void OnGUI()
    {

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 30;
        style.fontStyle = FontStyle.Bold;

        //GUI.Label(new Rect(20, 20, 100, 100), hpText, style);

        style.normal.textColor = Color.green;
        GUI.Label(new Rect(20, 50, 100, 100), lvlText, style);

        style.normal.textColor = Color.cyan;
        GUI.Label(new Rect(20, 80, 100, 100), expText, style);


    }

    void ManageExperience()
    {
        int currentExp = getExperiencePoints();
        expText = "EXP: " + currentExp;

		int curLevel = getLevel ();
        //Example level-exp ratio
        if (oldExp != currentExp)
        {

            if (currentExp >= 1000 && currentExp <= 1999)
            {
				if(curLevel!=2)
                	LevelUp(2);
            }
            if (currentExp >= 2000 && currentExp <= 2999)
            {
				if(curLevel!=3)
                LevelUp(3);
            }
            if (currentExp >= 3000 && currentExp <= 3999)
            {
				if(curLevel!=4)
                LevelUp(4);
            }
            if (currentExp >= 5000 && currentExp <= 5999)
            {
				if(curLevel!=5)
                LevelUp(5);
            }
            if (currentExp >= 6000 && currentExp <= 6999)
            {
				if(curLevel!=6)
                LevelUp(6);
            }
            if (currentExp >= 7000 && currentExp <= 7999)
            {
				if(curLevel!=7)
                LevelUp(7);
            }
            if (currentExp >= 8000 && currentExp <= 8999)
            {
				if(curLevel!=8)
                LevelUp(8);
            }
            if (currentExp >= 10000 && currentExp <= 10999)
            {
				if(curLevel!=9)
                LevelUp(9);
            }
            if (currentExp >= 20000 && currentExp <= 20999)
            {
				if(curLevel!=10)
                LevelUp(10);

            }
            oldExp = currentExp;

        }


    }

    void LevelUp(int val)
    {
        setLevel(val);
		jumpForce += 100;
        PlayLevelUpSound();
    }

    void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound, volume);
    }

    void PlayTakeHitSound()
    {
        audioSource.PlayOneShot(takeHitSound, volume);
    }

    void PlayLevelUpSound()
    {
        audioSource.PlayOneShot(LevelUpSound, volume);
    }

    void PlayShootProjectileSound()
    {
        audioSource.PlayOneShot(shootProjectileSound, volume);
    }

    public void PlayLandingShoot()
    {
        audioSource.PlayOneShot(landingHit, volume);
    }


}
