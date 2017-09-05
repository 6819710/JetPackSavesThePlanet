using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class SpeedUpgrade : TimelyRechargedUpgrade
{
	[SerializeField]
	private float magnitude = 1;

	public float Magnitude {
		get {
			return magnitude;
		}
		set {
			magnitude = value;
		}
	}
	
	public SpeedUpgrade (String name): base(name)
	{
	}

	public override void Effect ()
	{
		SwipeToMove sw = Owner.GetComponent<SwipeToMove> ();
		sw.speed *= magnitude;
	}
}
