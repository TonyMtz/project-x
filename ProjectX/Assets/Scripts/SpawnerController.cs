using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	public GameObject dummy;

	// Use this for initialization
	void Start () {
		SpawnMobsEverySecond();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnMobsEverySecond(){
		InvokeRepeating("SpawnMobs", 2, 1F);
	}

	void SpawnMobs() {
		GameObject wreckClone = (GameObject) Instantiate(dummy, transform.position, transform.rotation);
	}
}
