using System;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class ShieldUpgrade : ConsumableUpgrade, ITimable
{
	[SerializeField]
	private float sheildSize = 1; // Size of the shield

	[SerializeField]
	private float sheildTime = 5; // Time the shield is kept for

	[SerializeField]
	private float sheildDelay = 5; // Time taken to activate sheild

	[SerializeField]
	private GameObject shieldPrefab; // prefab for the shield 

	private float time; 
	private GameObject shield;

	public float Size {
		get { return sheildSize; }
		set { sheildSize = value; }
	}

	public float Frequency {
		get { return sheildTime; }
		set { sheildTime = value; }
	}

	public float Time {
		get { return time; }
		set { time = value; }
	}

	public float Delay {
		get { return sheildDelay; }
		set { sheildDelay = value;}
	}

	public void Start(){
		Time += (Delay + Frequency);
	}

	public void Process(float deltaTime){
		if (Time>0)
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
		Time = Frequency;
	}

	public ShieldUpgrade (String name): base(name)
	{
	}

	public override void Effect ()
	{
		shield = Instantiate (shieldPrefab, this.Owner.transform);
		shield.transform.localScale *= sheildSize;
		shield.transform.SetParent (this.Owner.transform);
	}

	public override void Restore ()
	{
		base.Restore ();
		Destroy (shield);
	}
}

