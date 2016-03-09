using UnityEngine;
using System.Collections;

public class EnemyUIController : MonoBehaviour {

	public TextMesh EnemyHP;
	public Character Enemy;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string enemyCurrentHP=Enemy.getCurrentHealthPoints ().ToString ();
		string enemyMaxHP = Enemy.getMaxHealthPoints ().ToString ();
		EnemyHP.text = "HP: " + enemyCurrentHP+"/"+enemyMaxHP;
	}
}
