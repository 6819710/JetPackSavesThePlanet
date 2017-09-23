using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu]
public class LevelProfile: System.Object {

	[Header("Level Details")]
	[SerializeField] public string name; 
	[SerializeField] public LevelDifficulty difficulty; 

	[Space(5)]

	[Header("Level Events")]
	[SerializeField] public UnityEvent onEnter; 
	[SerializeField] public UnityEvent onRandom; 
	[SerializeField] public UnityEvent onExit; 

	[Header("Level Terminating Condition")]
	[SerializeField] public UnityEvent shouldExit;

	public LevelProfile ()
	{
	}

	public enum LevelDifficulty{
		Easy, Medium, Hard
	}


}

