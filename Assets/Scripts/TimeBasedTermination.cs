using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeBasedTermination : TerminatingCondition, ITimable  {

	[SerializeField] public float startDelay = 0;
	[SerializeField] public float startFrequency = 0;

	private float time = 0;

	public float Frequency {
		get { return startFrequency; }
		set { startFrequency = value; }
	}

	public float Time {
		get { return time; }
		set { time = value; }
	}

	public float Delay {
		get { return startDelay; }
		set { startDelay = value;}
	}

	public void Start(){
		Time += (Delay + Frequency);
	}

	public void Process(float deltaTime){
		Time -= deltaTime;
	}

	public void Stop(){
		Time  = 0;
	}

	public override bool shouldTerminate(){
		return Time <= 0;
	}
}
