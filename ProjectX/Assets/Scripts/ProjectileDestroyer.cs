using UnityEngine;
using System.Collections;

public class ProjectileDestroyer : MonoBehaviour {

	private Player player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.tag == "Projectile")
		{
			Destroy(col.gameObject);
		
			PlayLandingShoot ();
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag == "Projectile")
		{
			Destroy(col.gameObject);
			PlayLandingShoot ();
		}
	}

	void PlayLandingShoot()
	{
		GameObject playerGameObj = GameObject.Find("Player");
		player = playerGameObj.GetComponent<Player>();
		player.PlayLandingShoot ();
	}
		
}
