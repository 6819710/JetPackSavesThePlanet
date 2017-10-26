using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class GrantUpgradeOnCollect : MonoBehaviour {

	public List<Upgrade> upgradesToGrant; 
	public bool grantOneAtRandom = true;
	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

	private Animator animator;
	private CrateSoundController sound;
	private Rigidbody2D body;
	private bool collected = false;

	void Start(){
		animator = gameObject.GetComponent<Animator> ();
		body = gameObject.GetComponent<Rigidbody2D> ();
		sound = gameObject.GetComponent<CrateSoundController> ();
		List<Upgrade> dupedList = new List<Upgrade>();
		foreach(Upgrade u in upgradesToGrant){
			Upgrade duped = Object.Instantiate (u) as Upgrade;
			duped.Owner = this.gameObject;
			dupedList.Add (duped);
		}
		upgradesToGrant.Clear ();
		upgradesToGrant = dupedList;

	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (!collected) {
			if (canBeCollectedByEntitesTagged.Contains (collision.gameObject.tag)) {
				GameManager.instance.GetComponent<TutorialManager> ().SetTrigger (TutorialManager.TutorialTriggers.PickupCollected);
				UpgradeSystem upSys = collision.gameObject.GetComponent<UpgradeSystem> ();
				//Grant Upgrade , If the reciever has an UpgradeSystem
				if (upSys != null) { // if it's players
					collected = true;
					sound.Collect ();
					body.bodyType = RigidbodyType2D.Kinematic;
					if (!grantOneAtRandom) {
						foreach (Upgrade u in upgradesToGrant)
							upSys.Add (u);
					} else {
						Upgrade toGrant = upgradesToGrant [Random.Range (0, upgradesToGrant.Count)];
						upSys.Add (toGrant);
					}
				}
				animator.SetTrigger ("Collected");
			}
			this.enabled = false;
		}
	}

	public void SelfDestruct(){
		Destroy (this.gameObject);
	}

}
