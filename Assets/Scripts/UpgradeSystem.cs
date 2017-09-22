using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour {

	public List<Upgrade> upgrades;

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

	public void Add(Upgrade upgrade){
		upgrade.Owner = this.gameObject;
		upgrades.Add (upgrade);
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
}
