﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class POWUpgrade : ConsumableUpgrade {

	[SerializeField] private float radius = 5;

	public POWUpgrade (string name): base(name)
	{
	}


	public override void Effect ()
	{
		Owner.transform.Find ("pow").GetComponent<Animator> ().SetTrigger ("Activate");
		GameObject.Find ("SFX").GetComponent<SFXControler> ().playPOW();
		GameObject player = GameManager.instance.Player;
		List<SpawnableObject> toDestroy = GameManager.instance.Director.GetComponent<AsteroidSpawner> ().InScreen;
		foreach(SpawnableObject so in toDestroy){
			Asteroid a = so.gameObject.GetComponent<Asteroid> ();
			if (a != null) { // If the spawnable object is an asteroid 
				a.Split (a.gameObject.transform.position - player.transform.position);
				a.Destruct ();
			}
		}
		Restore ();
	}

}
