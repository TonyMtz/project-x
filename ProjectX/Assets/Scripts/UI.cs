using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text hpText;
	public Player hero;

	void Start () {
	
	}
	

	void Update () {

		string currentHP = hero.getCurrentHealthPoints ().ToString ();
		string maxHP = hero.getMaxHealthPoints ().ToString ();

		hpText.text = "HP: "+ currentHP+"/"+maxHP;
	}
}
