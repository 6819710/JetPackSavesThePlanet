using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(DestructableEntity))]
public class dropsLootOnDestruction : MonoBehaviour {

	private LootTable lootTable;
	private DestructableEntity entity;

	public LootTable loots {
		get { return lootTable; }
	}

	void OnEnable() {
		lootTable = new LootTable();
	}

	void Start () {
		entity = this.GetComponent<DestructableEntity> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(entity.IsDestroyed){
			if (lootTable.Count > 0) {
				for(int i = 0; i< lootTable.Keys.Count; i++){
					KeyValuePair<GameObject, float> row = lootTable[i];
					if (row.Key!= null && Random.value < row.Value) {
						Instantiate (row.Key, gameObject.transform.position,new Quaternion());
					}
				}
			}
		}
	}
}
