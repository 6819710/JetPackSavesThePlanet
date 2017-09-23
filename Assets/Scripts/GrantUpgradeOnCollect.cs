using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GrantUpgradeOnCollect : MonoBehaviour {

	public List<Upgrade> upgradesToGrant; 

	public List<string> canBeCollectedByEntitesTagged = new List<string> ();

	void OnCollisionEnter2D(Collision2D collision) {
		if (canBeCollectedByEntitesTagged.Contains (collision.gameObject.tag)) {
			//Grant Upgrade , If the reciever has an UpgradeSystem
			UpgradeSystem upSys = collision.gameObject.GetComponent<UpgradeSystem> ();
			if (upSys != null) { // if it's players
				foreach(Upgrade u in upgradesToGrant)
					upSys.Add(u);
			}
			//Destorys self once granted
			SelfDestruct();
		}
	}

	public void SelfDestruct(){
		Destroy (this.gameObject);
	}

}
