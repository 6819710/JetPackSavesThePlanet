using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathCauseUpdater : MonoBehaviour {

	private Health playerHealth;
	private Text label;

	void Start () {
		playerHealth = GameObject.Find ("Player").GetComponent<Health> ();
		label = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerHealth.isDead){
			switch(playerHealth.KillingBlow){
				case Health.DamageType.Suffocation:
					label.text = "You ran out of oxygen";
					break;
				case Health.DamageType.Worm:
					label.text = "You got wrecked by the Worms ";
					break;
				case Health.DamageType.Explosion:
					label.text = "You blasted yourself";
					break;
				default:
					label.text = "You died!";
					break;
			}
		}
	}
}
