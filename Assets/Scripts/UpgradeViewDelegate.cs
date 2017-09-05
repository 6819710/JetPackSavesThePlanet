using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeViewDelegate : MonoBehaviour {

	public UpgradeSystem data;
	public GameObject holderPrefab;

	private List<GameObject> holders;


	void Start () {
		if(data==null){
			data = GameManager.instance.Player.GetComponent<UpgradeSystem> ();
		}
		initialiseUI ();
	}

	void initialiseUI (){
		Clear ();
		int offsetY = 0;
		foreach(Upgrade u in data.Upgrades){
			GameObject holder = Instantiate (holderPrefab);
			UpgradeHolder uh = holder.GetComponent<UpgradeHolder> ();
			uh.Upgrade = u;
			Vector3 newPosition = holder.transform.position;
			newPosition.y = offsetY++ * holder.GetComponent<RectTransform> ().rect.height;
			holder.transform.position = newPosition;
			holders.Add (holder);
		}
	}

	void Update () {
		
	}

	void Clear (){
		holders = new List<GameObject>();
	}
}
