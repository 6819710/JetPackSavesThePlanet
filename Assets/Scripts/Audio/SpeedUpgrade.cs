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
		Rigidbody2D rb = Owner.GetComponent<Rigidbody2D> ();
		ParticleSystem ps = Owner.transform.Find("jetpack").GetComponent<ParticleSystem> (); // TODO : remove hardcoded value
		rb.AddForce(rb.velocity * magnitude);
		ParticleSystem.EmitParams ep = new ParticleSystem.EmitParams ();
		ep.startColor = Color.red;
		ps.Emit(ep,(int) Magnitude);
	}
}
