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

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Projectile")
		{
			DecreaseHP (1);
			if (getCurrentHealthPoints() <= 0) {
				GameObject getPlayer = GameObject.FindGameObjectWithTag("Player");
				Player hero= getPlayer.GetComponent<Player>();
				hero.increaseExperiencePoints (getExperiencePoints ());
				Debug.Log (hero.getExperiencePoints ());
				Destroy (this.gameObject);
			}
		}
	}
}
