using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private GameObject ThePlayer;

	public int score = 0;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
		}
	}

	// Use this for initialization
	void Start () {
		Initialise ();
	}

	public void Initialise(){
		//Get the player reference from the game manager
		if (ThePlayer == null) ThePlayer = GameManager.instance.Player;
	}

    //Returns the scrore
    public double CurrentScore
    {
        get
        {
			return Score;
        }
    }
}
