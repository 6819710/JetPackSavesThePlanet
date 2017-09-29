using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour {

	public float value = 1;
	public float max = 1;

	public UnityEvent onDeath;

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
		if (isDead) {
			Die ();
		}
	}

	public void Die(){
		onDeath.Invoke ();
	}

	public void dealDamage(float amount){
		value -= amount;
	}


}
