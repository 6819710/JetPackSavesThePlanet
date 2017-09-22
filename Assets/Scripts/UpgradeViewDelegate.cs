using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeViewDelegate : MonoBehaviour {

	public UpgradeSystem data;
	public GameObject holderPrefab;

	private List<GameObject> holders;


	void Start () {
		if(data==null){
			data = GameManager.instance.Player.GetComponent<UpgradeSystem> ().Bind (this);
		}
		initialiseUI ();
	}

	public void initialiseUI (){
		Clear ();
		int offsetY = 0;
		foreach(Upgrade u in data.Upgrades){
			GameObject holder = Instantiate (holderPrefab);
			UpgradeHolder uh = holder.GetComponent<UpgradeHolder> ();
			uh.Upgrade = u;
			Vector3 newPosition = this.transform.position;
			newPosition.y = offsetY++ * holder.GetComponent<RectTransform> ().rect.height;
			holder.transform.position = newPosition;
			holder.transform.SetParent (this.transform);
			holder.name = u.Name;
			holders.Add (holder);
		}
	}

	void Clear (){
		holders = new List<GameObject>();
	}
}
