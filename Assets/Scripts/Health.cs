using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateManager))]

public class Health : MonoBehaviour {

	public float value = 1;
	public float max = 1;

	private PlayerStateManager playerStateManager;

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
		playerStateManager = gameObject.GetComponent<PlayerStateManager> ();
		if (value > max)
			value = max;
	}

	void Update(){
		if (isDead) {
			Die ();
		}
	}

	public void Die(){
		GameManager.instance.StateManager.Lost ();
		playerStateManager.Dead ();
		this.gameObject.GetComponent<SwipeToMove> ().enabled = false;
		this.gameObject.GetComponent<Breathing> ().enabled = false;
	}

	public void dealDamage(float amount){
		value -= amount;
	}


}
