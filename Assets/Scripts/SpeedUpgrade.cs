using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class SpeedUpgrade : RenewableUpgrade, ITimable, ISpammable, ICollectable
{
	
	[SerializeField] private float magnitude = 1;
	[SerializeField] public float rechargeFrequency = 1;
	[SerializeField] public float rechargeDelay = 0; 
	[SerializeField] public bool spamProtection = false;

	private float time = 0; 

	public SpeedUpgrade (String name): base(name)
	{
	}

	public float Magnitude {
		get { return magnitude; }
		set { magnitude = value; }
	}

	public float Frequency {
		get { return rechargeFrequency; }
		set { rechargeFrequency = value; }
	}

	public float Time {
		get { return time; }
		set { time = value; }
	}

	public float Delay {
		get { return rechargeDelay; }
		set { rechargeDelay = value;}
	}

	public bool isSpammable {
		get {
			return spamProtection;
		}
		set {
			spamProtection = value;
		}
	}

	public override bool isRenewable {
		get { return Time <= 0; }
	}

	public void Start(){
		Time += (Delay + Frequency);
	}

	public void Process(float deltaTime){
		if (!isRenewable)
			Time -= deltaTime;
		else
			if(Active) 
				Restore ();
	}

	public void Stop(){
		Time  = 0;
	}

	public override void Activate ()
	{
		base.Activate ();
		if (isSpammable || isRenewable) {	
			Time = Frequency;
		}
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

	public void onCollect(){
		this.Stop ();
	}


}
