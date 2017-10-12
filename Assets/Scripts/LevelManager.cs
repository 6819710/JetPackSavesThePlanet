using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StateManager))]
public class LevelManager : MonoBehaviour {

	public List<LevelProfile> levels;

	public int currentLevel = 0;

	public float randomTickSpeed = 3;

	private float time;
	private LevelProfile currentLP;

	private StateManager stateManager;
	private GameState shown;

	public int Level{
		get {  return currentLevel; }
		set { currentLevel = value; } 
	}

	public LevelProfile this [int i]{
		get { return levels [i]; } 
		set { levels [i] = value; } 
	}

	public void Add(LevelProfile toAdd){
		levels.Add (toAdd);
	}

	void Start(){
		time = 0;
		stateManager = gameObject.GetComponent<StateManager> ();
	}

	// Update is called once per frame
	void Update () {
		if (currentLP != null) {
			time += Time.deltaTime;
			if(currentLP.condition is ITimable){
				(currentLP.condition as ITimable).Process (Time.deltaTime);
			}
			if (time > Random.value * randomTickSpeed) {
				time = 0;
				RandomEvent ();
			}
			if((currentLP.condition as TerminatingCondition).shouldTerminate()){
				ExitEvent ();
			}
		}
	}

	public void Begin(){
		StartLevel (currentLevel);
	}

	void StartLevel(int level){
		if(level < levels.Count){
			currentLP = this [level];
			if(currentLP.condition is ITimable){
				(currentLP.condition as ITimable).Start ();
			}
			BeginEvent ();
		}
	}

	public void NextLevel(){
		StartLevel (++currentLevel);
	}

	public void RestartLevel(){
		StartLevel (currentLevel);
	}

	public void BeginEvent(){
		currentLP.onEnter.Invoke ();
	}

	public void RandomEvent(){
		currentLP.onRandom.Invoke ();
	}

	public void ExitEvent(){
		currentLP.onExit.Invoke ();
	}


}
