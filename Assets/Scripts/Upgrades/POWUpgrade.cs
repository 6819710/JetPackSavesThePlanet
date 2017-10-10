using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class POWUpgrade : ConsumableUpgrade {

	[SerializeField] private float radius = 5;

	public override void Activate ()
	{
		base.Activate ();
	}

	public POWUpgrade (string name): base(name)
	{
	}

	public override void Effect ()
	{
		Debug.Log ("POW ACTIVATED!");
		Restore ();
	}
}
