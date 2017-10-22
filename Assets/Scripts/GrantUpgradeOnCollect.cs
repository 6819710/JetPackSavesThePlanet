using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class GrantUpgradeOnCollect : MonoBehaviour {

	public List<Upgrade> upgradesToGrant; 

	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

    public UnityEvent onCollect;

	void Start(){
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
			//Grant Upgrade , If the reciever has an UpgradeSystem
			UpgradeSystem upSys = collision.gameObject.GetComponent<UpgradeSystem> ();
			if (upSys != null) { // if it's players
				foreach(Upgrade u in upgradesToGrant)
					upSys.Add(u);
			}
            onCollect.Invoke();

            SelfDestruct();
		}
	}

	public void SelfDestruct(){
		Destroy (this.gameObject);
	}

}
