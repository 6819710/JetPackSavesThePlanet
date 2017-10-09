using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LevelProfile: System.Object {

	[Header("Level Details")]
	[SerializeField] public string name; 
	[SerializeField] public LevelDifficulty difficulty; 

	[Space(5)]

	[Header("Level Events")]
	[SerializeField] public UnityEvent onEnter; 
	[SerializeField] public UnityEvent onRandom; 
	[SerializeField] public UnityEvent onExit; 


	[Header("Level Termination")]
	[SerializeField] public DistanceBasedTermination condition;

	public enum LevelDifficulty{
		Easy, Medium, Hard
	}
}

