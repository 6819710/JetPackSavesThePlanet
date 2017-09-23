using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour {

	public List<LevelProfile> levels;

	public int currentLevel;

	[SerializeField] public UnityEvent onEnter; 

	public int Level{
		get {  return currentLevel; }
		set { currentLevel = value; } 
	}

	public LevelProfile this [int i]{
		get { return levels [i]; } 
		set { levels [i] = value; } 
	}

	void Awake(){
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Add(LevelProfile toAdd){
		levels.Add (toAdd);
	}
}
