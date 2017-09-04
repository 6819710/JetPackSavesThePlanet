using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float value = 1;
	public float max = 1;

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
			GameManager.instance.StateManager.Lost ();
			this.gameObject.GetComponent<SwipeToMove> ().enabled = false;
			this.gameObject.GetComponent<Breathing> ().enabled = false;
		}
	}

	public void dealDamage(float amount){
		value -= amount;
	}


}
