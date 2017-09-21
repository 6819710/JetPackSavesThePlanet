using System;
using UnityEngine;

[System.Serializable]
public abstract class TimelyRechargedUpgrade : RenewableUpgrade 
{

	[SerializeField]
	public float rechargeFrequency = 1;

	[SerializeField]
	public float rechargeDelay = 0; 

	[SerializeField]
	public bool spamProtection = false;

	private float time = 0; 

	public float Frequency {
		get {
			return rechargeFrequency;
		}
		set {
			rechargeFrequency = value;
		}
	}

	public float Time {
		get {
			return time;
		}
		set {
			time = value;
		}
	}

	public float Delay {
		get {
			return rechargeDelay;
		}
		set {
			rechargeDelay = value;
		}
	}

	public override bool isRenewable {
		get {
			return Time <= 0;
		}
	}

	public TimelyRechargedUpgrade (String name) : base(name)
	{
	}

	public virtual void Start(){
		Time += (Delay + Frequency);
	}

	public void UpdateTime(float deltaTime){
		if (!isRenewable)
			Time -= deltaTime;
		else
			if(Active) Restore ();
	}

	public override void Activate ()
	{
		base.Activate ();
		if (spamProtection) {	
			Time = Frequency;
		} else {
			if (isRenewable) {
				Time = Frequency;
			}
		}
	}

}

