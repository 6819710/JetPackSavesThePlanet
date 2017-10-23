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
	private Rigidbody2D body;

	void Start(){
		animator = gameObject.GetComponent<Animator> ();
		body = gameObject.GetComponent<Rigidbody2D> ();
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
		if (canBeCollectedByEntitesTagged.Contains (collision.gameObject.tag)) {
			body.bodyType = RigidbodyType2D.Kinematic;
			//Grant Upgrade , If the reciever has an UpgradeSystem
			UpgradeSystem upSys = collision.gameObject.GetComponent<UpgradeSystem> ();
			if (upSys != null) { // if it's players
				if (!grantOneAtRandom) {
					foreach (Upgrade u in upgradesToGrant)
						upSys.Add (u);
				} else {
					upSys.Add (upgradesToGrant[Random.Range(0,upgradesToGrant.Count-1)]);
				}
			}
			animator.SetTrigger ("Collected");
		}
	}

	public void SelfDestruct(){
		Destroy (this.gameObject);
	}

}
