using System;

public abstract class TimelyRechargedUpgrade : RenewableUpgrade 
{
	private float frequency = 1; 
	private float time = 0; 
	private float delay = 0; 

	public float Frequency {
		get {
			return frequency;
		}
		set {
			frequency = value;
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
			return delay;
		}
		set {
			delay = value;
		}
	}

	public override bool isRenewable {
		get {
			return Time > 0;
		}
	}

	public TimelyRechargedUpgrade (String name) : base(name)
	{
	}

	public virtual void Start(){
		Time += (Delay + Frequency);
	}

	public void UpdateTime(float deltaTime){
		Time -= deltaTime;
	}
}

