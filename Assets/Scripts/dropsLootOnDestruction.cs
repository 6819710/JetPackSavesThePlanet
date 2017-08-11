using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(DestructableEntity))]
public class dropsLootOnDestruction : MonoBehaviour {

	public LootTable lootTable;

	private DestructableEntity entity;
	// Use this for initialization

	void Start () {
		entity = this.GetComponent<DestructableEntity> ();
		lootTable = new LootTable();
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
