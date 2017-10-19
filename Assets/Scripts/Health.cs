using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

	public float value = 1;
	public float max = 1;
	
	private DamageType killingBlow;
	public DeathEvent onDeath;
	private bool executed = false;

	public float Value { 
		get { return value; }
		set { this.value = value; }
	}

	public float Max{
		get { return max; }
		set { this.max = value; }
	}

	public bool isDead{
		get { return value <= 0; }
	}

	void Start () {
		if (value > max)
			value = max;
	}

	void Update(){
		if (isDead && !executed)
			Die ();
	}

	public void Die(){
        executed = true;
        onDeath.Invoke(killingBlow);
    }

	public void dealDamage(DamageType dm, float amount){
		value -= amount;
		killingBlow = dm;
	}

	[System.Serializable]
	public class DeathEvent: UnityEvent<DamageType>{}

	public enum DamageType: int { Worm=0, Suffocation=1, Explosion=2 }


}
