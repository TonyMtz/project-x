using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text hpText;
	public Character character;


	void Update () {

		string currentHP = character.getCurrentHealthPoints ().ToString ();
		string maxHP = character.getMaxHealthPoints ().ToString ();

		hpText.text = "HP: "+ currentHP+"/"+maxHP;
	}
}
