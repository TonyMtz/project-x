using UnityEngine;

public abstract class BaseEnemy : BaseCharacter
{
    [SerializeField]
    protected Transform[] collisionCheck;

    [SerializeField]
    protected float collisionCheckRadius;

    [SerializeField]
    protected LayerMask whatIsCollision;


    // Use this for initialization
    override public void Start()
    {
        base.Start();
        isFacingLeft = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            DecreaseHP(1);
			GameObject hit_fx =
				Instantiate(Resources.Load("FX/Hit_FX"),
					transform.position,
					Quaternion.identity) as GameObject;
			
            if (getCurrentHealthPoints() <= 0)
            {
                //Increment exp points on Player
                GameObject getPlayer = GameObject.FindGameObjectWithTag("Player");
                Player hero = getPlayer.GetComponent<Player>();
                hero.increaseExperiencePoints(getExperiencePoints());

				int rand = Random.Range (0, 2);
				string explosion = "FX/Explosion_FX";
				if (rand == 1)
					explosion = "FX/Explosion2_FX";
					

				GameObject explosion_fx =
					Instantiate(Resources.Load(explosion),
						transform.position,
						Quaternion.identity) as GameObject;

                Destroy(this.gameObject);
            }
        }
    } 
}
