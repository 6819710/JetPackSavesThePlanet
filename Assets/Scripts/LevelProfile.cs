using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[System.Serializable]
[CreateAssetMenu]
public class LevelProfile: ScriptableObject {

	[Header("Level Spawns")]
	[SerializeField] public List<GameObject> spawns; 
	[SerializeField] float spawnFrequency;

	[Space(10)]

	[Header("Level Options")]
	[SerializeField] public float distance; 
	[SerializeField] public Sprite background; 

	[Space(5)]

	[Header("Level Events")]
	[SerializeField] public UnityEvent onEnter; 
	[SerializeField] public UnityEvent onRandom; 
	[SerializeField] public UnityEvent onExit; 

	public LevelProfile ()
	{
	}


}

