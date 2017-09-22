using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour {

	public List<Upgrade> upgrades;

	private UpgradeViewDelegate _delegate;

	public List<Upgrade> Upgrades {
		get {
			return upgrades;
		}
		set {
			upgrades = value;
		}
	}

	public Upgrade this[int index]    
	{  
		get { return upgrades[index]; }
	}  

	public Upgrade this[Upgrade type]{
		get{
			foreach (Upgrade u in upgrades) {
				if (u==type) {
					return u;
				}
			}
			return null;
		}
	}

	void Start(){
		List<Upgrade> dupedList = new List<Upgrade>();
		foreach(Upgrade u in upgrades){
			Upgrade duped = Object.Instantiate (u) as Upgrade;
			duped.Owner = this.gameObject;
			dupedList.Add (duped);
		}
		upgrades.Clear ();
		upgrades = dupedList;
	}

	void Update () {
		foreach(Upgrade u in Upgrades){
			if(u is ITimable){
				ITimable timeUpgrade = u as ITimable;
				timeUpgrade.Process (Time.deltaTime);
			}
		}
	}

	public void Activate(Upgrade upgrade){
		upgrade.Activate ();
	}

	public bool Contains(Upgrade upgrade){
		foreach(Upgrade u in upgrades){
			if (u==upgrade) {
				return true;
			}
		}
		return false;
	}

	public void Add(Upgrade upgrade){
		upgrade.Owner = this.gameObject;

		//If the upgrade system doesnt have one of those upgrades 
		if (!this.Contains (upgrade)) {
			// It adds it
			upgrades.Add (upgrade);
		} else {
			// If it already has one 
			Upgrade toIncrease = this [upgrade];
			// Check if it is consumable,
			if(toIncrease is ConsumableUpgrade){
				// if so, add more users to it
				(toIncrease as ConsumableUpgrade).Uses++;
			}
			// Check if it is timable,
			if(toIncrease is ITimable){
				// if so, reset it's timer
				(toIncrease as ITimable).Stop();
			}
		}
	}

	public void Remove(Upgrade upgrade){
		upgrades.Remove (upgrade);
	}

	public void RemoveAt(int index){
		upgrades.RemoveAt (index);
	}

	public void Clear(){
		upgrades.Clear ();
	}

	public UpgradeSystem Bind(UpgradeViewDelegate holder){
		_delegate = holder;
		return this;
	}
}
