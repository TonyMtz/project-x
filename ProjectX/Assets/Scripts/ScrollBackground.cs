using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

	public float speed=0.005f;
	Vector2 offset;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Move horizontally
		//Vector2 offset = new Vector2(Time.time*speed, 0);

		//Move vertically
		//Vector2 offset = new Vector2 (0,Time.time * speed);



	}

	public void MoveBackgroundToRight(float pos)
	{
		offset = new Vector2(pos*speed, 0);
		Move (offset);
	}

	public void MoveBackgroundToLeft(float pos)
	{
		offset = new Vector2(pos*-speed, 0);
		Move (offset);
	}

	void Move(Vector2 offset)
	{
		GetComponent<Renderer>().material.mainTextureOffset = offset;﻿
	}

}
