using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class LootTable : ScriptableObject {
	
	[SerializeField] private List<GameObject> keys = new List<GameObject>();
	[SerializeField] private List<float> values = new List<float>();

	public  List<GameObject> Keys {
		get { return keys; } 
	}

	public int Count {
		get { return keys.Count; } 
	}

	public KeyValuePair<GameObject, float> this[int index]
	{
		get { 
			return new KeyValuePair<GameObject, float>(keys[index], values [index]);
		}
		set{
			keys.Add (null);
			values.Add (0f);
		}
	}

	public float this[GameObject key]
	{
		get { 
			if (keys.Contains(key)) {
				int i = keys.IndexOf (key);
				return values [i];
			}
			return 0f;
		}
		set { Add (key, (float) value); }
	}

	public bool ContainsKey(GameObject key) {
		return keys.Contains(key);
	}

	public void Add(GameObject key, float value) {
		if (!keys.Contains(key)) {
			keys.Add(key);
			values.Add(value);
		}
	}

	public void Add(int index, GameObject key, float value) {
		if (index < keys.Count) {
			keys [index] = (key);
			values [index] = (value);
		} else {
			keys.Add (key);
			values.Add (value);
		}
	}

	public void Remove(GameObject key) {
		if (keys.Contains(key)) {
			int index = keys.IndexOf (key);
			values.RemoveAt (index);
			keys.RemoveAt (index);
		}
	}

	public void Remove(int index) {
		if (keys.Count > (index) && index > 0) {
			values.RemoveAt (index);
			keys.RemoveAt (index);
		}
	}

	public void Clear(){
		keys = new List<GameObject>();
		values = new List<float>();
	}

	public void SetChance(GameObject of, float to){
		int index = keys.IndexOf (of);
		if(index>0){
			values [index] = to;
		}
	}

	public void SetLootAt(int index, GameObject to){
		if(index>= 0 && keys.Count > index){
			keys [index] = to;
		}
	}

	public void SetLootAt(int index, GameObject to, float chance){
		if(index>= 0 && keys.Count > index){
			keys [index] = to;
			values [index] = chance;
		}
	}


}
