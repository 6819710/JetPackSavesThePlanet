using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class POWUpgrade : ConsumableUpgrade, ITimable {

	[SerializeField] private float radius = 5;
	[SerializeField] public float powTime = 1;
	[SerializeField] public float delay = 0;

	private float time = 0; 

	public float Frequency {
		get { return powTime; }
		set { powTime = value; }
	}

	public float Time {
		get { return time; }
		set { time = value; }
	}

	public float Delay {
		get { return delay; }
		set { delay = value;}
	}


	public void Start(){
		Time += (Delay + Frequency);
	}

	public POWUpgrade (string name): base(name)
	{
	}

	public override void Activate ()
	{
		Start ();
		base.Activate ();
	}

	public override void Effect ()
	{
		UnityEngine.Time.timeScale = 0.5f;
		GameObject player = GameManager.instance.Player;
		List<SpawnableObject> toDestroy = GameManager.instance.Director.GetComponent<AsteroidSpawner> ().InScreen;
		foreach(SpawnableObject so in toDestroy){
			Asteroid a = so.gameObject.GetComponent<Asteroid> ();
			if (a != null) { // If the spawnable object is an asteroid 
				a.Split (a.gameObject.transform.position - player.transform.position);
				a.Destruct ();
			}
		}
	}

	public void Process(float deltaTime){
		Time-=deltaTime;
		if (Active) {
			if (UnityEngine.Time.timeScale > 0.5)
				UnityEngine.Time.timeScale -= 0.1f;
		} 
		if(Time<=0) Stop ();
	}

	public void Stop(){
		Time  = 0;
		Restore ();
	}

	public override void Restore ()
	{
		UnityEngine.Time.timeScale = 1;
		base.Restore ();
	}
}
