using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float UnitsPerPoint = 1;
  
	private GameObject ThePlayer;

    private float UnitsTraveled = 0;

	// Use this for initialization
	void Start () {
        //Get the player reference from the game manager
		if (ThePlayer == null) ThePlayer = GameManager.instance.Player;
        
	}
	
	// Update is called once per frame
	void Update () {
        //Updates the units traveled if the player has moved further than the saved distance
        float CurrentUnits = ThePlayer.transform.position.y;
		if (UnitsTraveled <= CurrentUnits)
            UnitsTraveled = CurrentUnits;
	}

    //Returns the scrore
    public double CurrentScore
    {
        get
        {
            return Mathf.Round(UnitsTraveled / UnitsPerPoint);
        }
    }
}
