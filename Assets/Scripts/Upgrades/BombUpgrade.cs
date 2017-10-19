using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu]
public class BombUpgrade : ConsumableUpgrade {
	
	public GameObject bombPrefab;
	public float damageRadius = 1;

	public BombUpgrade (string name): base(name)
	{
	}

	public override void Effect ()
	{
		Instantiate (bombPrefab, Owner.transform.position, new Quaternion());
		Restore ();
	}
}
