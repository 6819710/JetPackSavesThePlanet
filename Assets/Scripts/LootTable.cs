using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootTable{
	
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
	}

	public object this[GameObject key]
	{
		get { 
			if (keys.Contains(key)) {
				int i = keys.IndexOf (key);
				return values [i];
			}
			return null;
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

	public void Remove(GameObject key) {
		if (keys.Contains(key)) {
			int index = keys.IndexOf (key);
			values.RemoveAt (index);
			keys.RemoveAt (index);
		}
	}


}
