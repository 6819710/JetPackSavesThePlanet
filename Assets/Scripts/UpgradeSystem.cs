using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour {

	public List<Upgrade> upgrades;
	public bool removeUsedUpUpgrades = true;

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
		List<Upgrade> toClear = null;
		foreach(Upgrade u in Upgrades){
			if(u is ITimable){
				ITimable timeUpgrade = u as ITimable;
				timeUpgrade.Process (Time.deltaTime);
			}
			if(removeUsedUpUpgrades && u is ConsumableUpgrade ){
				if((u as ConsumableUpgrade).isUsedUp && !u.Active){
					if (toClear == null)
						toClear = new List<Upgrade> ();
					toClear.Add (u);
				}
			}
		}
		if(toClear!=null && toClear.Count>0){
			foreach (Upgrade toRemove in toClear) {
				Upgrades.Remove (toRemove);
			}
			if(_delegate) _delegate.RefreshUI ();
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
			if(_delegate) _delegate.RefreshUI ();
		} else {
			// If it already has one 
			Upgrade toIncrease = this [upgrade];
			// Check if it is collectable,
			if(toIncrease is ICollectable){
				//If is, then perform collection logic
				(toIncrease as ICollectable).onCollect ();
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
