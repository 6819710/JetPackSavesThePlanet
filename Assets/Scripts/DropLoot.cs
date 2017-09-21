using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {

	public LootTable lootTable;

	public LootTable loots {
		get { return lootTable; }
		set { lootTable = value; }
	}

	public void Drop () {
		if (lootTable!=null && lootTable.Count > 0) {
			for(int i = 0; i< lootTable.Keys.Count; i++){
				KeyValuePair<GameObject, float> row = lootTable[i];
				if (row.Key!= null && Random.value < row.Value) {
					Instantiate (row.Key, gameObject.transform.position,new Quaternion());
				}
			}
		}
	}

}
