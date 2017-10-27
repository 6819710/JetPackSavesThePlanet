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
		Owner.transform.Find ("rockets").GetComponent<ParticleSystem> ().Clear ();
		Owner.transform.Find ("rockets").GetComponent<ParticleSystem> ().Play ();
		Owner.GetComponent<Thruster> ().enabled = false;
		Owner.GetComponent<Thruster> ().ParticlesEnabled(false);
		Array.ForEach(Owner.transform.Find ("rockets").GetComponents<AudioSource>(), x => x.Play());
		Owner.GetComponent<ClampSpeed> ().maxSpeed += magnitude;
	}

	public override void Restore(){
		Owner.transform.Find("rockets").GetComponent<ParticleSystem> ().Stop();
		Array.ForEach(Owner.transform.Find ("rockets").GetComponents<AudioSource>(), x => x.Stop());
		Owner.GetComponent<Thruster> ().enabled = true;
		Owner.GetComponent<ClampSpeed> ().maxSpeed -= magnitude;
		base.Restore ();
	}

	public void onCollect(int amount){
		this.Stop ();
	}


}
