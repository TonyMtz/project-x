using UnityEngine;
using System.Collections;

public class DestroyAfterCertainTime : MonoBehaviour {

	public float secondsAlive;
	public GameObject targetObject;

	// Use this for initialization
	void Start () {
		DestroyAfterSeconds(secondsAlive);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DestroyAfterSeconds(float seconds)
	{
		Destroy (targetObject, seconds);
	}
		
}
